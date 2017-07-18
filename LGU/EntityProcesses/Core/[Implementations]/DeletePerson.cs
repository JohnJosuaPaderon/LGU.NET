using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.Core;
using LGU.EntityConverters.Core;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.Core
{
    public sealed class DeletePerson : PersonProcess, IDeletePerson
    {
        public DeletePerson(IConnectionStringSource connectionStringSource, IPersonConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public Person Person { get; set; }

        private SqlQueryInfo<Person> QueryInfo =>
            SqlQueryInfo<Person>.CreateProcedureQueryInfo(Person, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", Person.Id)
            .AddLogByParameter();

        private IProcessResult<Person> GetProcessResult(Person data, SqlCommand command, int affectedRows)
        {
            if (affectedRows == 1)
            {
                return new ProcessResult<Person>(data);
            }
            else
            {
                return new ProcessResult<Person>(ProcessResultStatus.Failed, "Failed to delete person.");
            }
        }

        public IProcessResult<Person> Execute()
        {
            return SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<Person>> ExecuteAsync()
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<Person>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}

using LGU.Data.Extensions;
using LGU.Data.RDBMS;
using LGU.Entities.Core;
using LGU.EntityConverters.Core;
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

        private SqlDataQueryInfo<Person> QueryInfo =>
            SqlDataQueryInfo<Person>.CreateProcedureQueryInfo(Person, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", Person.Id)
            .AddLogByParameter();

        private IDataProcessResult<Person> GetProcessResult(Person data, SqlCommand command, int affectedRows)
        {
            if (affectedRows == 1)
            {
                return new DataProcessResult<Person>(data);
            }
            else
            {
                return new DataProcessResult<Person>(ProcessResultStatus.Failed, "Failed to delete person.");
            }
        }

        public IDataProcessResult<Person> Execute()
        {
            return SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IDataProcessResult<Person>> ExecuteAsync()
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IDataProcessResult<Person>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}

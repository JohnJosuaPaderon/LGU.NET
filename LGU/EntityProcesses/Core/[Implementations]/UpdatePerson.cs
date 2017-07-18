using LGU.Data.Extensions;
using LGU.Data.RDBMS;
using LGU.Entities.Core;
using LGU.EntityConverters.Core;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.Core
{
    public sealed class UpdatePerson : PersonProcess, IUpdatePerson
    {
        public UpdatePerson(IConnectionStringSource connectionStringSource, IPersonConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public Person Person { get; set; }

        private SqlDataQueryInfo<Person> QueryInfo =>
            SqlDataQueryInfo<Person>.CreateProcedureQueryInfo(Person, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", Person.Id)
            .AddInputParameter("@_FirstName", Person.FirstName)
            .AddInputParameter("@_MiddleName", Person.MiddleName)
            .AddInputParameter("@_LastName", Person.LastName)
            .AddInputParameter("@_NameExtension", Person.NameExtension)
            .AddInputParameter("@_GenderId", Person.Gender?.Id)
            .AddInputParameter("@_BirthDate", Person.BirthDate)
            .AddInputParameter("@_Deceased", Person.Deceased)
            .AddLogByParameter();

        private IProcessResult<Person> GetProcessResult(Person data, SqlCommand command, int affectedRows)
        {
            if (affectedRows == 1)
            {
                return new ProcessResult<Person>(data);
            }
            else
            {
                return new ProcessResult<Person>(ProcessResultStatus.Failed, "Failed to update person.");
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

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
    public sealed class UpdatePerson : PersonProcess, IUpdatePerson
    {
        public UpdatePerson(IConnectionStringSource connectionStringSource, IPersonConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public IPerson Person { get; set; }

        private SqlQueryInfo<IPerson> QueryInfo =>
            SqlQueryInfo<IPerson>.CreateProcedureQueryInfo(Person, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", Person.Id)
            .AddInputParameter("@_FirstName", Person.FirstName)
            .AddInputParameter("@_MiddleName", Person.MiddleName)
            .AddInputParameter("@_LastName", Person.LastName)
            .AddInputParameter("@_NameExtension", Person.NameExtension)
            .AddInputParameter("@_GenderId", Person.Gender?.Id)
            .AddInputParameter("@_BirthDate", Person.BirthDate)
            .AddInputParameter("@_Deceased", Person.Deceased)
            .AddLogByParameter();

        private IProcessResult<IPerson> GetProcessResult(IPerson data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<IPerson>(data);
            }
            else
            {
                return new ProcessResult<IPerson>(ProcessResultStatus.Failed, "Failed to update person.");
            }
        }

        public IProcessResult<IPerson> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IPerson>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IPerson>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}

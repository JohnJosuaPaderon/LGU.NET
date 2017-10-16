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
        public DeletePerson(IConnectionStringSource connectionStringSource, IPersonConverter converter) : base(connectionStringSource, converter)
        {
        }

        public IPerson Person { get; set; }

        private SqlQueryInfo<IPerson> QueryInfo =>
            SqlQueryInfo<IPerson>.CreateProcedureQueryInfo(Person, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", Person.Id)
            .AddLogByParameter();

        private IProcessResult<IPerson> GetProcessResult(IPerson data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<IPerson>(data);
            }
            else
            {
                return new ProcessResult<IPerson>(ProcessResultStatus.Failed, "Failed to delete person.");
            }
        }

        public IProcessResult<IPerson> Execute()
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IPerson>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IPerson>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}

using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class DeleteApplication : ApplicationProcess, IDeleteApplication
    {
        public DeleteApplication(IConnectionStringSource connectionStringSource, IApplicationConverter converter) : base(connectionStringSource, converter)
        {
        }

        public IApplication Application { get; set; }

        private SqlQueryInfo<IApplication> QueryInfo =>
            SqlQueryInfo<IApplication>.CreateProcedureQueryInfo(Application, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", Application.Id)
            .AddLogByParameter();

        private IProcessResult<IApplication> GetProcessResult(IApplication data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<IApplication>(data, ProcessResultStatus.Success);
            }
            else
            {
                return new ProcessResult<IApplication>(ProcessResultStatus.Failed, "Failed to delete application.");
            }
        }

        public IProcessResult<IApplication> Execute()
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IApplication>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IApplication>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}

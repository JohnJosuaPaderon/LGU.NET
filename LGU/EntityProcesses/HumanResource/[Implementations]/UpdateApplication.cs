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
    public sealed class UpdateApplication : ApplicationProcess, IUpdateApplication
    {
        public UpdateApplication(IConnectionStringSource connectionStringSource, IApplicationConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public IApplication Application { get; set; }

        private SqlQueryInfo<IApplication> QueryInfo =>
            SqlQueryInfo<IApplication>.CreateProcedureQueryInfo(Application, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", Application.Id)
            .AddInputParameter("@_ApplicantId", Application.Applicant?.Id)
            .AddInputParameter("@_StatusId", Application.Status?.Id)
            .AddInputParameter("@_Date", Application.Date)
            .AddInputParameter("@_ApplyingPositionId", Application.ApplyingPosition?.Id)
            .AddLogByParameter();

        private IProcessResult<IApplication> GetProcessResult(IApplication data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<IApplication>(data);
            }
            else
            {
                return new ProcessResult<IApplication>(ProcessResultStatus.Failed, "Failed to update application.");
            }
        }

        public IProcessResult<IApplication> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IApplication>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IApplication>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}

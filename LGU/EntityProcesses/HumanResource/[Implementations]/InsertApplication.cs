using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class InsertApplication : ApplicationProcess, IInsertApplication
    {
        public InsertApplication(IConnectionStringSource connectionStringSource, IApplicationConverter converter) : base(connectionStringSource, converter)
        {
        }

        public IApplication Application { get; set; }

        private SqlQueryInfo<IApplication> QueryInfo =>
            SqlQueryInfo<IApplication>.CreateProcedureQueryInfo(Application, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddOutputParameter("@_Id", DbType.Int64)
            .AddInputParameter("@_ApplicantId", Application.Applicant?.Id)
            .AddInputParameter("@_StatusId", Application.Status?.Id)
            .AddInputParameter("@_Date", Application.Date)
            .AddInputParameter("@_ApplyingPositionId", Application.ApplyingPosition?.Id)
            .AddLogByParameter();

        private IProcessResult<IApplication> GetProcessResult(IApplication data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                data.Id = command.Parameters.GetInt64("@_Id");
                return new ProcessResult<IApplication>(data);
            }
            else
            {
                return new ProcessResult<IApplication>(ProcessResultStatus.Failed, "Failed to insert application.");
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

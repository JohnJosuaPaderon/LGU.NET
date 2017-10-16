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
    public sealed class DeleteWorkTimeSchedule : WorkTimeScheduleProcess, IDeleteWorkTimeSchedule
    {
        public DeleteWorkTimeSchedule(IConnectionStringSource connectionStringSource, IWorkTimeScheduleConverter converter) : base(connectionStringSource, converter)
        {
        }

        public IWorkTimeSchedule WorkTimeSchedule { get; set; }

        private SqlQueryInfo<IWorkTimeSchedule> QueryInfo =>
            SqlQueryInfo<IWorkTimeSchedule>.CreateProcedureQueryInfo(WorkTimeSchedule, GetQualifiedDbObjectName(), GetProcessResult, true)
                .AddInputParameter("@_Id", WorkTimeSchedule.Id)
                .AddLogByParameter();

        private IProcessResult<IWorkTimeSchedule> GetProcessResult(IWorkTimeSchedule WorkTimeSchedule, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<IWorkTimeSchedule>(WorkTimeSchedule);
            }
            else
            {
                return new ProcessResult<IWorkTimeSchedule>(ProcessResultStatus.Failed, "Failed to delete work-time schedule.");
            }
        }

        public IProcessResult<IWorkTimeSchedule> Execute()
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IWorkTimeSchedule>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IWorkTimeSchedule>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}

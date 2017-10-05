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
    public sealed class UpdateWorkTimeSchedule : WorkTimeScheduleProcess, IUpdateWorkTimeSchedule
    {
        private const string MESSAGE_FAILED = "Failed to update work-time schedule.";
        private const string PARAMETER_ID = "@_Id";
        private const string PARAMETER_WORK_TIME_START = "@_WorkTimeStart";
        private const string PARAMETER_WORK_TIME_END = "@_WorkTimeEnd";
        private const string PARAMETER_BREAK_TIME = "@_BreakTime";
        private const string PARAMETER_WORKING_MONTH_DAYS = "@_WorkingMonthDays";

        public UpdateWorkTimeSchedule(IConnectionStringSource connectionStringSource, IWorkTimeScheduleConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public IWorkTimeSchedule WorkTimeSchedule { get; set; }

        public SqlQueryInfo<IWorkTimeSchedule> QueryInfo =>
            SqlQueryInfo<IWorkTimeSchedule>.CreateProcedureQueryInfo(WorkTimeSchedule, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter(PARAMETER_ID, WorkTimeSchedule.Id)
            .AddInputParameter(PARAMETER_WORK_TIME_START, WorkTimeSchedule.WorkTimeStart)
            .AddInputParameter(PARAMETER_WORK_TIME_END, WorkTimeSchedule.WorkTimeEnd)
            .AddInputParameter(PARAMETER_BREAK_TIME, WorkTimeSchedule.BreakTime?.Ticks)
            .AddInputParameter(PARAMETER_WORKING_MONTH_DAYS, WorkTimeSchedule.WorkingMonthDays)
            .AddLogByParameter();

        private IProcessResult<IWorkTimeSchedule> GetProcessResult(IWorkTimeSchedule data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<IWorkTimeSchedule>(WorkTimeSchedule);
            }
            else
            {
                return new ProcessResult<IWorkTimeSchedule>(ProcessResultStatus.Failed, MESSAGE_FAILED);
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

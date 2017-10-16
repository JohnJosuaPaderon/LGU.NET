using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class InsertEmployeeFlexWorkSchedule : HumanResourceProcessBaseV2, IInsertEmployeeFlexWorkSchedule
    {
        private const string MESSAGE_FAILED = "Failed to insert employee flex work schedule.";

        public InsertEmployeeFlexWorkSchedule(IConnectionStringSource connectionStringSource, IEmployeeFlexWorkScheduleParameters parameters) : base(connectionStringSource)
        {
            _Parameters = parameters;
        }

        private readonly IEmployeeFlexWorkScheduleParameters _Parameters;

        public IEmployeeFlexWorkSchedule EmployeeFlexWorkSchedule { get; set; }

        private SqlQueryInfo<IEmployeeFlexWorkSchedule> QueryInfo =>
            SqlQueryInfo<IEmployeeFlexWorkSchedule>.CreateProcedureQueryInfo(EmployeeFlexWorkSchedule, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddOutputParameter(_Parameters.Id, DbType.Int64)
            .AddInputParameter(_Parameters.EmployeeId, EmployeeFlexWorkSchedule.Employee?.Id)
            .AddInputParameter(_Parameters.EffectivityDateBegin, EmployeeFlexWorkSchedule.EffectivityDate.Begin)
            .AddInputParameter(_Parameters.EffectivityDateEnd, EmployeeFlexWorkSchedule.EffectivityDate.End)
            .AddInputParameter(_Parameters.SundayWorkTimeScheduleId, EmployeeFlexWorkSchedule.SundayWorkTimeSchedule?.Id)
            .AddInputParameter(_Parameters.MondayWorkTimeScheduleId, EmployeeFlexWorkSchedule.MondayWorkTimeSchedule?.Id)
            .AddInputParameter(_Parameters.TuesdayWorkTimeScheduleId, EmployeeFlexWorkSchedule.TuesdayWorkTimeSchedule?.Id)
            .AddInputParameter(_Parameters.WednesdayWorkTimeScheduleId, EmployeeFlexWorkSchedule.WednesdayWorkTimeSchedule?.Id)
            .AddInputParameter(_Parameters.ThursdayWorkTimeScheduleId, EmployeeFlexWorkSchedule.ThursdayWorkTimeSchedule?.Id)
            .AddInputParameter(_Parameters.FridayWorkTimeScheduleId, EmployeeFlexWorkSchedule.FridayWorkTimeSchedule?.Id)
            .AddInputParameter(_Parameters.SaturdayWorkTimeScheduleId, EmployeeFlexWorkSchedule.SaturdayWorkTimeSchedule?.Id)
            .AddLogByParameter();

        private IProcessResult<IEmployeeFlexWorkSchedule> GetProcessResult(IEmployeeFlexWorkSchedule data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                data.Id = command.Parameters.GetInt64(_Parameters.Id);
                return new ProcessResult<IEmployeeFlexWorkSchedule>(data);
            }
            else
            {
                return new ProcessResult<IEmployeeFlexWorkSchedule>(ProcessResultStatus.Failed, MESSAGE_FAILED);
            }
        }

        public IProcessResult<IEmployeeFlexWorkSchedule> Execute()
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IEmployeeFlexWorkSchedule>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IEmployeeFlexWorkSchedule>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}

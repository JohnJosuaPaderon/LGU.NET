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
    public sealed class InsertEmployeeWorkTimeSchedule : EmployeeWorkTimeScheduleProcess, IInsertEmployeeWorkTimeSchedule
    {
        public InsertEmployeeWorkTimeSchedule(IConnectionStringSource connectionStringSource, IEmployeeWorkTimeScheduleConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public EmployeeWorkTimeSchedule WorkTimeSchedule { get; set; }

        private SqlQueryInfo<EmployeeWorkTimeSchedule> QueryInfo =>
            SqlQueryInfo<EmployeeWorkTimeSchedule>.CreateProcedureQueryInfo(WorkTimeSchedule, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddOutputParameter("@_Id", DbType.Int64)
            .AddInputParameter("@_EmployeeId", WorkTimeSchedule.Employee?.Id)
            .AddInputParameter("@_WorkTimeStart", WorkTimeSchedule.WorkTimeStart)
            .AddInputParameter("@_WorkTimeEnd", WorkTimeSchedule.WorkTimeEnd)
            .AddInputParameter("@_EffectivityDate", WorkTimeSchedule.EffectivityDate)
            .AddInputParameter("@_IsEnabled", WorkTimeSchedule.IsEnabled)
            .AddInputParameter("@_InvocationLevel", WorkTimeSchedule.InvocationLevel)
            .AddLogByParameter();

        private IProcessResult<EmployeeWorkTimeSchedule> GetProcessResult(EmployeeWorkTimeSchedule data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                data.Id = command.Parameters.GetInt64("@_Id");
                return new ProcessResult<EmployeeWorkTimeSchedule>(data);
            }
            else
            {
                return new ProcessResult<EmployeeWorkTimeSchedule>(ProcessResultStatus.Failed, "Failed to insert work time schedule.");
            }
        }

        public IProcessResult<EmployeeWorkTimeSchedule> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<EmployeeWorkTimeSchedule>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<EmployeeWorkTimeSchedule>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}

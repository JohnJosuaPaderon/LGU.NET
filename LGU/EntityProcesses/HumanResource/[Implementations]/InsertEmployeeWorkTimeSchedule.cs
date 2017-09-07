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
    public sealed class InsertEmployeeWorkTimeSchedule : EmployeeWorkTimeScheduleProcess, IInsertEmployeeWorkTimeSchedule
    {
        public InsertEmployeeWorkTimeSchedule(IConnectionStringSource connectionStringSource, IEmployeeWorkTimeScheduleConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public IEmployeeWorkTimeSchedule EmployeeWorkTimeSchedule { get; set; }

        private SqlQueryInfo<IEmployeeWorkTimeSchedule> QueryInfo =>
            SqlQueryInfo<IEmployeeWorkTimeSchedule>.CreateProcedureQueryInfo(EmployeeWorkTimeSchedule, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_EmployeeId", EmployeeWorkTimeSchedule.Employee?.Id)
            .AddInputParameter("@_WorkTimeScheduleId", EmployeeWorkTimeSchedule.WorkTimeSchedule?.Id)
            .AddLogByParameter();

        private IProcessResult<IEmployeeWorkTimeSchedule> GetProcessResult(IEmployeeWorkTimeSchedule data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<IEmployeeWorkTimeSchedule>(data);
            }
            else
            {
                return new ProcessResult<IEmployeeWorkTimeSchedule>(ProcessResultStatus.Failed, "Failed to insert work time schedule.");
            }
        }

        public IProcessResult<IEmployeeWorkTimeSchedule> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IEmployeeWorkTimeSchedule>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IEmployeeWorkTimeSchedule>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}

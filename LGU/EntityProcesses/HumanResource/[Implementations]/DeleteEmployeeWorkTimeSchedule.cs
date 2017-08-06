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
    public sealed class DeleteEmployeeWorkTimeSchedule : EmployeeWorkTimeScheduleProcess, IDeleteEmployeeWorkTimeSchedule
    {
        public DeleteEmployeeWorkTimeSchedule(IConnectionStringSource connectionStringSource, IEmployeeWorkTimeScheduleConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public EmployeeWorkTimeSchedule WorkTimeSchedule { get; set; }

        private SqlQueryInfo<EmployeeWorkTimeSchedule> QueryInfo =>
            SqlQueryInfo<EmployeeWorkTimeSchedule>.CreateProcedureQueryInfo(WorkTimeSchedule, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", WorkTimeSchedule.Id)
            .AddLogByParameter();

        private IProcessResult<EmployeeWorkTimeSchedule> GetProcessResult(EmployeeWorkTimeSchedule data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<EmployeeWorkTimeSchedule>(data);
            }
            else
            {
                return new ProcessResult<EmployeeWorkTimeSchedule>(ProcessResultStatus.Failed, "Failed to delete work time schedule.");
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

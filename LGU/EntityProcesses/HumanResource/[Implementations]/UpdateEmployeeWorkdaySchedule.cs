using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class UpdateEmployeeWorkdaySchedule : HumanResourceProcessBaseV2, IUpdateEmployeeWorkdaySchedule
    {
        private const string MESSAGE_FAILED = "Failed to update employee workday schedule.";

        public UpdateEmployeeWorkdaySchedule(IConnectionStringSource connectionStringSource, IEmployeeWorkdayScheduleParameters parameters) : base(connectionStringSource)
        {
            _Parameters = parameters;
        }

        public IEmployeeWorkdaySchedule EmployeeWorkdaySchedule { get; set; }

        private readonly IEmployeeWorkdayScheduleParameters _Parameters;

        private SqlQueryInfo<IEmployeeWorkdaySchedule> QueryInfo =>
            SqlQueryInfo<IEmployeeWorkdaySchedule>.CreateProcedureQueryInfo(EmployeeWorkdaySchedule, nameof(UpdateEmployeeWorkdaySchedule), GetProcessResult, true)
            .AddInputParameter(_Parameters.Id, EmployeeWorkdaySchedule.Id)
            .AddInputParameter(_Parameters.EmployeeId, EmployeeWorkdaySchedule.Employee?.Id)
            .AddInputParameter(_Parameters.Sunday, EmployeeWorkdaySchedule.Sunday)
            .AddInputParameter(_Parameters.Monday, EmployeeWorkdaySchedule.Monday)
            .AddInputParameter(_Parameters.Tuesday, EmployeeWorkdaySchedule.Tuesday)
            .AddInputParameter(_Parameters.Wednesday, EmployeeWorkdaySchedule.Wednesday)
            .AddInputParameter(_Parameters.Thursday, EmployeeWorkdaySchedule.Thursday)
            .AddInputParameter(_Parameters.Friday, EmployeeWorkdaySchedule.Friday)
            .AddInputParameter(_Parameters.Saturday, EmployeeWorkdaySchedule.Saturday)
            .AddLogByParameter();

        private IProcessResult<IEmployeeWorkdaySchedule> GetProcessResult(IEmployeeWorkdaySchedule data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<IEmployeeWorkdaySchedule>(data);
            }
            else
            {
                return new ProcessResult<IEmployeeWorkdaySchedule>(ProcessResultStatus.Failed, MESSAGE_FAILED);
            }
        }

        public IProcessResult<IEmployeeWorkdaySchedule> Execute()
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IEmployeeWorkdaySchedule>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IEmployeeWorkdaySchedule>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}

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
    public sealed class InsertEmployeeWorkdaySchedule : HumanResourceProcessBaseV2, IInsertEmployeeWorkdaySchedule
    {
        private const string MESSAGE_FAILED = "Failed to insert employee workday schedule.";

        public InsertEmployeeWorkdaySchedule(IConnectionStringSource connectionStringSource, IEmployeeWorkdayScheduleParameters parameters) : base(connectionStringSource)
        {
            _FailedResult = new ProcessResult<IEmployeeWorkdaySchedule>(ProcessResultStatus.Failed, MESSAGE_FAILED);
            _Parameters = parameters;
        }

        public IEmployeeWorkdaySchedule EmployeeWorkdaySchedule { get; set; }

        private readonly IProcessResult<IEmployeeWorkdaySchedule> _FailedResult;
        private readonly IEmployeeWorkdayScheduleParameters _Parameters;

        private SqlQueryInfo<IEmployeeWorkdaySchedule> QueryInfo =>
            SqlQueryInfo<IEmployeeWorkdaySchedule>.CreateProcedureQueryInfo(EmployeeWorkdaySchedule, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddOutputParameter(_Parameters.Id, DbType.Int64)
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
                data.Id = command.Parameters.GetInt64(_Parameters.Id);
                return new ProcessResult<IEmployeeWorkdaySchedule>(data);
            }
            else
            {
                return _FailedResult;
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

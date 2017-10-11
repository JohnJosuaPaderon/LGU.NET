using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class DeleteEmployeeWorkdaySchedule : HumanResourceProcessBaseV2, IDeleteEmployeeWorkdaySchedule
    {
        private const string MESSAGE_FAILED = "Failed to delete employee workday schedule.";
        private const string PARAM_ID = "@_Id";

        public DeleteEmployeeWorkdaySchedule(IConnectionStringSource connectionStringSource) : base(connectionStringSource)
        {
            _FailedResult = new ProcessResult<IEmployeeWorkdaySchedule>(ProcessResultStatus.Failed, MESSAGE_FAILED);
        }

        public IEmployeeWorkdaySchedule EmployeeWorkdaySchedule { get; set; }

        private readonly IProcessResult<IEmployeeWorkdaySchedule> _FailedResult;

        private SqlQueryInfo<IEmployeeWorkdaySchedule> QueryInfo =>
            SqlQueryInfo<IEmployeeWorkdaySchedule>.CreateProcedureQueryInfo(EmployeeWorkdaySchedule, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter(PARAM_ID, EmployeeWorkdaySchedule.Id)
            .AddLogByParameter();

        private IProcessResult<IEmployeeWorkdaySchedule> GetProcessResult(IEmployeeWorkdaySchedule data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
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

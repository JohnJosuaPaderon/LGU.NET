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
    public sealed class DeleteEmployee : HumanResourceProcessBaseV2, IDeleteEmployee
    {
        private const string MESSAGE_FAILED = "Failed to delete employee.";

        public DeleteEmployee(IConnectionStringSource connectionStringSource, IEmployeeParameters parameters) : base(connectionStringSource)
        {
            _Parameters = parameters;
        }

        private readonly IEmployeeParameters _Parameters;

        public IEmployee Employee { get; set; }

        private SqlQueryInfo<IEmployee> QueryInfo =>
            SqlQueryInfo<IEmployee>.CreateProcedureQueryInfo(Employee, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter(_Parameters.Id, Employee.Id)
            .AddLogByParameter();

        private IProcessResult<IEmployee> GetProcessResult(IEmployee data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<IEmployee>(data, ProcessResultStatus.Success);
            }
            else
            {
                return new ProcessResult<IEmployee>(ProcessResultStatus.Failed, MESSAGE_FAILED);
            }
        }

        public IProcessResult<IEmployee> Execute()
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IEmployee>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IEmployee>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}

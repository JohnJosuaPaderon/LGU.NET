using LGU.Data.Extensions;
using LGU.Data.RDBMS;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class DeleteEmployee : HumanResourceProcessBase, IDeleteEmployee
    {
        public DeleteEmployee(IConnectionStringSource connectionStringSource) : base(connectionStringSource)
        {
        }

        public Employee Employee { get; set; }

        private SqlDataQueryInfo<Employee> QueryInfo =>
            SqlDataQueryInfo<Employee>.CreateProcedureQueryInfo(Employee, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", Employee.Id)
            .AddLogByParameter();

        private IProcessResult<Employee> GetProcessResult(Employee data, SqlCommand command, int affectedRows)
        {
            if (affectedRows == 1)
            {
                data.Id = command.Parameters.GetInt64("@_Id");
                return new ProcessResult<Employee>(data, ProcessResultStatus.Success);
            }
            else
            {
                return new ProcessResult<Employee>(ProcessResultStatus.Failed);
            }
        }

        public IProcessResult<Employee> Execute()
        {
            return SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<Employee>> ExecuteAsync()
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<Employee>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}

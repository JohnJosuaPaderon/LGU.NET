using LGU.Data.Extensions;
using LGU.Data.Rdbms;
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

        private SqlQueryInfo<Employee> QueryInfo =>
            SqlQueryInfo<Employee>.CreateProcedureQueryInfo(Employee, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", Employee.Id)
            .AddLogByParameter();

        private IProcessResult<Employee> GetProcessResult(Employee data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
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
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<Employee>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<Employee>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}

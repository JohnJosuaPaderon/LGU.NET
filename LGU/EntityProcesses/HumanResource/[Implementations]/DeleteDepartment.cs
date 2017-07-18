using LGU.Data.Extensions;
using LGU.Data.RDBMS;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class DeleteDepartment : HumanResourceProcessBase, IDeleteDepartment
    {
        public DeleteDepartment(IConnectionStringSource connectionStringSource) : base(connectionStringSource)
        {
        }

        private SqlDataQueryInfo<Department> QueryInfo =>
            SqlDataQueryInfo<Department>.CreateProcedureQueryInfo(Department, GetQualifiedDbObjectName(), GetProcessResult, true)
                .AddInputParameter("Id", Department.Id)
                .AddLogByParameter();

        private IProcessResult<Department> GetProcessResult(Department department, SqlCommand command, int affectedRows)
        {
            if (affectedRows == 1)
            {
                return new ProcessResult<Department>(department);
            }
            else
            {
                return new ProcessResult<Department>(ProcessResultStatus.Failed);
            }
        }

        public Department Department { get; set; }

        public IProcessResult<Department> Execute()
        {
            return SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<Department>> ExecuteAsync()
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<Department>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}

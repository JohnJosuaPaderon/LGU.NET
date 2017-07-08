using LGU.Data.Extensions;
using LGU.Data.RDBMS;
using LGU.Entities.HumanResource;
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

        private SqlDataQueryInfo<Department> GetQueryInfo()
        {
            return SqlDataQueryInfo<Department>.CreateProcedureQueryInfo(Department, GetQualifiedDbObjectName("DeleteDepartment"), GetProcessResult, true)
                .AddInputParameter("Id", Department.Id);
        }

        private IDataProcessResult<Department> GetProcessResult(Department department, SqlCommand command, int affectedRows)
        {
            if (affectedRows == 1)
            {
                return new DataProcessResult<Department>(department);
            }
            else
            {
                return new DataProcessResult<Department>(ProcessResultStatus.Failed);
            }
        }

        public Department Department { get; set; }

        public IDataProcessResult<Department> Execute()
        {
            return SqlHelper.ExecuteNonQuery(GetQueryInfo());
        }

        public Task<IDataProcessResult<Department>> ExecuteAsync()
        {
            return SqlHelper.ExecuteNonQueryAsync(GetQueryInfo());
        }

        public Task<IDataProcessResult<Department>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteNonQueryAsync(GetQueryInfo(), cancellationToken);
        }
    }
}

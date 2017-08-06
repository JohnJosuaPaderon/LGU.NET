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
    public sealed class DeleteDepartment : DepartmentProcess, IDeleteDepartment
    {
        public DeleteDepartment(IConnectionStringSource connectionStringSource, IDepartmentConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        private SqlQueryInfo<Department> QueryInfo =>
            SqlQueryInfo<Department>.CreateProcedureQueryInfo(Department, GetQualifiedDbObjectName(), GetProcessResult, true)
                .AddInputParameter("Id", Department.Id)
                .AddLogByParameter();

        private IProcessResult<Department> GetProcessResult(Department department, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<Department>(department);
            }
            else
            {
                return new ProcessResult<Department>(ProcessResultStatus.Failed, "Failed to delete department.");
            }
        }

        public Department Department { get; set; }

        public IProcessResult<Department> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<Department>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<Department>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}

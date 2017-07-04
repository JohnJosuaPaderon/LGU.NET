using LGU.Data.Extensions;
using LGU.Data.RDBMS;
using LGU.Entities.HumanResource;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class DeleteDepartment : ProcessBase, IDeleteDepartment
    {
        public DeleteDepartment(IConnectionStringSource connectionStringSource) : base(connectionStringSource)
        {
        }

        private SqlDataQueryInfo<Department> GetQueryInfo()
        {
            return SqlDataQueryInfo<Department>.CreateProcedureQueryInfo(Department, "DeleteDepartment", GetProcessResult, true)
                .AddOutputParameter("Id")
                .AddInputParameter("Description", Department.Description)
                .AddInputParameter("Abbreviation", Department.Abbreviation);
        }

        private IDataProcessResult<Department> GetProcessResult(Department department, SqlCommand command, int affectedRows)
        {
            if (affectedRows == 1)
            {
                department.Id = command.Parameters.GetUInt32("Id");
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

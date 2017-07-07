using LGU.Data.Extensions;
using LGU.Data.RDBMS;
using LGU.Entities.HumanResource;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class UpdateDepartment : ProcessBase, IUpdateDepartment
    {
        public UpdateDepartment(IConnectionStringSource connectionStringSource) : base(connectionStringSource)
        {
        }

        public Department Department { get; set; }

        public SqlDataQueryInfo<Department> QueryInfo
        {
            get
            {
                return SqlDataQueryInfo<Department>.CreateProcedureQueryInfo(Department, "HumanResource.UpdateDepartment", GetProcessResult, true)
                    .AddInputParameter("Id", Department.Id)
                    .AddInputParameter("Description", Department.Description)
                    .AddInputParameter("Abbreviation", Department.Abbreviation);
            }
        }

        private IDataProcessResult<Department> GetProcessResult(Department data, SqlCommand command, int affectedRows)
        {
            if (affectedRows == 1)
            {
                return new DataProcessResult<Department>(Department);
            }
            else
            {
                return new DataProcessResult<Department>(ProcessResultStatus.Failed);
            }
        }

        public IDataProcessResult<Department> Execute()
        {
            return SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IDataProcessResult<Department>> ExecuteAsync()
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IDataProcessResult<Department>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}

using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class UpdateDepartment : HumanResourceProcessBase, IUpdateDepartment
    {
        public UpdateDepartment(IConnectionStringSource connectionStringSource) : base(connectionStringSource)
        {
        }

        public Department Department { get; set; }

        public SqlQueryInfo<Department> QueryInfo =>
            SqlQueryInfo<Department>.CreateProcedureQueryInfo(Department, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", Department.Id)
            .AddInputParameter("@_Description", Department.Description)
            .AddInputParameter("@_Abbreviation", Department.Abbreviation)
            .AddLogByParameter();

        private IProcessResult<Department> GetProcessResult(Department data, SqlCommand command, int affectedRows)
        {
            if (affectedRows == 1)
            {
                return new ProcessResult<Department>(Department);
            }
            else
            {
                return new ProcessResult<Department>(ProcessResultStatus.Failed);
            }
        }

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

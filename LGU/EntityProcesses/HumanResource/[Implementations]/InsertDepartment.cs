using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class InsertDepartment : HumanResourceProcessBase, IInsertDepartment
    {
        public InsertDepartment(IConnectionStringSource connectionStringSource) : base(connectionStringSource)
        {
        }

        public Department Department { get; set; }

        private SqlQueryInfo<Department> QueryInfo =>
            SqlQueryInfo<Department>.CreateProcedureQueryInfo(Department, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddOutputParameter("@_Id", DbType.Int32)
            .AddInputParameter("@_Description", Department.Description)
            .AddInputParameter("@_Abbreviation", Department.Abbreviation)
            .AddLogByParameter();

        private IProcessResult<Department> GetProcessResult(Department data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                data.Id = command.Parameters.GetInt32("@_Id");
                return new ProcessResult<Department>(Department);
            }
            else
            {
                return new ProcessResult<Department>(ProcessResultStatus.Failed);
            }
        }

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

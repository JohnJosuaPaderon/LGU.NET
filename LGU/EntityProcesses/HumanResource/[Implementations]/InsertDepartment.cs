using LGU.Data.Extensions;
using LGU.Data.RDBMS;
using LGU.Entities.HumanResource;
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

        private SqlDataQueryInfo<Department> QueryInfo
        {
            get
            {
                return SqlDataQueryInfo<Department>.CreateProcedureQueryInfo(Department, "HumanResource.InsertDepartment", GetProcessResult, true)
                    .AddOutputParameter("@_Id", DbType.Int32)
                    .AddInputParameter("@_Description", Department.Description)
                    .AddInputParameter("@_Abbreviation", Department.Abbreviation)
                    .AddInputParameter("@_LogBy", SystemRuntime.LogByInfo);
            }
        }

        private IDataProcessResult<Department> GetProcessResult(Department data, SqlCommand command, int affectedRows)
        {
            if (affectedRows == 1)
            {
                data.Id = command.Parameters.GetUInt32("@_Id");
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

using LGU.Data.Extensions;
using LGU.Data.RDBMS;
using LGU.Entities.HumanResource;
using LGU.EntityProcessHelpers.HumanResource;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class GetDepartmentById : HumanResourceProcessBase, IGetDepartmentById
    {
        public GetDepartmentById(IConnectionStringSource connectionStringSource) : base(connectionStringSource)
        {
        }

        public int DepartmentId { get; set; }

        private SqlQueryInfo GetQueryInfo()
        {
            return SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName("GetDepartmentById"), GetProcessResult)
                .AddInputParameter("@_Id", DepartmentId);
        }

        private IProcessResult GetProcessResult(SqlCommand command, int affectedRows)
        {
            return new ProcessResult(ProcessResultStatus.Success);
        }

        public IDataProcessResult<Department> Execute()
        {
            return SqlHelper.ExecuteReader(GetQueryInfo(), DepartmentProcessHelper.FromReader);
        }

        public Task<IDataProcessResult<Department>> ExecuteAsync()
        {
            return SqlHelper.ExecuteReaderAsync(GetQueryInfo(), DepartmentProcessHelper.FromReaderAsync);
        }

        public Task<IDataProcessResult<Department>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteReaderAsync(GetQueryInfo(), DepartmentProcessHelper.FromReaderAsync, cancellationToken);
        }
    }
}

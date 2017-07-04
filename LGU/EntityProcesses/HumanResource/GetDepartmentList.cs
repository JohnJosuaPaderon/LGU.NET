using LGU.Data.RDBMS;
using LGU.Entities.HumanResource;
using LGU.EntityProcessHelpers.HumanResource;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class GetDepartmentList : ProcessBase, IGetDepartmentList
    {
        private SqlQueryInfo GetQueryInfo()
        {
            return SqlQueryInfo.CreateProcedureQueryInfo("GetDepartmentList", GetProcessResult);
        }

        private static IProcessResult GetProcessResult(SqlCommand command, int affectedRows)
        {
            return new ProcessResult(ProcessResultStatus.Success);
        }
        
        public GetDepartmentList(IConnectionStringSource connectionStringSource) : base(connectionStringSource)
        {
        }

        public IEnumerableDataProcessResult<Department> Execute()
        {
            return SqlHelper.ExecuteReaderEnumerable(GetQueryInfo(), DepartmentProcessHelper.EnumerableFromReader);
        }

        public Task<IEnumerableDataProcessResult<Department>> ExecuteAsync()
        {
            return SqlHelper.ExecuteReaderEnumerableAsync(GetQueryInfo(), DepartmentProcessHelper.EnumerableFromReaderAsync);
        }

        public Task<IEnumerableDataProcessResult<Department>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteReaderEnumerableAsync(GetQueryInfo(), DepartmentProcessHelper.EnumerableFromReaderAsync, cancellationToken);
        }
    }
}

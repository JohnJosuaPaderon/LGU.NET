using LGU.Data.RDBMS;
using LGU.Entities.HumanResource;
using LGU.EntityProcessHelpers.HumanResource;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class GetEmployeeList : HumanResourceProcessBase, IGetEmployeeList
    {
        public GetEmployeeList(IConnectionStringSource connectionStringSource) : base(connectionStringSource)
        {
        }

        private SqlQueryInfo QueryInfo
        {
            get
            {
                return SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName("GetEmployeeList"), GetProcessList);
            }
        }

        private IProcessResult GetProcessList(SqlCommand command, int affectedRows)
        {
            return new ProcessResult(ProcessResultStatus.Success);
        }

        public IEnumerableDataProcessResult<Employee> Execute()
        {
            return SqlHelper.ExecuteReaderEnumerable(QueryInfo, EmployeeProcessHelper.EnumerableFromReader);
        }

        public Task<IEnumerableDataProcessResult<Employee>> ExecuteAsync()
        {
            return SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, EmployeeProcessHelper.EnumerableFromReaderAsync);
        }

        public Task<IEnumerableDataProcessResult<Employee>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, EmployeeProcessHelper.EnumerableFromReaderAsync, cancellationToken);
        }
    }
}

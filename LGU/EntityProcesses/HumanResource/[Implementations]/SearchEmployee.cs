using LGU.Data.Extensions;
using LGU.Data.RDBMS;
using LGU.Entities.HumanResource;
using LGU.EntityProcessHelpers.HumanResource;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class SearchEmployee : HumanResourceProcessBase, ISearchEmployee
    {
        public SearchEmployee(IConnectionStringSource connectionStringSource) : base(connectionStringSource)
        {
        }

        public string SearchKey { get; set; }

        private SqlQueryInfo QueryInfo
        {
            get
            {
                return SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName("SearchEmployee"), GetProcessResult)
                    .AddInputParameter("@_SearchKey", SearchKey);
            }
        }

        private IProcessResult GetProcessResult(SqlCommand command, int affectedRows)
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

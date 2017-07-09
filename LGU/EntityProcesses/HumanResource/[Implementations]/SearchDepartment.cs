using LGU.Data.Extensions;
using LGU.Data.RDBMS;
using LGU.Entities.HumanResource;
using LGU.EntityProcessHelpers.HumanResource;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class SearchDepartment : HumanResourceProcessBase, ISearchDepartment
    {
        public SearchDepartment(IConnectionStringSource connectionStringSource) : base(connectionStringSource)
        {
        }

        public string SearchKey { get; set; }

        private SqlQueryInfo QueryInfo
        {
            get
            {
                return SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName("SearchDepartment"), GetProcessResult)
                    .AddInputParameter("@_SearchKey", SearchKey);
            }
        }

        private IProcessResult GetProcessResult(SqlCommand command, int affectedRows)
        {
            return new ProcessResult(ProcessResultStatus.Success);
        }

        public IEnumerableDataProcessResult<Department> Execute()
        {
            return SqlHelper.ExecuteReaderEnumerable(QueryInfo, DepartmentProcessHelper.EnumerableFromReader);
        }

        public Task<IEnumerableDataProcessResult<Department>> ExecuteAsync()
        {
            return SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, DepartmentProcessHelper.EnumerableFromReaderAsync);
        }

        public Task<IEnumerableDataProcessResult<Department>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, DepartmentProcessHelper.EnumerableFromReaderAsync, cancellationToken);
        }
    }
}

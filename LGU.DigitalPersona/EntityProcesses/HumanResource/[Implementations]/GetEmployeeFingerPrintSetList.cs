using LGU.Data.RDBMS;
using LGU.Entities.HumanResource;
using LGU.EntityProcessHelpers.HumanResource;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class GetEmployeeFingerPrintSetList : HumanResourceProcessBase, IGetEmployeeFingerPrintSetList
    {
        public GetEmployeeFingerPrintSetList(IConnectionStringSource connectionStringSource) : base(connectionStringSource)
        {
        }

        private SqlQueryInfo QueryInfo
        {
            get
            {
                return SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName("GetEmployeeFingerPrintSetList"), GetProcessResult);
            }
        }

        private IProcessResult GetProcessResult(SqlCommand command, int affectedRows)
        {
            return new ProcessResult(ProcessResultStatus.Success);
        }

        public IEnumerableProcessResult<EmployeeFingerPrintSet> Execute()
        {
            return SqlHelper.ExecuteReaderEnumerable(QueryInfo, EmployeeFingerPrintSetProcessHelper.EnumerableFromReader);
        }

        public Task<IEnumerableProcessResult<EmployeeFingerPrintSet>> ExecuteAsync()
        {
            return SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, EmployeeFingerPrintSetProcessHelper.EnumerableFromReaderAsync);
        }

        public Task<IEnumerableProcessResult<EmployeeFingerPrintSet>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, EmployeeFingerPrintSetProcessHelper.EnumerableFromReaderAsync, cancellationToken);
        }
    }
}

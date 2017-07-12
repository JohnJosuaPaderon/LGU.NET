using LGU.Data.RDBMS;
using LGU.Entities.Core;
using LGU.EntityProcessHelpers.Core;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.Core
{
    public sealed class GetGenderList : CoreProcessBase, IGetGenderList
    {
        public GetGenderList(IConnectionStringSource connectionStringSource) : base(connectionStringSource)
        {
        }

        private SqlQueryInfo QueryInfo
        {
            get
            {
                return SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName("GetGenderList"), GetProcessResult);
            }
        }

        private IProcessResult GetProcessResult(SqlCommand command, int affectedRows)
        {
            return new ProcessResult(ProcessResultStatus.Success);
        }

        public IEnumerableDataProcessResult<Gender> Execute()
        {
            return SqlHelper.ExecuteReaderEnumerable(QueryInfo, GenderProcessHelper.EnumerableFromReader);
        }

        public Task<IEnumerableDataProcessResult<Gender>> ExecuteAsync()
        {
            return SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, GenderProcessHelper.EnumerableFromReaderAsync);
        }

        public Task<IEnumerableDataProcessResult<Gender>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, GenderProcessHelper.EnumerableFromReaderAsync, cancellationToken);
        }
    }
}

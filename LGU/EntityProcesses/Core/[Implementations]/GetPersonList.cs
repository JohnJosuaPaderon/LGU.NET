using LGU.Data.RDBMS;
using LGU.Entities.Core;
using LGU.EntityProcessHelpers.Core;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.Core
{
    public sealed class GetPersonList : CoreProcessBase, IGetPersonList
    {
        public GetPersonList(IConnectionStringSource connectionStringSource) : base(connectionStringSource)
        {
        }

        private SqlQueryInfo QueryInfo
        {
            get
            {
                return SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName("GetPersonList"), GetProcessResult);
            }
        }

        private IProcessResult GetProcessResult(SqlCommand command, int affectedRows)
        {
            return new ProcessResult(ProcessResultStatus.Success);
        }

        public IEnumerableDataProcessResult<Person> Execute()
        {
            return SqlHelper.ExecuteReaderEnumerable(QueryInfo, PersonProcessHelper.EnumerableFromReader);
        }

        public Task<IEnumerableDataProcessResult<Person>> ExecuteAsync()
        {
            return SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, PersonProcessHelper.EnumerableFromReaderAsync);
        }

        public Task<IEnumerableDataProcessResult<Person>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, PersonProcessHelper.EnumerableFromReaderAsync, cancellationToken);
        }
    }
}

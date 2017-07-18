using LGU.Data.RDBMS;
using LGU.Entities.Core;
using LGU.EntityConverters.Core;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.Core
{
    public sealed class GetUserStatusList : UserStatusProcess, IGetUserStatusList
    {
        public GetUserStatusList(IConnectionStringSource connectionStringSource, IUserStatusConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName());

        public IEnumerableProcessResult<UserStatus> Execute()
        {
            return SqlHelper.ExecuteReaderEnumerable(QueryInfo, Converter.EnumerableFromReader);
        }

        public Task<IEnumerableProcessResult<UserStatus>> ExecuteAsync()
        {
            return SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, Converter.EnumerableFromReaderAsync);
        }

        public Task<IEnumerableProcessResult<UserStatus>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, Converter.EnumerableFromReaderAsync, cancellationToken);
        }
    }
}

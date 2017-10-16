using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class GetTimeLogList : TimeLogProcess, IGetTimeLogList
    {
        public GetTimeLogList(IConnectionStringSource connectionStringSource, ITimeLogConverter converter) : base(connectionStringSource, converter)
        {
        }

        private SqlQueryInfo QueryInfo => SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName());

        public IEnumerableProcessResult<ITimeLog> Execute()
        {
            return _SqlHelper.ExecuteReaderEnumerable(QueryInfo, r_Converter);
        }

        public Task<IEnumerableProcessResult<ITimeLog>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, r_Converter);
        }

        public Task<IEnumerableProcessResult<ITimeLog>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, r_Converter, cancellationToken);
        }
    }
}

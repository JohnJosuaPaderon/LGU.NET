using LGU.Data.Rdbms;
using LGU.Entities.Core;
using LGU.EntityConverters.Core;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.Core
{
    public sealed class GetModuleList : ModuleProcess, IGetModuleList
    {
        public GetModuleList(IConnectionStringSource connectionStringSource, IModuleConverter converter) : base(connectionStringSource, converter)
        {
        }

        private SqlQueryInfo QueryInfo => SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName());

        public IEnumerableProcessResult<IModule> Execute()
        {
            return _SqlHelper.ExecuteReaderEnumerable(QueryInfo, _Converter);
        }

        public Task<IEnumerableProcessResult<IModule>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, _Converter);
        }

        public Task<IEnumerableProcessResult<IModule>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, _Converter, cancellationToken);
        }
    }
}

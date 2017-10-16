using LGU.Data.Rdbms;
using LGU.Entities.Core;
using LGU.EntityConverters.Core;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.Core
{
    public sealed class GetGenderList : GenderProcess, IGetGenderList
    {
        public GetGenderList(IConnectionStringSource connectionStringSource, IGenderConverter converter) : base(connectionStringSource, converter)
        {
        }

        private SqlQueryInfo QueryInfo => SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName());

        public IEnumerableProcessResult<IGender> Execute()
        {
            return _SqlHelper.ExecuteReaderEnumerable(QueryInfo, _Converter);
        }

        public Task<IEnumerableProcessResult<IGender>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, _Converter);
        }

        public Task<IEnumerableProcessResult<IGender>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, _Converter, cancellationToken);
        }
    }
}

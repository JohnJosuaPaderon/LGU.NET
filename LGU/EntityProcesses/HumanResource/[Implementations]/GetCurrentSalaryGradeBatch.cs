using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class GetCurrentSalaryGradeBatch : SalaryGradeBatchProcess, IGetCurrentSalaryGradeBatch
    {
        public GetCurrentSalaryGradeBatch(IConnectionStringSource connectionStringSource, ISalaryGradeBatchConverter converter) : base(connectionStringSource, converter)
        {
        }

        private SqlQueryInfo QueryInfo => SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName());

        public IProcessResult<ISalaryGradeBatch> Execute()
        {
            return _SqlHelper.ExecuteReader(QueryInfo, _Converter);
        }

        public Task<IProcessResult<ISalaryGradeBatch>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter);
        }

        public Task<IProcessResult<ISalaryGradeBatch>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter, cancellationToken);
        }
    }
}

using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class GetPayrollContractualInclusion : HumanResourceProcessBaseV2, IGetPayrollContractualInclusion
    {
        public GetPayrollContractualInclusion(IConnectionStringSource connectionStringSource, IPayrollContractualInclusionParameters parameters, IPayrollContractualInclusionConverter converter) : base(connectionStringSource)
        {
            _Parameters = parameters;
            _Converter = converter;
        }

        private readonly IPayrollContractualInclusionParameters _Parameters;
        private readonly IPayrollContractualInclusionConverter _Converter;

        public IPayrollContractual Payroll { get; set; }

        private SqlQueryInfo QueryInfo => SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter(_Parameters.PayrollId, Payroll?.Id);

        public IProcessResult<IPayrollContractualInclusion> Execute()
        {
            return _SqlHelper.ExecuteReader(QueryInfo, _Converter);
        }

        public Task<IProcessResult<IPayrollContractualInclusion>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter);
        }

        public Task<IProcessResult<IPayrollContractualInclusion>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter, cancellationToken);
        }
    }
}

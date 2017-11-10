using LGU.Data.Extensions;
using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Extensions;
using LGU.Processes;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.HumanResource
{
    public sealed class PayrollContractualInclusionConverter : IPayrollContractualInclusionConverter
    {
        public PayrollContractualInclusionConverter(IPayrollContractualInclusionFields fields, IDbDataReaderToEnumerableProcessResultConverter toEnumerableProcessResultConverter, IDbDataReaderToProcessResultConverter toProcessResultConverter)
        {
            _Fields = fields;
            _ToEnumerableProcessResultConverter = toEnumerableProcessResultConverter;
            _ToProcessResultConverter = toProcessResultConverter;
        }

        private readonly IPayrollContractualInclusionFields _Fields;
        private readonly IDbDataReaderToEnumerableProcessResultConverter _ToEnumerableProcessResultConverter;
        private readonly IDbDataReaderToProcessResultConverter _ToProcessResultConverter;

        public IDataConverterProperty<IPayrollContractual> PPayroll { get; }
        public IDataConverterProperty<bool> PHdmfPremiumPs { get; }

        private IPayrollContractualManager PayrollContractualManager;

        private IPayrollContractualInclusion Construct(IPayrollContractual payrollContractual, DbDataReader reader)
        {
            return new PayrollContractualInclusion(payrollContractual)
            {
                HdmfPremiumPs = PHdmfPremiumPs.TryGetValue(reader.GetBoolean, _Fields.HdmfPremiumPs)
            };
        }

        private IPayrollContractualInclusion Get(DbDataReader reader)
        {
            var payrollContractual = PPayroll.TryGetValueFromProcess(PayrollContractualManager.GetById, reader.GetInt64, _Fields.PayrollId);

            return Construct(payrollContractual, reader);
        }

        private async Task<IPayrollContractualInclusion> GetAsync(DbDataReader reader)
        {
            var payrollContractual = await PPayroll.TryGetValueFromProcessAsync(PayrollContractualManager.GetByIdAsync, reader.GetInt64, _Fields.PayrollId);

            return Construct(payrollContractual, reader);
        }

        private async Task<IPayrollContractualInclusion> CancellableGetAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            var payrollContractual = await PPayroll.TryGetValueFromProcessAsync(PayrollContractualManager.GetByIdAsync, reader.GetInt64, _Fields.PayrollId, cancellationToken);

            return Construct(payrollContractual, reader);
        }

        public IEnumerableProcessResult<IPayrollContractualInclusion> EnumerableFromReader(DbDataReader reader)
        {
            return _ToEnumerableProcessResultConverter.EnumerableFromReader(reader, Get);
        }

        public Task<IEnumerableProcessResult<IPayrollContractualInclusion>> EnumerableFromReaderAsync(DbDataReader reader)
        {
            return _ToEnumerableProcessResultConverter.EnumerableFromReaderAsync(reader, GetAsync);
        }

        public Task<IEnumerableProcessResult<IPayrollContractualInclusion>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            return _ToEnumerableProcessResultConverter.EnumerableFromReaderAsync(reader, cancellationToken, CancellableGetAsync);
        }

        public IProcessResult<IPayrollContractualInclusion> FromReader(DbDataReader reader)
        {
            return _ToProcessResultConverter.FromReader(reader, Get);
        }

        public Task<IProcessResult<IPayrollContractualInclusion>> FromReaderAsync(DbDataReader reader)
        {
            return _ToProcessResultConverter.FromReaderAsync(reader, GetAsync);
        }

        public Task<IProcessResult<IPayrollContractualInclusion>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            return _ToProcessResultConverter.FromReaderAsync(reader, cancellationToken, CancellableGetAsync);
        }

        public void InitializeDependency()
        {
            PayrollContractualManager = ApplicationDomain.GetService<IPayrollContractualManager>();
        }
    }
}

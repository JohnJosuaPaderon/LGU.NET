using LGU.EntityConverters.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class SalaryGradeBatchProcess : HumanResourceProcessBase
    {
        protected readonly ISalaryGradeBatchConverter _Converter;

        public SalaryGradeBatchProcess(IConnectionStringSource connectionStringSource, ISalaryGradeBatchConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }
    }
}

using LGU.EntityConverters.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class SalaryGradeStepProcess : HumanResourceProcessBase
    {
        protected readonly ISalaryGradeStepConverter _Converter;

        public SalaryGradeStepProcess(IConnectionStringSource connectionStringSource, ISalaryGradeStepConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }
    }
}

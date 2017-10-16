using LGU.EntityConverters.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class SalaryGradeProcess : HumanResourceProcessBase
    {
        protected readonly ISalaryGradeConverter _Converter;

        public SalaryGradeProcess(IConnectionStringSource connectionStringSource, ISalaryGradeConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }
    }
}

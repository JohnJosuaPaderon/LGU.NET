using LGU.EntityConverters.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class EmployeeSalaryGradeStepProcess : HumanResourceProcessBase
    {
        public EmployeeSalaryGradeStepProcess(IConnectionStringSource connectionStringSource, IEmployeeSalaryGradeStepConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }

        protected readonly IEmployeeSalaryGradeStepConverter _Converter;
    }
}

using LGU.EntityConverters.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class EmployeeTypeProcess : HumanResourceProcessBase
    {
        protected readonly IEmployeeTypeConverter _Converter;

        public EmployeeTypeProcess(IConnectionStringSource connectionStringSource, IEmployeeTypeConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }
    }
}

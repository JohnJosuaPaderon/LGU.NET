using LGU.EntityConverters.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class EmployeeProcess : HumanResourceProcessBase
    {
        protected readonly IEmployeeConverter _Converter;

        public EmployeeProcess(IConnectionStringSource connectionStringSource, IEmployeeConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }
    }
}

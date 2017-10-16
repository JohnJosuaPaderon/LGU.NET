using LGU.EntityConverters.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class EmploymentStatusProcess : HumanResourceProcessBase
    {
        protected readonly IEmploymentStatusConverter _Converter;

        public EmploymentStatusProcess(IConnectionStringSource connectionStringSource, IEmploymentStatusConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }
    }
}

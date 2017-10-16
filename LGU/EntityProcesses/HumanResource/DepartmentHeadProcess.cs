using LGU.EntityConverters.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class DepartmentHeadProcess : HumanResourceProcessBase
    {
        protected readonly IDepartmentHeadConverter _Converter;

        public DepartmentHeadProcess(IConnectionStringSource connectionStringSource, IDepartmentHeadConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }
    }
}

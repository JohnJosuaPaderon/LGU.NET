using LGU.EntityConverters.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class DepartmentProcess : HumanResourceProcessBase
    {
        protected readonly IDepartmentConverter _Converter;

        public DepartmentProcess(IConnectionStringSource connectionStringSource, IDepartmentConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }
    }
}

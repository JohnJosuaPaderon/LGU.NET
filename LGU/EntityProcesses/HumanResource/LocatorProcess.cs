using LGU.EntityConverters.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class LocatorProcess : HumanResourceProcessBase
    {
        protected readonly ILocatorConverter _Converter;

        public LocatorProcess(IConnectionStringSource connectionStringSource, ILocatorConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }
    }
}

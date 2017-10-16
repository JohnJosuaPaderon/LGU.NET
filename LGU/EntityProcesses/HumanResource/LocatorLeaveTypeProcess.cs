using LGU.EntityConverters.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class LocatorLeaveTypeProcess : HumanResourceProcessBase
    {
        protected readonly ILocatorLeaveTypeConverter _Converter;

        public LocatorLeaveTypeProcess(IConnectionStringSource connectionStringSource, ILocatorLeaveTypeConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }
    }
}

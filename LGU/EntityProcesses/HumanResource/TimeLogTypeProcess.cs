using LGU.EntityConverters.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class TimeLogTypeProcess : HumanResourceProcessBase
    {
        protected readonly ITimeLogTypeConverter _Converter;

        public TimeLogTypeProcess(IConnectionStringSource connectionStringSource, ITimeLogTypeConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }
    }
}

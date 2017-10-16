using LGU.EntityConverters.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class TimeLogProcess : HumanResourceProcessBase
    {
        protected readonly ITimeLogConverter r_Converter;

        public TimeLogProcess(IConnectionStringSource connectionStringSource, ITimeLogConverter converter) : base(connectionStringSource)
        {
            r_Converter = converter;
        }
    }
}

using LGU.EntityConverters.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class WorkTimeScheduleProcess : HumanResourceProcessBase
    {
        public WorkTimeScheduleProcess(IConnectionStringSource connectionStringSource, IWorkTimeScheduleConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }

        protected readonly IWorkTimeScheduleConverter _Converter;
    }
}

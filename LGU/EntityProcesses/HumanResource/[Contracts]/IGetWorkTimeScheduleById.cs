using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetWorkTimeScheduleById : IProcess<IWorkTimeSchedule>
    {
        int WorkTimeScheduleId { get; set; }
    }
}

using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IUpdateWorkTimeSchedule : IProcess<IWorkTimeSchedule>
    {
        IWorkTimeSchedule WorkTimeSchedule { get; set; }
    }
}

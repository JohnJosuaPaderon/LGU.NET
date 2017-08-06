using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetEmployeeWorkTimeScheduleById : IProcess<EmployeeWorkTimeSchedule>
    {
        long WorkTimeScheduleId { get; set; }
    }
}

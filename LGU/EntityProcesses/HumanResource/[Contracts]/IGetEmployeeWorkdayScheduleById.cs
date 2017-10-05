using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetEmployeeWorkdayScheduleById : IProcess<IEmployeeWorkdaySchedule>
    {
        long EmployeeWorkdayScheduleId { get; set; }
    }
}

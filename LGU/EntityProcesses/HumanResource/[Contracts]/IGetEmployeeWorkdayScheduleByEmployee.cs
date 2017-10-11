using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetEmployeeWorkdayScheduleByEmployee : IProcess<IEmployeeWorkdaySchedule>
    {
        IEmployee Employee { get; set; }
    }
}

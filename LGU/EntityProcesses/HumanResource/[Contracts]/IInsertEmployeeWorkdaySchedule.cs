using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertEmployeeWorkdaySchedule : IProcess<IEmployeeWorkdaySchedule>
    {
        IEmployeeWorkdaySchedule EmployeeWorkdaySchedule { get; set; }
    }
}

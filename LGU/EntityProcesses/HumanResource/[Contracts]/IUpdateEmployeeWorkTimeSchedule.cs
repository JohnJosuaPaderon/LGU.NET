using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IUpdateEmployeeWorkTimeSchedule : IProcess<EmployeeWorkTimeSchedule>
    {
        EmployeeWorkTimeSchedule WorkTimeSchedule { get; set; }
    }
}

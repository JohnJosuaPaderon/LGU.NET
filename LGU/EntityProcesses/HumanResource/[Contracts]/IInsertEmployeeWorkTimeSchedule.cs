using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertEmployeeWorkTimeSchedule : IProcess<EmployeeWorkTimeSchedule>
    {
        EmployeeWorkTimeSchedule WorkTimeSchedule { get; set; }
    }
}

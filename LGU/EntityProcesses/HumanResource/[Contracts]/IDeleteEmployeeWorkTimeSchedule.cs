using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IDeleteEmployeeWorkTimeSchedule : IProcess<EmployeeWorkTimeSchedule>
    {
        EmployeeWorkTimeSchedule WorkTimeSchedule { get; set; }
    }
}

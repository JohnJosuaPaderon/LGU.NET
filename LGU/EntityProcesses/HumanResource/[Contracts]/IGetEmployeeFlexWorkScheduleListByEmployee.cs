using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetEmployeeFlexWorkScheduleListByEmployee : IEnumerableProcess<IEmployeeFlexWorkSchedule>
    {
        IEmployee Employee { get; set; }
    }
}

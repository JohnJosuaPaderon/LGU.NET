using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetEmployeeFlexWorkScheduleById : IProcess<IEmployeeFlexWorkSchedule>
    {
        long EmployeeFlexWorkScheduleId { get; set; }
    }
}

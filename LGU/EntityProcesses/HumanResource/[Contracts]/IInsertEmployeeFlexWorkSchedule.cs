using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertEmployeeFlexWorkSchedule : IProcess<IEmployeeFlexWorkSchedule>
    {
        IEmployeeFlexWorkSchedule EmployeeFlexWorkSchedule { get; set; }
    }
}

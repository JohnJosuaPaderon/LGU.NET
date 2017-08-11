using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetLocatorLeaveTypeById : IProcess<LocatorLeaveType>
    {
        short LocatorLeaveTypeId { get; set; }
    }
}

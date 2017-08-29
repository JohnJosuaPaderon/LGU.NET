using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetLocatorLeaveTypeById : IProcess<ILocatorLeaveType>
    {
        short LocatorLeaveTypeId { get; set; }
    }
}

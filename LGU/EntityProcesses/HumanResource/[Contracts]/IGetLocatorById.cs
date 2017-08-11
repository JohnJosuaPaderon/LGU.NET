using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetLocatorById : IProcess<Locator>
    {
        long LocatorId { get; set; }
    }
}

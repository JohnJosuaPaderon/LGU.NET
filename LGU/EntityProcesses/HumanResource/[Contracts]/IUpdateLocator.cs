using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IUpdateLocator : IProcess<Locator>
    {
        Locator Locator { get; set; }
    }
}

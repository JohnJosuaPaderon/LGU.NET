using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IUpdateLocator : IProcess<ILocator>
    {
        ILocator Locator { get; set; }
    }
}

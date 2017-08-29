using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertLocator : IProcess<ILocator>
    {
        ILocator Locator { get; set; }
    }
}

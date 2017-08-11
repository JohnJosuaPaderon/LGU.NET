using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IDeleteLocator : IProcess<Locator>
    {
        Locator Locator { get; set; }
    }
}

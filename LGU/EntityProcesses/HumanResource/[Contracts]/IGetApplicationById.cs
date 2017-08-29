using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetApplicationById : IProcess<IApplication>
    {
        long ApplicationId { get; set; }
    }
}

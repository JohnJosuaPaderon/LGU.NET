using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetApplicationById : IProcess<Application>
    {
        long ApplicationId { get; set; }
    }
}

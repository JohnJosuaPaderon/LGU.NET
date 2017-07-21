using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetApplicationStatusById : IProcess<ApplicationStatus>
    {
        short ApplicationStatusId { get; set; }
    }
}

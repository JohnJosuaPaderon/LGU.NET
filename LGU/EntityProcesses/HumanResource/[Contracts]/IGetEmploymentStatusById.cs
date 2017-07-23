using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetEmploymentStatusById : IProcess<EmploymentStatus>
    {
        short EmploymentStatusId { get; set; }
    }
}

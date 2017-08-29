using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetApplicantById : IProcess<IApplicant>
    {
        long ApplicantId { get; set; }
    }
}

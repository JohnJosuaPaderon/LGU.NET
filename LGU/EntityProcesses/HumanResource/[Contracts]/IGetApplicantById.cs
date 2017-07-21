using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetApplicantById : IProcess<Applicant>
    {
        long ApplicantId { get; set; }
    }
}

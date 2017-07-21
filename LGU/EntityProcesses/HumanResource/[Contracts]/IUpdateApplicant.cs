using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IUpdateApplicant : IProcess<Applicant>
    {
        Applicant Applicant { get; set; }
    }
}

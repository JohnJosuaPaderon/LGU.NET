using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertApplicant : IProcess<Applicant>
    {
        Applicant Applicant { get; set; }
    }
}

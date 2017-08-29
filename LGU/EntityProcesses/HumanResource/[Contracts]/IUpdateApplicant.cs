using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IUpdateApplicant : IProcess<IApplicant>
    {
        IApplicant Applicant { get; set; }
    }
}

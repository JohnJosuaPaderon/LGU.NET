using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IDeleteApplicant : IProcess<Applicant>
    {
        Applicant Applicant { get; set; }
    }
}

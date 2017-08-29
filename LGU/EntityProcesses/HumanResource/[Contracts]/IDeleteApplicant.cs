using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IDeleteApplicant : IProcess<IApplicant>
    {
        IApplicant Applicant { get; set; }
    }
}

using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetApplicantStatusById : IProcess<IApplicantStatus>
    {
        short ApplicantStatusId { get; set; }
    }
}

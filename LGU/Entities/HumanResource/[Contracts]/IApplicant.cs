using LGU.Entities.Core;

namespace LGU.Entities.HumanResource
{
    public interface IApplicant : IPerson
    {
        IApplicantStatus Status { get; set; }
        string ContactNumber { get; set; }
    }
}

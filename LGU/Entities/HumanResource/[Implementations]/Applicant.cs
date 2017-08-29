using LGU.Entities.Core;

namespace LGU.Entities.HumanResource
{
    public class Applicant : Person, IApplicant
    {
        public IApplicantStatus Status { get; set; }
        public string ContactNumber { get; set; }
    }
}

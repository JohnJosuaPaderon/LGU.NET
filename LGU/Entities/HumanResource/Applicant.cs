using LGU.Entities.Core;

namespace LGU.Entities.HumanResource
{
    public class Applicant : Person
    {
        public ApplicantStatus Status { get; set; }
        public string ContactNumber { get; set; }
    }
}

using System;

namespace LGU.Entities.HumanResource
{
    public class Application : Entity<long>, IApplication
    {
        public Application(IApplicant applicant)
        {
            Applicant = applicant ?? throw new ArgumentNullException(nameof(applicant));
        }

        public IApplicant Applicant { get; }
        public IApplicationStatus Status { get; set; }
        public DateTime Date { get; set; }
        public IPosition ApplyingPosition { get; set; }

        public override string ToString()
        {
            return $"{ Applicant?.ToString() ?? "[APPLICANT UNAVAILABLE]" } : {Status?.ToString() ?? "[APPLICATION STATUS UNAVAILABLE]"}";
        }
    }
}

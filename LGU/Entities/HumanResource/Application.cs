using System;

namespace LGU.Entities.HumanResource
{
    public class Application : Entity<long>
    {
        public Application(Applicant applicant)
        {
            Applicant = applicant ?? throw new ArgumentNullException(nameof(applicant));
        }

        public Applicant Applicant { get; }
        public ApplicationStatus Status { get; set; }
        public DateTime Date { get; set; }
        public Position ApplyingPosition { get; set; }

        public override string ToString()
        {
            return $"{ Applicant?.ToString() ?? "[APPLICANT UNAVAILABLE]" } : {Status?.ToString() ?? "[APPLICATION STATUS UNAVAILABLE]"}";
        }
    }
}

namespace LGU.Entities.HumanResource
{
    public class ApplicantStatus : Entity<short>, IApplicantStatus
    {
        public static ApplicantStatus Applied { get; }
        public static ApplicantStatus Rejected { get; }

        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}

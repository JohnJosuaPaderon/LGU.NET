namespace LGU.Entities.HumanResource
{
    public class ApplicantStatus : Entity<short>
    {
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}

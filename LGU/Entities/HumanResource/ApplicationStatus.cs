namespace LGU.Entities.HumanResource
{
    public class ApplicationStatus : Entity<short>
    {
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}

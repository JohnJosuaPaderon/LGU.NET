namespace LGU.Entities.HumanResource
{
    public class ApplicationStatus : Entity<short>, IApplicationStatus
    {
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}

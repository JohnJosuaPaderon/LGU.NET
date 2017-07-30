namespace LGU.Entities.HumanResource
{
    public class EmploymentStatus : Entity<short>
    {
        public static EmploymentStatus Active { get; }
        public static EmploymentStatus Retired { get; }
        public static EmploymentStatus Resigned { get; }

        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}

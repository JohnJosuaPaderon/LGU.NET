namespace LGU.Entities.HumanResource
{
    public class EmployeeType : Entity<short>, IEmployeeType
    {
        public static EmployeeType Regular { get; }
        public static EmployeeType Contractual { get; }
        public static EmployeeType Casual { get; }

        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}

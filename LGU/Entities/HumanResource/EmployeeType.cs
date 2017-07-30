namespace LGU.Entities.HumanResource
{
    public class EmployeeType : Entity<short>
    {
        public static EmployeeType Regular { get; }
        public static EmployeeType Contractual { get; }

        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}

namespace LGU.Entities.HumanResource
{
    public class EmployeeType : Entity<short>
    {
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}

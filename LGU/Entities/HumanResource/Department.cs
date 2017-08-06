namespace LGU.Entities.HumanResource
{
    public class Department : Entity<int>
    {
        public string Description { get; set; }
        public string Abbreviation { get; set; }
        public DepartmentHead Head { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}

namespace LGU.Entities.HumanResource
{
    public class PayrollGroup : Entity<int>
    {
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}

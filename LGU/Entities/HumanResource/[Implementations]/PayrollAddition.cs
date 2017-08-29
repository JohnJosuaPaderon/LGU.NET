namespace LGU.Entities.HumanResource
{
    public class PayrollAddition : Entity<int>, IPayrollAddition
    {
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}

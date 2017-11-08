namespace LGU.Entities.HumanResource
{
    public class PayrollType : Entity<short>, IPayrollType
    {
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}

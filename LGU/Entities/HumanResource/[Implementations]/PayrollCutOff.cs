namespace LGU.Entities.HumanResource
{
    public class PayrollCutOff : Entity<short>, IPayrollCutOff
    {
        public int Count { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}

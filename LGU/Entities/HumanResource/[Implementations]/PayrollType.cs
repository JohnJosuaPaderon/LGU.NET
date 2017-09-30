namespace LGU.Entities.HumanResource
{
    public class PayrollType : Entity<short>, IPayrollType
    {
        public static PayrollType Regular { get; }
        public static PayrollType Contractual { get; }
        public static PayrollType ContractualPerVisit { get; }
        public static PayrollType Casual { get; }

        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}

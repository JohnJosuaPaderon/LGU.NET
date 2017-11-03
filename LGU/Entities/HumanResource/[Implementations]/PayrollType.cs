namespace LGU.Entities.HumanResource
{
    public class PayrollType : Entity<short>, IPayrollType
    {
        static PayrollType()
        {
            var initializer = ApplicationDomain.GetService<IPayrollTypeInitializer>();

            Regular = initializer.Regular;
            Contractual = initializer.Contractual;
        }

        public static IPayrollType Regular { get; }
        public static IPayrollType Contractual { get; }

        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}

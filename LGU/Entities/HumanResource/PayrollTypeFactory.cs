using LGU.EntityManagers.HumanResource;

namespace LGU.Entities.HumanResource
{
    public static class PayrollTypeFactory
    {
        static PayrollTypeFactory()
        {
            var manager = ApplicationDomain.GetService<IPayrollTypeManager>();

            var regularResult = manager.GetById(1);
            var contractualResult = manager.GetById(2);

            Regular = regularResult.Data;
            Contractual = contractualResult.Data;
        }

        public static IPayrollType Regular { get; }
        public static IPayrollType Contractual { get; }
    }
}

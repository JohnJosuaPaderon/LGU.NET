using LGU.EntityManagers.HumanResource;

namespace LGU.Entities.HumanResource
{
    public sealed class PayrollTypeInitializer : IPayrollTypeInitializer
    {
        public PayrollTypeInitializer(IPayrollTypeManager manager)
        {
            var regularResult = manager.GetById(1);
            var contractualResult = manager.GetById(2);

            Regular = regularResult.Data;
            Contractual = contractualResult.Data;
        }

        public IPayrollType Regular { get; }
        public IPayrollType Contractual { get; }
    }
}

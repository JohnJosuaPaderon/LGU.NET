using System;

namespace LGU.Entities.HumanResource
{
    public sealed class PayrollContractualInclusion : IPayrollContractualInclusion
    {
        public PayrollContractualInclusion(IPayrollContractual payroll)
        {
            Payroll = payroll ?? throw new ArgumentNullException(nameof(payroll));

            HdmfPremiumPs = true;
        }

        public IPayrollContractual Payroll { get; }
        public bool HdmfPremiumPs { get; set; }
    }
}

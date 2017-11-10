namespace LGU.Entities.HumanResource
{
    public sealed class PayrollContractualInclusionParameters : IPayrollContractualInclusionParameters
    {
        public PayrollContractualInclusionParameters()
        {
            PayrollId = "@_PayrollId";
            HdmfPremiumPs = "@_HdmfPremiumPs";
        }

        public string PayrollId { get; }
        public string HdmfPremiumPs { get; }
    }
}

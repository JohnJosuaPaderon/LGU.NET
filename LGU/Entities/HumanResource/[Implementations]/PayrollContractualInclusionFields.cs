namespace LGU.Entities.HumanResource
{
    public class PayrollContractualInclusionFields : IPayrollContractualInclusionFields
    {
        public PayrollContractualInclusionFields()
        {
            PayrollId = "PayrollId";
            HdmfPremiumPs = "HdmfPremiumPs";
        }

        public string PayrollId { get; }
        public string HdmfPremiumPs { get; }
    }
}

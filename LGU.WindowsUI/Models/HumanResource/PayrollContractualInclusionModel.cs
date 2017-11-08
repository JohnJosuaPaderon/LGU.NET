using LGU.Entities.HumanResource;

namespace LGU.Models.HumanResource
{
    public sealed class PayrollContractualInclusionModel : ModelBase<IPayrollContractualInclusion>
    {
        public static PayrollContractualInclusionModel TryInstantiate(IPayrollContractualInclusion payrollContractualInclusion)
        {
            return payrollContractualInclusion != null ? new PayrollContractualInclusionModel(payrollContractualInclusion) : null;
        }

        public PayrollContractualInclusionModel(IPayrollContractualInclusion source) : base(source)
        {
            HdmfPremiumPs = source.HdmfPremiumPs;
        }

        private bool _HdmfPremiumPs;
        public bool HdmfPremiumPs
        {
            get { return _HdmfPremiumPs; }
            set { SetProperty(ref _HdmfPremiumPs, value); }
        }

        public override IPayrollContractualInclusion GetSource()
        {
            Source.HdmfPremiumPs = HdmfPremiumPs;

            return Source;
        }
    }
}

using LGU.Entities.HumanResource;

namespace LGU.Models.HumanResource
{
    public sealed class ContractualPayrollClusterInclusionModel : ModelBase<IContractualPayrollClusterInclusion>
    {
        public ContractualPayrollClusterInclusionModel(IContractualPayrollClusterInclusion source) : base(source ?? new ContractualPayrollClusterInclusion())
        {
            HdmfPremiumPs = source?.HdmfPremiumPs ?? default(bool);
        }

        private bool _HdmfPremiumPs;
        public bool HdmfPremiumPs
        {
            get { return _HdmfPremiumPs; }
            set { SetProperty(ref _HdmfPremiumPs, value); }
        }

        public override IContractualPayrollClusterInclusion GetSource()
        {
            Source.HdmfPremiumPs = HdmfPremiumPs;
            return Source;
        }
    }
}

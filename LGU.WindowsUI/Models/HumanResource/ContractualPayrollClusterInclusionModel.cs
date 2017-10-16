using LGU.Entities.HumanResource;

namespace LGU.Models.HumanResource
{
    public sealed class ContractualPayrollClusterInclusionModel : ModelBase<IContractualPayrollClusterInclusion>
    {
        public ContractualPayrollClusterInclusionModel(IContractualPayrollClusterInclusion source) : base(source)
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
            if (Source != null)
            {
                Source.HdmfPremiumPs = HdmfPremiumPs;
            }

            return Source;
        }

        public static bool operator ==(ContractualPayrollClusterInclusionModel left, ContractualPayrollClusterInclusionModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ContractualPayrollClusterInclusionModel left, ContractualPayrollClusterInclusionModel right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            var value = obj as ContractualPayrollClusterInclusionModel;
            return HdmfPremiumPs.Equals(value.HdmfPremiumPs);
        }

        public override int GetHashCode()
        {
            return HdmfPremiumPs.GetHashCode();
        }
    }
}

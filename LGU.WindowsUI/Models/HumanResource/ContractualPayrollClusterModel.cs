using LGU.Entities.HumanResource;
using System.Collections.ObjectModel;
using System.Linq;

namespace LGU.Models.HumanResource
{
    public sealed class ContractualPayrollClusterModel : ModelBase<IContractualPayrollCluster>
    {
        public ContractualPayrollClusterModel(IContractualPayrollCluster source) : base(source)
        {
            Departments = new ObservableCollection<PayrollContractualDepartmentModel>();

            Payroll = source?.Payroll != null ? new PayrollModel(source.Payroll) : null;
            Inclusion = source?.Inclusion != null ? new ContractualPayrollClusterInclusionModel(source.Inclusion) : null;

            TryInitializeDepartments();
        }

        public ObservableCollection<PayrollContractualDepartmentModel> Departments { get; }

        private PayrollModel _Payroll;
        public PayrollModel Payroll
        {
            get { return _Payroll; }
            set { SetProperty(ref _Payroll, value); }
        }

        private ContractualPayrollClusterInclusionModel _Inclusion;
        public ContractualPayrollClusterInclusionModel Inclusion
        {
            get { return _Inclusion; }
            set { SetProperty(ref _Inclusion, value); }
        }

        private void TryInitializeDepartments()
        {
            if (Source?.Departments?.Any() ?? false)
            {
                foreach (var department in Source.Departments)
                {
                    Departments.Add(new PayrollContractualDepartmentModel(department));
                }
            }
        }

        public override IContractualPayrollCluster GetSource()
        {
            if (Source != null)
            {
                Source.Payroll = Payroll.GetSource();
                Source.Inclusion = Inclusion.GetSource();
            }

            return Source;
        }

        public static bool operator ==(ContractualPayrollClusterModel left, ContractualPayrollClusterModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ContractualPayrollClusterModel left, ContractualPayrollClusterModel right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            var value = obj as ContractualPayrollClusterModel;
            return Payroll.Equals(value.Payroll);
        }

        public override int GetHashCode()
        {
            return Payroll.GetHashCode();
        }
    }
}

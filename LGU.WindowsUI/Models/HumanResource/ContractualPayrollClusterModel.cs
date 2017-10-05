using LGU.Extensions;
using LGU.Entities.HumanResource;
using System.Collections.ObjectModel;
using System.Linq;

namespace LGU.Models.HumanResource
{
    public sealed class ContractualPayrollClusterModel : ModelBase<IContractualPayrollCluster>
    {
        public ContractualPayrollClusterModel(IContractualPayrollCluster source) : base(source ?? new ContractualPayrollCluster())
        {
            Payroll = new PayrollModel(source?.Payroll);
            Inclusion = new ContractualPayrollClusterInclusionModel(source?.Inclusion);
            Employees = new ObservableCollection<PayrollContractualEmployeeModel>();

            if (source?.Employees != null && source.Employees.Any())
            {
                foreach (var item in source.Employees)
                {
                    Employees.Add(new PayrollContractualEmployeeModel(item));
                }
            }
        }

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

        public ObservableCollection<PayrollContractualEmployeeModel> Employees { get; }

        public override IContractualPayrollCluster GetSource()
        {
            Source.Payroll = Payroll.GetSource();
            Source.Inclusion = Inclusion.GetSource();
            Source.Employees = Employees.GetSource<IPayrollContractualEmployee, PayrollContractualEmployeeModel>();

            return Source;
        }
    }
}

using LGU.Entities.HumanResource;
using System.Collections.ObjectModel;

namespace LGU.Models.HumanResource
{
    public sealed class PayrollContractualModel : PayrollModelBase<IPayrollContractual>
    {
        public static PayrollContractualModel TryCreate(IPayrollContractual payrollContractual)
        {
            return payrollContractual != null ? new PayrollContractualModel(payrollContractual) : null;
        }

        public PayrollContractualModel(IPayrollContractual source) : base(source)
        {
            Departments = new ObservableCollection<PayrollContractualDepartmentModel>();
            Inclusion = PayrollContractualInclusionModel.TryInstantiate(source.Inclusion);
        }

        public PayrollContractualInclusionModel Inclusion { get; }
        public ObservableCollection<PayrollContractualDepartmentModel> Departments { get; }

        public override IPayrollContractual GetSource()
        {
            Source.Inclusion.HdmfPremiumPs = Inclusion.HdmfPremiumPs;

            foreach (var department in Departments)
            {
                Source.Departments.AddUpdate(department.GetSource());
            }

            return base.GetSource();
        }
    }
}

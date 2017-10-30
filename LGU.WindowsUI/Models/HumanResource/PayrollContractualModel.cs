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
        }

        ObservableCollection<PayrollContractualDepartmentModel> Departments { get; }

        public override IPayrollContractual GetSource()
        {
            foreach (var department in Departments)
            {
                Source.Departments.AddUpdate(department.GetSource());
            }

            return base.GetSource();
        }
    }
}

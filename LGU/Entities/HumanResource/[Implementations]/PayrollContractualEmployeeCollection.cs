using System;

namespace LGU.Entities.HumanResource
{
    public sealed class PayrollContractualEmployeeCollection : EntityCollection<IPayrollContractualEmployee>, IPayrollContractualEmployeeCollection
    {
        public PayrollContractualEmployeeCollection(IPayrollContractualDepartment department)
        {
            Department = department ?? throw new ArgumentNullException(nameof(department));
        }

        public IPayrollContractualDepartment Department { get; }

        protected override void UnsafeAdd(IPayrollContractualEmployee item)
        {
            if (item.Department != Department)
            {
                item.Department = Department;
            }

            base.UnsafeAdd(item);
        }

        protected override bool UnsafeRemove(IPayrollContractualEmployee item)
        {
            item.Department = null;

            return base.UnsafeRemove(item);
        }

        protected override void UnsafeUpdate(IPayrollContractualEmployee item)
        {
            if (item.Department != Department)
            {
                item.Department = Department;
            }

            base.UnsafeUpdate(item);
        }
    }
}

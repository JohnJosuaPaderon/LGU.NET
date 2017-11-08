using System;
using System.Collections.Generic;

namespace LGU.Entities.HumanResource
{
    public sealed class PayrollContractualDepartmentCollection : EntityCollection<IPayrollContractualDepartment>, IPayrollContractualDepartmentCollection
    {
        public PayrollContractualDepartmentCollection(IPayrollContractual payroll)
        {
            Payroll = payroll ?? throw new ArgumentNullException(nameof(payroll));
        }

        public IPayrollContractual Payroll { get; }

        protected override void UnsafeAdd(IPayrollContractualDepartment item)
        {
            if (item.Payroll != Payroll)
            {
                item.Payroll = Payroll;
            }

            base.UnsafeAdd(item);
        }

        protected override void UnsafeAdd(IEnumerable<IPayrollContractualDepartment> items)
        {
            foreach (var item in items)
            {
                if (item.Payroll != Payroll)
                {
                    item.Payroll = Payroll;
                }
            }

            base.UnsafeAdd(items);
        }

        protected override bool UnsafeRemove(IPayrollContractualDepartment item)
        {
            item.Payroll = null;
            return base.UnsafeRemove(item);
        }

        protected override void UnsafeUpdate(IPayrollContractualDepartment item)
        {
            if (item.Payroll != null)
            {
                item.Payroll = Payroll;
            }

            base.UnsafeUpdate(item);
        }
    }
}

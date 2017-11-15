using System;
using System.Collections.Generic;

namespace LGU.Entities.HumanResource
{
    public sealed class PayrollContractualEmployeeCollection : EntityCollection<IPayrollContractualEmployee>, IPayrollContractualEmployeeCollection
    {
        public PayrollContractualEmployeeCollection(IPayrollContractualDepartment department)
        {
            Department = department ?? throw new ArgumentNullException(nameof(department));
        }

        public IPayrollContractualDepartment Department { get; }

        public decimal TotalHdmfPremiumPs
        {
            get
            {
                var total = 0M;

                foreach (var employee in _Source)
                {
                    total += employee.HdmfPremiumPs ?? 0;
                }

                return total;
            }
        }

        public decimal TotalMonthlyRate
        {
            get
            {
                var total = 0M;

                foreach (var employee in _Source)
                {
                    total += employee.MonthlyRate;
                }

                return total;
            }
        }

        public decimal TotalWithholdingTax
        {
            get
            {
                var total = 0M;

                foreach (var employee in _Source)
                {
                    total += employee.WithholdingTax ?? 0;
                }

                return total;
            }
        }

        public decimal TotalAmountAccrued
        {
            get
            {
                var total = 0M;

                foreach (var employee in _Source)
                {
                    total += employee.AmountAccrued;
                }

                return total;
            }
        }

        public decimal TotalAmountPaid
        {
            get
            {
                var total = 0M;

                foreach (var employee in _Source)
                {
                    total += employee.AmountPaid;
                }

                return total;
            }
        }

        protected override void UnsafeAdd(IPayrollContractualEmployee item)
        {
            if (item.Department != Department)
            {
                item.Department = Department;
            }

            base.UnsafeAdd(item);
        }

        protected override void UnsafeAdd(IEnumerable<IPayrollContractualEmployee> items)
        {
            foreach (var item in items)
            {
                if (item.Department != Department)
                {
                    item.Department = Department;
                }
            }

            base.UnsafeAdd(items);
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

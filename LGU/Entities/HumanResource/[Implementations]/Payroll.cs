using LGU.Extensions;
using System;

namespace LGU.Entities.HumanResource
{
    public class Payroll<TDepartment> : Entity<long>, IPayroll<TDepartment>
        where TDepartment : IPayrollDepartment
    {
        public Payroll(IPayrollType type, IEntityCollection<TDepartment> departments)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
            Departments = departments ?? throw new ArgumentNullException(nameof(departments));
        }

        public IPayrollType Type { get; }
        public IPayrollCutOff CutOff { get; set; }
        public ValueRange<DateTime> RangeDate { get; set; }
        public DateTime RunDate { get; set; }
        public IEmployee HumanResourceHead { get; set; }
        public IEmployee Mayor { get; set; }
        public IEmployee Treasurer { get; set; }
        public IEmployee CityAccountant { get; set; }
        public IEmployee CityBudgetOfficer { get; set; }
        public IEntityCollection<TDepartment> Departments { get; }

        public override string ToString()
        {
            return $"{RangeDate.ToFormattedString()} ({Type})";
        }
    }
}

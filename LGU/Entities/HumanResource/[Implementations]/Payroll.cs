using LGU.Extensions;
using System;

namespace LGU.Entities.HumanResource
{
    public class Payroll : Entity<long>, IPayroll
    {
        public Payroll(IPayrollType type)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
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

        public override string ToString()
        {
            return $"{RangeDate.ToFormattedString()} ({Type})";
        }
    }
}

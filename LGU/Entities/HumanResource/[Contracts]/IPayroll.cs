using System;

namespace LGU.Entities.HumanResource
{
    public interface IPayroll : IEntity<long>
    {
        IPayrollType Type { get; }
        IPayrollCutOff CutOff { get; set; }
        ValueRange<DateTime> RangeDate { get; set; }
        DateTime RunDate { get; set; }
        IEmployee HumanResourceHead { get; set; }
        IEmployee Mayor { get; set; }
        IEmployee Treasurer { get; set; }
        IEmployee CityAccountant { get; set; }
        IEmployee CityBudgetOfficer { get; set; }
    }
}

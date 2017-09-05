using System;

namespace LGU.Entities.HumanResource
{
    public interface IEmployeeSalaryGradeStep
    {
        IEmployee Employee { get; set; }
        ISalaryGradeStep SalaryGradeStep { get; set; }
        DateTime EffectivityDate { get; set; }
    }
}

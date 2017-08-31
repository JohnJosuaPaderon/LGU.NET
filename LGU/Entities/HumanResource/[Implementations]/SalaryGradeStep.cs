using System;

namespace LGU.Entities.HumanResource
{
    public class SalaryGradeStep : Entity<long>, ISalaryGradeStep
    {
        public SalaryGradeStep(ISalaryGrade salaryGrade, int step)
        {
            SalaryGrade = salaryGrade ?? throw new ArgumentNullException(nameof(salaryGrade));
            Step = step;
        }

        public ISalaryGrade SalaryGrade { get; }
        public int Step { get; }
        public decimal Amount { get; set; }

        public override string ToString()
        {
            return Step.ToString();
        }
    }
}

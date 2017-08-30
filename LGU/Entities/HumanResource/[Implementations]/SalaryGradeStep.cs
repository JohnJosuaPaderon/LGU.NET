namespace LGU.Entities.HumanResource
{
    public class SalaryGradeStep : Entity<long>, ISalaryGradeStep
    {
        public ISalaryGrade SalaryGrade { get; }
        public int Step { get; }
        public decimal Amount { get; set; }

        public override string ToString()
        {
            return Step.ToString();
        }
    }
}

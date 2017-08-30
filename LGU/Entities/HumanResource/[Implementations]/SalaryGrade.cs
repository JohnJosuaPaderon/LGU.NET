using System;

namespace LGU.Entities.HumanResource
{
    public class SalaryGrade : Entity<long>, ISalaryGrade
    {
        static SalaryGrade()
        {

        }

        public static int MinGrade { get; }
        public static int MaxGrade { get; }

        public SalaryGrade(ISalaryGradeBatch batch, int number)
        {
            Batch = batch ?? throw new ArgumentNullException(nameof(batch));

            if (number < MinGrade)
            {
                throw new ArgumentException($"Salary grade number cannot be less than {MinGrade}.");
            }
            else if (number > MaxGrade)
            {
                throw new ArgumentException($"Salary grade number cannot be greater than {MaxGrade}.");
            }

            Number = number;
        }

        public int Number { get; }
        public ISalaryGradeBatch Batch { get; }

        public override string ToString()
        {
            return Number.ToString();
        }
    }
}

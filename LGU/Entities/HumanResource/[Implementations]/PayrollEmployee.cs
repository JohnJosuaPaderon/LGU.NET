namespace LGU.Entities.HumanResource
{
    public abstract class PayrollEmployee<TDepartment> : Entity<long>, IPayrollEmployee<TDepartment>
        where TDepartment : IPayrollDepartment
    {
        public IEmployee Employee { get; set; }
        public TDepartment Department { get; set; }
        public decimal MonthlyRate { get; set; }
        public decimal? WithholdingTax { get; set; }
        public decimal TimeLogDeduction { get; set; }

        public decimal AmountAccrued
        {
            get { return MonthlyRate / 2; }
        }

        public decimal AmountPaid
        {
            get { return (AmountAccrued + CalculateTotalAddition()) - CalculateTotalDeduction(); }
        }

        protected virtual decimal CalculateTotalAddition()
        {
            return 0;
        }

        protected virtual decimal CalculateTotalDeduction()
        {
            return WithholdingTax ?? 0 + TimeLogDeduction;
        }

        public override string ToString()
        {
            return Employee.ToString();
        }
    }
}

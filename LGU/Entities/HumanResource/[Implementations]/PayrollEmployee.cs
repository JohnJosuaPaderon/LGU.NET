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

        public override string ToString()
        {
            return Employee.ToString();
        }
    }
}

namespace LGU.Entities.HumanResource
{
    public interface IPayrollEmployee
    {
        IEmployee Employee { get; set; }
        IPayroll Payroll { get; set; }
        decimal MonthlyRate { get; set; }
        decimal TimeLogDeduction { get; set; }
        decimal? WithholdingTax { get; set; }
    }
}

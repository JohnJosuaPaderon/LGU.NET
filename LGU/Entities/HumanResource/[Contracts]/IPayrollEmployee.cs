namespace LGU.Entities.HumanResource
{
    public interface IPayrollEmployee<TDepartment>
        where TDepartment : IPayrollDepartment
    {
        IEmployee Employee { get; set; }
        TDepartment Department { get; set; }
        decimal MonthlyRate { get; set; }
        decimal TimeLogDeduction { get; set; }
        decimal? WithholdingTax { get; set; }
    }
}

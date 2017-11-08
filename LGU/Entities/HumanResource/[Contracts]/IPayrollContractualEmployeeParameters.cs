namespace LGU.Entities.HumanResource
{
    public interface IPayrollContractualEmployeeParameters : IPayrollEmployeeParameters
    {
        string HdmfPremiumPs { get; }
        string EmployeeId { get; }
        string MonthlyRate { get; }
        string TimeLogDeduction { get; }
        string WithholdingTax { get; }
    }
}

namespace LGU.Entities.HumanResource
{
    public interface IPayrollContractualEmployeeFields
    {
        string HdmfPremiumPs { get; }
        string EmployeeId { get; }
        string PayrollId { get; }
        string MonthlyRate { get; }
        string TimeLogDeduction { get; }
        string WithholdingTax { get; }
    }
}

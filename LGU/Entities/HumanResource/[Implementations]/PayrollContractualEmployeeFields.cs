namespace LGU.Entities.HumanResource
{
    public sealed class PayrollContractualEmployeeFields : PayrollEmployeeFields, IPayrollContractualEmployeeFields
    {
        public PayrollContractualEmployeeFields()
        {
            HdmfPremiumPs = "HdmfPremiumPs";
            EmployeeId = "EmployeeId";
            MonthlyRate = "MonthlyRate";
            TimeLogDeduction = "TimeLogDeduction";
            WithholdingTax = "WithholdingTax";
        }
        
        public string HdmfPremiumPs { get; }
        public string EmployeeId { get; }
        public string MonthlyRate { get; }
        public string TimeLogDeduction { get; }
        public string WithholdingTax { get; }
    }
}

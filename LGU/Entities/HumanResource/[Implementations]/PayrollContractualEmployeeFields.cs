namespace LGU.Entities.HumanResource
{
    public sealed class PayrollContractualEmployeeFields : IPayrollContractualEmployeeFields
    {
        public PayrollContractualEmployeeFields()
        {
            HdmfPremiumPs = "HdmfPremiumPs";
            EmployeeId = "EmployeeId";
            PayrollId = "PayrollId";
            MonthlyRate = "MonthlyRate";
            TimeLogDeduction = "TimeLogDeduction";
            WithholdingTax = "WithholdingTax";
        }

        public string HdmfPremiumPs { get; }
        public string EmployeeId { get; }
        public string PayrollId { get; }
        public string MonthlyRate { get; }
        public string TimeLogDeduction { get; }
        public string WithholdingTax { get; }
    }
}

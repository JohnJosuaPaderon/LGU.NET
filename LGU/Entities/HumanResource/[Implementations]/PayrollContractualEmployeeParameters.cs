namespace LGU.Entities.HumanResource
{
    public sealed class PayrollContractualEmployeeParameters : IPayrollContractualEmployeeParameters
    {
        public PayrollContractualEmployeeParameters()
        {
            HdmfPremiumPs = "@_HdmfPremiumPs";
            EmployeeId = "@_EmployeeId";
            PayrollId = "@_PayrollId";
            MonthlyRate = "@_MonthlyRate";
            TimeLogDeduction = "@_TimeLogDeduction";
            WithholdingTax = "@_WithholdingTax";
        }

        public string HdmfPremiumPs { get; }
        public string EmployeeId { get; }
        public string PayrollId { get; }
        public string MonthlyRate { get; }
        public string TimeLogDeduction { get; }
        public string WithholdingTax { get; }
    }
}

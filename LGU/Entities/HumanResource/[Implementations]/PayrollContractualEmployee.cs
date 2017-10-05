namespace LGU.Entities.HumanResource
{
    public sealed class PayrollContractualEmployee : PayrollEmployee, IPayrollContractualEmployee
    {
        public decimal? HdmfPremiumPs { get; set; }
    }
}

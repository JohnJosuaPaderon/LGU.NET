namespace LGU.Entities.HumanResource
{
    public sealed class PayrollContractualEmployee : PayrollEmployee<IPayrollContractualDepartment>, IPayrollContractualEmployee
    {
        public decimal? HdmfPremiumPs { get; set; }
    }
}

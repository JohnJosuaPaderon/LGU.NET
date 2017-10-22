namespace LGU.Entities.HumanResource
{
    public sealed class PayrollContractualEmployee : PayrollEmployee, IPayrollContractualEmployee
    {
        public IPayrollContractualDepartment Department { get; set; }
        public decimal? HdmfPremiumPs { get; set; }
    }
}

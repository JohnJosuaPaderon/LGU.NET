namespace LGU.Entities.HumanResource
{
    public interface IPayrollContractualEmployee : IPayrollEmployee
    {
        IPayrollContractualDepartment Department { get; set; }
        decimal? HdmfPremiumPs { get; set; }
    }
}

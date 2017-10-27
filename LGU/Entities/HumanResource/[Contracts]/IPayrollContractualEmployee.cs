namespace LGU.Entities.HumanResource
{
    public interface IPayrollContractualEmployee : IPayrollEmployee<IPayrollContractualDepartment>
    {
        decimal? HdmfPremiumPs { get; set; }
    }
}

namespace LGU.Entities.HumanResource
{
    public interface IPayrollContractualEmployee : IPayrollEmployee
    {
        decimal? HdmfPremiumPs { get; set; }
    }
}

namespace LGU.Entities.HumanResource
{
    public interface IPayrollContractualInclusion
    {
        IPayrollContractual Payroll { get; }
        bool HdmfPremiumPs { get; set; }
    }
}

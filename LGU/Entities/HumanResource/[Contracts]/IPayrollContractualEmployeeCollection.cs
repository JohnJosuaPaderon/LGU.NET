namespace LGU.Entities.HumanResource
{
    public interface IPayrollContractualEmployeeCollection : IEntityCollection<IPayrollContractualEmployee>
    {
        IPayrollContractualDepartment Department { get; }
        decimal TotalHdmfPremiumPs { get; }
        decimal TotalMonthlyRate { get; }
        decimal TotalWithholdingTax { get; }
        decimal TotalAmountAccrued { get; }
        decimal TotalAmountPaid { get; }
    }
}

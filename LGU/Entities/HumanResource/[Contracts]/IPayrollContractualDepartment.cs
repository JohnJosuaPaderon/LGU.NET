namespace LGU.Entities.HumanResource
{
    public interface IPayrollContractualDepartment : IPayrollDepartment
    {
        IPayrollContractual Payroll { get; set; }
        IEntityCollection<IPayrollContractualEmployee> Employees { get; }
    }
}

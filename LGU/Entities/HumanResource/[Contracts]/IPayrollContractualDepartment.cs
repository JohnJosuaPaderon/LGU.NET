namespace LGU.Entities.HumanResource
{
    public interface IPayrollContractualDepartment : IPayrollDepartment
    {
        IPayrollContractualEmployeeCollection Employees { get; }
    }
}

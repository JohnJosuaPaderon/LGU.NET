namespace LGU.Entities.HumanResource
{
    public interface IPayrollContractual : IPayroll
    {
        IPayrollContractualDepartmentCollection Departments { get; }
    }
}

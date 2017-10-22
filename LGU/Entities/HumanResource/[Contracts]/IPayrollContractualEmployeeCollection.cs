namespace LGU.Entities.HumanResource
{
    public interface IPayrollContractualEmployeeCollection : IEntityCollection<IPayrollContractualEmployee>
    {
        IPayrollContractualDepartment Department { get; }
    }
}

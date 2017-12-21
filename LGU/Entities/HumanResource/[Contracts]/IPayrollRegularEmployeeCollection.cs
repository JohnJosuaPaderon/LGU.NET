namespace LGU.Entities.HumanResource
{
    public interface IPayrollRegularEmployeeCollection : IEntityCollection<IPayrollRegularEmployee>
    {
        IPayrollRegularDepartment Department { get; }
    }
}

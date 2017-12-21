namespace LGU.Entities.HumanResource
{
    public interface IPayrollRegular : IPayroll
    {
        IPayrollRegularInclusion Inclusion { get; }
        IPayrollRegularDepartmentCollection Departments { get; }
}
}

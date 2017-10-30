namespace LGU.Entities.HumanResource
{
    public interface IPayrollDepartmentCollection<TPayroll, TPayrollDepartment> : IEntityCollection<TPayrollDepartment>
        where TPayroll : IPayroll
        where TPayrollDepartment : IPayrollDepartment
    {
        TPayroll Payroll { get; }
    }
}

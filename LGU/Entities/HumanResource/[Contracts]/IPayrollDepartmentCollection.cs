namespace LGU.Entities.HumanResource
{
    public interface IPayrollDepartmentCollection<TPayroll, TPayrollDepartment>
        where TPayroll : IPayroll<TPayrollDepartment>
        where TPayrollDepartment : IPayrollDepartment
    {
        TPayroll Payroll { get; }
    }
}

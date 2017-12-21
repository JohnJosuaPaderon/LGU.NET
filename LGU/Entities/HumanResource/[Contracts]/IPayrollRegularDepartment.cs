namespace LGU.Entities.HumanResource
{
    public interface IPayrollRegularDepartment : IPayrollDepartment
    {
        IPayrollRegular Payroll { get; set; }
    }
}

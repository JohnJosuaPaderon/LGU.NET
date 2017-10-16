namespace LGU.Entities.HumanResource
{
    public interface IPayrollDepartment
    {
        IDepartment Department { get; set; }
        IPayroll Payroll { get; set; }
        IEmployee Head { get; set; }
        int Ordinal { get; set; }
    }
}

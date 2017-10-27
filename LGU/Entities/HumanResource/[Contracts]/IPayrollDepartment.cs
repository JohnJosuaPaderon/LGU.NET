namespace LGU.Entities.HumanResource
{
    public interface IPayrollDepartment
    {
        IDepartment Department { get; set; }
        IDepartmentHead Head { get; set; }
        int Ordinal { get; set; }
    }
}

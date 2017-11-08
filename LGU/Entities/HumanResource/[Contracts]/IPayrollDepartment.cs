namespace LGU.Entities.HumanResource
{
    public interface IPayrollDepartment : IEntity<long>
    {
        IDepartment Department { get; set; }
        IEmployee Head { get; set; }
        int Ordinal { get; set; }
    }
}

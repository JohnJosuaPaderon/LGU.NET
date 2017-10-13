namespace LGU.Entities.HumanResource
{
    public interface IEmployeeParameters
    {
        string Id { get; }
        string FirstName { get; }
        string MiddleName { get; }
        string LastName { get; }
        string NameExtension { get; }
        string BirthDate { get; }
        string Deceased { get; }
        string MonthlySalary { get; }
        string DepartmentId { get; }
        string EmploymentStatusId { get; }
        string GenderId { get; }
        string PositionId { get; }
        string TypeId { get; }
        string DepartmentHeadId { get; }
        string WorkTimeScheduleId { get; }
        string PayrollTypeId { get; }
        string IsFlexWorkSchedule { get; }
    }
}

using LGU.Entities.Core;

namespace LGU.Entities.HumanResource
{
    public interface IEmployeeParameters : IPersonParameters
    {
        string MonthlySalary { get; }
        string DepartmentId { get; }
        string EmploymentStatusId { get; }
        string PositionId { get; }
        string TypeId { get; }
        string DepartmentHeadId { get; }
        string WorkTimeScheduleId { get; }
        string PayrollTypeId { get; }
        string IsFlexWorkSchedule { get; }
        string Title { get; }
        string BankAccountNumber { get; }
    }
}

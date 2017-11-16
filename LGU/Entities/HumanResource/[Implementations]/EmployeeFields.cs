using LGU.Entities.Core;

namespace LGU.Entities.HumanResource
{
    public sealed class EmployeeFields : PersonFields, IEmployeeFields
    {
        public EmployeeFields()
        {
            MonthlySalary = "MonthlySalary";
            DepartmentId = "DepartmentId";
            EmploymentStatusId = "EmploymentStatusId";
            PositionId = "PositionId";
            TypeId = "TypeId";
            DepartmentHeadId = "DepartmentHeadId";
            WorkTimeScheduleId = "WorkTimeScheduleId";
            PayrollTypeId = "PayrollTypeId";
            IsFlexWorkSchedule = "IsFlexWorkSchedule";
            Title = "Title";
            BankAccountNumber = "BankAccountNumber";
        }
        
        public string MonthlySalary { get; }
        public string DepartmentId { get; }
        public string EmploymentStatusId { get; }
        public string PositionId { get; }
        public string TypeId { get; }
        public string DepartmentHeadId { get; }
        public string WorkTimeScheduleId { get; }
        public string PayrollTypeId { get; }
        public string IsFlexWorkSchedule { get; }
        public string Title { get; }
        public string BankAccountNumber { get; }
    }
}

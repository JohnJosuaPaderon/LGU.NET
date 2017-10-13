using LGU.Entities.Core;

namespace LGU.Entities.HumanResource
{
    public sealed class EmployeeParameters : PersonParameters, IEmployeeParameters
    {
        public EmployeeParameters()
        {
            MonthlySalary = "@_MonthlySalary";
            DepartmentId = "@_DepartmentId";
            EmploymentStatusId = "@_EmploymentStatusId";
            PositionId = "@_PositionId";
            TypeId = "@_TypeId";
            DepartmentHeadId = "@_DepartmentHeadId";
            WorkTimeScheduleId = "@_WorkTimeScheduleId";
            IsFlexWorkSchedule = "@_IsFlexWorkSchedule";
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
    }
}

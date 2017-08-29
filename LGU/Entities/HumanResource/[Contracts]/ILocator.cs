using System;

namespace LGU.Entities.HumanResource
{
    public interface ILocator : IEntity<long>
    {
        IEmployee Requestor { get; }
        DateTime Date { get; set; }
        DateTime OfficeOutTime { get; set; }
        DateTime? ExpectedReturnTime { get; set; }
        ILocatorLeaveType LeaveType { get; set; }
        string Purpose { get; set; }
        string DepartmentHead { get; set; }
    }
}

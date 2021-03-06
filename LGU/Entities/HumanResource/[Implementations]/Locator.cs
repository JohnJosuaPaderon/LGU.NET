﻿using System;

namespace LGU.Entities.HumanResource
{
    public class Locator : Entity<long>, ILocator
    {
        public Locator(IEmployee requestor)
        {
            Requestor = requestor ?? throw new ArgumentNullException(nameof(requestor));
        }

        public IEmployee Requestor { get; }
        public DateTime Date { get; set; }
        public DateTime OfficeOutTime { get; set; }
        public DateTime? ExpectedReturnTime { get; set; }
        public ILocatorLeaveType LeaveType { get; set; }
        public string Purpose { get; set; }
        public string DepartmentHead { get; set; }
    }
}

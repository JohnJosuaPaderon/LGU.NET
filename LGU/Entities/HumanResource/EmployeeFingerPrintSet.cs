using LGU.Entities.Core;
using System;

namespace LGU.Entities.HumanResource
{
    public class EmployeeFingerPrintSet : FingerPrintSet
    {
        public EmployeeFingerPrintSet(Employee employee)
        {
            Employee = employee ?? throw new ArgumentNullException(nameof(employee));
        }

        public Employee Employee { get; }
    }
}

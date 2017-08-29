using LGU.Entities.Core;
using System;

namespace LGU.Entities.HumanResource
{
    public class EmployeeFingerPrintSet : FingerPrintSet, IEmployeeFingerPrintSet
    {
        public EmployeeFingerPrintSet(IEmployee employee)
        {
            Employee = employee ?? throw new ArgumentNullException(nameof(employee));
        }

        public IEmployee Employee { get; }
    }
}

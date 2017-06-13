using System;

namespace LGU.HumanResource.Entities
{
    public class EmployeeEmploymentInfo
    {
        public EmployeeEmploymentInfo(Employee employee)
        {
            Employee = employee ?? throw LGUException.ArgumentNull(nameof(employee), "Employee passed on constructor is null.");
        }

        public Employee Employee { get; }
        public DateTime? EmploymentDate { get; set; }

        public static bool operator ==(EmployeeEmploymentInfo left, EmployeeEmploymentInfo right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EmployeeEmploymentInfo left, EmployeeEmploymentInfo right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            var value = obj as EmployeeEmploymentInfo;
            return Employee.Equals(value.Employee);
        }

        public override int GetHashCode()
        {
            return Employee.GetHashCode();
        }
    }
}

using System;

namespace LGU.Entities.HumanResource
{
    public sealed class EmployeeSalaryGradeStep : IEmployeeSalaryGradeStep
    {
        public IEmployee Employee { get; set; }
        public ISalaryGradeStep SalaryGradeStep { get; set; }
        public DateTime EffectivityDate { get; set; }

        public static bool operator ==(EmployeeSalaryGradeStep left, EmployeeSalaryGradeStep right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EmployeeSalaryGradeStep left, EmployeeSalaryGradeStep right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            var value = obj as EmployeeSalaryGradeStep;

            return
                Employee.Equals(value.Employee) &&
                SalaryGradeStep.Equals(value.SalaryGradeStep);
        }

        public override int GetHashCode()
        {
            return
                Employee.GetHashCode() ^
                SalaryGradeStep.GetHashCode();
        }
    }
}

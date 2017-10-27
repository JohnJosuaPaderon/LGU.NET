namespace LGU.Entities.HumanResource
{
    public abstract class PayrollEmployee<TDepartment> : IPayrollEmployee<TDepartment>
        where TDepartment : IPayrollDepartment
    {
        public IEmployee Employee { get; set; }
        public TDepartment Department { get; set; }
        public decimal MonthlyRate { get; set; }
        public decimal? WithholdingTax { get; set; }
        public decimal TimeLogDeduction { get; set; }

        public static bool operator ==(PayrollEmployee<TDepartment> left, PayrollEmployee<TDepartment> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PayrollEmployee<TDepartment> left, PayrollEmployee<TDepartment> right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            var value = obj as PayrollEmployee<TDepartment>;
            return
                Employee.Equals(value.Employee) &&
                Department.Equals(value.Department);
        }

        public override int GetHashCode()
        {
            return
                Employee.GetHashCode() ^
                Department.GetHashCode();
        }

        public override string ToString()
        {
            return Employee.ToString();
        }
    }
}

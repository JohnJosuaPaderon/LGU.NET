namespace LGU.Entities.HumanResource
{
    public class PayrollEmployee : IPayrollEmployee
    {
        public IEmployee Employee { get; set; }
        public IPayroll Payroll { get; set; }
        public decimal MonthlyRate { get; set; }
        public decimal? WithholdingTax { get; set; }
        public string Remarks { get; set; }

        public static bool operator ==(PayrollEmployee left, PayrollEmployee right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PayrollEmployee left, PayrollEmployee right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            var value = obj as PayrollEmployee;
            return
                Employee.Equals(value.Employee) &&
                Payroll.Equals(value.Payroll);
        }

        public override int GetHashCode()
        {
            return
                Employee.GetHashCode() ^
                Payroll.GetHashCode();
        }

        public override string ToString()
        {
            return Employee.ToString();
        }
    }
}

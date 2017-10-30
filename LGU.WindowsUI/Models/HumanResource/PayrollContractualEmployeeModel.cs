using LGU.Entities.HumanResource;

namespace LGU.Models.HumanResource
{
    public sealed class PayrollContractualEmployeeModel : ModelBase<IPayrollContractualEmployee>
    {
        public static PayrollContractualEmployeeModel TryCreate(IPayrollContractualEmployee payrollContractualEmployee)
        {
            return payrollContractualEmployee != null ? new PayrollContractualEmployeeModel(payrollContractualEmployee) : null;
        }

        public PayrollContractualEmployeeModel(IPayrollContractualEmployee source) : base(source ?? new PayrollContractualEmployee())
        {
            Employee = EmployeeModel.TryCreate(source.Employee);
            MonthlyRate = source.MonthlyRate;
            WithholdingTax = source.WithholdingTax;
            HdmfPremiumPs = source.HdmfPremiumPs;
            TimeLogDeduction = source.TimeLogDeduction;
        }

        private EmployeeModel _Employee;
        public EmployeeModel Employee
        {
            get { return _Employee; }
            set { SetProperty(ref _Employee, value); }
        }

        private decimal _MonthlyRate;
        public decimal MonthlyRate
        {
            get { return _MonthlyRate; }
            set { SetProperty(ref _MonthlyRate, value); }
        }

        private decimal? _WithholdingTax;
        public decimal? WithholdingTax
        {
            get { return _WithholdingTax; }
            set { SetProperty(ref _WithholdingTax, value); }
        }

        private decimal? _HdmfPremiumPs;
        public decimal? HdmfPremiumPs
        {
            get { return _HdmfPremiumPs; }
            set { SetProperty(ref _HdmfPremiumPs, value); }
        }

        private decimal _TimeLogDeduction;
        public decimal TimeLogDeduction
        {
            get { return _TimeLogDeduction; }
            set { SetProperty(ref _TimeLogDeduction, value); }
        }

        public override IPayrollContractualEmployee GetSource()
        {
            Source.Employee = Employee.GetSource();
            Source.HdmfPremiumPs = HdmfPremiumPs;
            Source.MonthlyRate = MonthlyRate;
            Source.WithholdingTax = WithholdingTax;
            Source.TimeLogDeduction = TimeLogDeduction;

            return Source;
        }


        public static bool operator ==(PayrollContractualEmployeeModel left, PayrollContractualEmployeeModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PayrollContractualEmployeeModel left, PayrollContractualEmployeeModel right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            if (obj is PayrollContractualEmployeeModel value)
            {
                return
                    Employee == value.Employee;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return
                Employee.GetHashCode();
        }
    }
}

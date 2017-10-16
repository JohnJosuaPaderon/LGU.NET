using LGU.Entities.HumanResource;

namespace LGU.Models.HumanResource
{
    public sealed class PayrollContractualEmployeeModel : ModelBase<IPayrollContractualEmployee>
    {
        public PayrollContractualEmployeeModel(IPayrollContractualEmployee source) : base(source ?? new PayrollContractualEmployee())
        {
            Employee = new EmployeeModel(source?.Employee);
            Payroll = new PayrollModel(source?.Payroll);
            MonthlyRate = source?.MonthlyRate ?? default(decimal);
            WithholdingTax = source?.WithholdingTax ?? default(decimal);
            HdmfPremiumPs = source?.HdmfPremiumPs;
            TimeLogDeduction = source?.TimeLogDeduction ?? 0;
        }

        private EmployeeModel _Employee;
        public EmployeeModel Employee
        {
            get { return _Employee; }
            set { SetProperty(ref _Employee, value); }
        }

        private PayrollModel _Payroll;
        public PayrollModel Payroll
        {
            get { return _Payroll; }
            set { SetProperty(ref _Payroll, value); }
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
            if (Source != null)
            {
                Source.Employee = Employee.GetSource();
                Source.HdmfPremiumPs = HdmfPremiumPs;
                Source.MonthlyRate = MonthlyRate;
                Source.Payroll = Payroll.GetSource();
                Source.WithholdingTax = WithholdingTax;
                Source.TimeLogDeduction = TimeLogDeduction;
            }

            return Source;
        }
    }
}

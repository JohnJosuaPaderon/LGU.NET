using LGU.Models.HumanResource;

namespace LGU.Interactivity.HumanResource
{
    public sealed class ContractualPayrollSignatoryNotification : CustomNotification, IContractualPayrollSignatoryNotification
    {
        public ContractualPayrollSignatoryNotification(PayrollContractualModel payroll)
        {
            Payroll = payroll;
        }

        private PayrollContractualModel _Payroll;
        public PayrollContractualModel Payroll
        {
            get { return _Payroll; }
            set { SetProperty(ref _Payroll, value); }
        }
    }
}

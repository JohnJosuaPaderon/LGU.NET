namespace LGU.Entities.HumanResource
{
    public sealed class PayrollContractualEmployee : PayrollEmployee<IPayrollContractualDepartment>, IPayrollContractualEmployee
    {
        private decimal? _HdmfPremiumPs;

        public decimal? HdmfPremiumPs
        {
            get { return Department.Payroll.Inclusion.HdmfPremiumPs ? _HdmfPremiumPs : null; }
            set
            {
                _HdmfPremiumPs = value;
            }
        }
    }
}

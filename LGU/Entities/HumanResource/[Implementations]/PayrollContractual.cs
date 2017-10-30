namespace LGU.Entities.HumanResource
{
    public class PayrollContractual : Payroll, IPayrollContractual
    {
        public PayrollContractual() : base(PayrollType.Contractual)
        {
        }

        public IPayrollContractualDepartmentCollection Departments { get; }
    }
}

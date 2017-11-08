namespace LGU.Entities.HumanResource
{
    public class PayrollContractual : Payroll, IPayrollContractual
    {
        public PayrollContractual() : base(PayrollTypeFactory.Contractual)
        {
            Departments = new PayrollContractualDepartmentCollection(this);
            Inclusion = new PayrollContractualInclusion(this);
        }

        public IPayrollContractualInclusion Inclusion { get; set; }
        public IPayrollContractualDepartmentCollection Departments { get; }
    }
}

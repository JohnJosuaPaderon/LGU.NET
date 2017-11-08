namespace LGU.Entities.HumanResource
{
    public class PayrollContractualDepartment : PayrollDepartment, IPayrollContractualDepartment
    {
        public PayrollContractualDepartment()
        {
            Employees = new PayrollContractualEmployeeCollection(this);
        }

        public IPayrollContractual Payroll { get; set; }
        public IPayrollContractualEmployeeCollection Employees { get; }
    }
}

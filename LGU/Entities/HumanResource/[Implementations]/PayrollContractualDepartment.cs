namespace LGU.Entities.HumanResource
{
    public class PayrollContractualDepartment : PayrollDepartment, IPayrollContractualDepartment
    {
        public PayrollContractualDepartment()
        {
            Employees = new PayrollContractualEmployeeCollection(this);
        }

        public IPayrollContractualEmployeeCollection Employees { get; }
    }
}

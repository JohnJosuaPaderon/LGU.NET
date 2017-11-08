namespace LGU.Entities.HumanResource
{
    public class PayrollEmployeeFields : EntityFields, IPayrollEmployeeFields
    {
        public PayrollEmployeeFields()
        {
            DepartmentId = "DepartmentId";
        }

        public string DepartmentId { get; }
    }
}

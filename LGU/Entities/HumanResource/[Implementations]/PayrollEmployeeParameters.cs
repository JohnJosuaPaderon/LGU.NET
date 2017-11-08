namespace LGU.Entities.HumanResource
{
    public class PayrollEmployeeParameters : EntityParameters, IPayrollEmployeeParameters
    {
        public PayrollEmployeeParameters()
        {
            DepartmentId = "@_DepartmentId";
        }

        public string DepartmentId { get; }
    }
}

namespace LGU.Entities.HumanResource
{
    public class PayrollDepartmentFields : IPayrollDepartmentFields
    {
        public PayrollDepartmentFields()
        {
            DepartmentId = "DepartmentId";
            PayrollId = "PayrollId";
            HeadId = "HeadId";
            Ordinal = "Ordinal";
        }

        public string DepartmentId { get; }
        public string PayrollId { get; }
        public string HeadId { get; }
        public string Ordinal { get; }
    }
}

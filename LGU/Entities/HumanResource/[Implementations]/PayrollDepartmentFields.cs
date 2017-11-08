namespace LGU.Entities.HumanResource
{
    public class PayrollDepartmentFields : IPayrollDepartmentFields
    {
        public PayrollDepartmentFields()
        {
            Id = "Id";
            DepartmentId = "DepartmentId";
            PayrollId = "PayrollId";
            HeadId = "HeadId";
            Ordinal = "Ordinal";
        }

        public string Id { get; }
        public string DepartmentId { get; }
        public string PayrollId { get; }
        public string HeadId { get; }
        public string Ordinal { get; }
    }
}

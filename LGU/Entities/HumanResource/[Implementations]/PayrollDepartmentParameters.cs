namespace LGU.Entities.HumanResource
{
    public class PayrollDepartmentParameters : IPayrollDepartmentParameters
    {
        public PayrollDepartmentParameters()
        {
            Id = "@_Id";
            DepartmentId = "@_DepartmentId";
            PayrollId = "@_PayrollId";
            HeadId = "@_HeadId";
            Ordinal = "@_Ordinal";
        }

        public string Id { get; }
        public string DepartmentId { get; }
        public string PayrollId { get; }
        public string HeadId { get; }
        public string Ordinal { get; }
    }
}

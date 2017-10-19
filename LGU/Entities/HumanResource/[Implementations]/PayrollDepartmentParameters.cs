namespace LGU.Entities.HumanResource
{
    public class PayrollDepartmentParameters : IPayrollDepartmentParameters
    {
        public PayrollDepartmentParameters()
        {
            DepartmentId = "@_DepartmentId";
            PayrollId = "@_PayrollId";
            HeadId = "@_HeadId";
            Ordinal = "@_Ordinal";
        }

        public string DepartmentId { get; }
        public string PayrollId { get; }
        public string HeadId { get; }
        public string Ordinal { get; }
    }
}

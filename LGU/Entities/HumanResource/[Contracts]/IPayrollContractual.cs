namespace LGU.Entities.HumanResource
{
    public interface IPayrollContractual : IPayroll
    {
        IPayrollContractualInclusion Inclusion { get; }
        IPayrollContractualDepartmentCollection Departments { get; }
    }
}

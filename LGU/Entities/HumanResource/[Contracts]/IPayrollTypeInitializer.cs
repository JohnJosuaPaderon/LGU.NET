namespace LGU.Entities.HumanResource
{
    public interface IPayrollTypeInitializer
    {
        IPayrollType Regular { get; }
        IPayrollType Contractual { get; }
    }
}

namespace LGU.Entities.HumanResource
{
    public interface IPayrollType : IEntity<short>
    {
        string Description { get; set; }
    }
}

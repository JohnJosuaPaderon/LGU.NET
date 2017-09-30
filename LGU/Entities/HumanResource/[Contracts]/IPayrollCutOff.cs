namespace LGU.Entities.HumanResource
{
    public interface IPayrollCutOff : IEntity<short>
    {
        int Count { get; set; }
        string Description { get; set; }
    }
}

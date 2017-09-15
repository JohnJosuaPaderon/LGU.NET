namespace LGU.Entities.HumanResource
{
    public interface IPayrollDeduction : IEntity<int>
    {
        string Description { get; set; }
    }
}

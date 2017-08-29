namespace LGU.Entities.HumanResource
{
    public interface IEmployeeType : IEntity<short>
    {
        string Description { get; set; }
    }
}

namespace LGU.Entities.HumanResource
{
    public interface IEmploymentStatus : IEntity<short>
    {
        string Description { get; set; }
    }
}

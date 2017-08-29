namespace LGU.Entities.HumanResource
{
    public interface IApplicationStatus : IEntity<short>
    {
        string Description { get; set; }
    }
}

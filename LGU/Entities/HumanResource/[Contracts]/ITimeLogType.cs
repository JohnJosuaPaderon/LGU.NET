namespace LGU.Entities.HumanResource
{
    public interface ITimeLogType : IEntity<short>
    {
        string Description { get; set; }
    }
}

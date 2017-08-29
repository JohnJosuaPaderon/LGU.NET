namespace LGU.Entities.Core
{
    public interface IGender : IEntity<short>
    {
        string Description { get; set; }
    }
}

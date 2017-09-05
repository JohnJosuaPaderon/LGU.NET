namespace LGU.Entities.Core
{
    public interface ICitizenship : IEntity<short>
    {
        string Description { get; set; }
    }
}

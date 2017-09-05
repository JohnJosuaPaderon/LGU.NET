namespace LGU.Entities.Core
{
    public interface ICivilStatus : IEntity<short>
    {
        string Description { get; set; }
    }
}

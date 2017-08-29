namespace LGU.Entities
{
    public interface IEntity<TIdentifier>
    {
        TIdentifier Id { get; set; }
    }
}

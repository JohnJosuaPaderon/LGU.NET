namespace LGU.Entities.Core
{
    public interface ICountry : IEntity<int>
    {
        string Name { get; set; }
    }
}

namespace LGU.Entities.Core
{
    public interface IProvince : IEntity<int>
    {
        ICountry Country { get; }
        string Name { get; set; }
    }
}

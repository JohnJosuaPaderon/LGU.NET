namespace LGU.Entities.Core
{
    public interface IBarangay : IEntity<int>
    {
        ICityMunicipality CityMunicipality { get; }
        short? District { get; set; }
        string Name { get; set; }
    }
}

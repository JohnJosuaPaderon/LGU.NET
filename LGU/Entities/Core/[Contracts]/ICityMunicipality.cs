namespace LGU.Entities.Core
{
    public interface ICityMunicipality : IEntity<int>
    {
        ICountry Country { get; }
        IProvince Province { get; }
        string Name { get; set; }
        short? DistrictCount { get; set; }
    }
}

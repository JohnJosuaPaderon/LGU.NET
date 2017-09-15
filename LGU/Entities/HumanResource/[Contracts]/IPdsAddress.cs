using LGU.Entities.Core;

namespace LGU.Entities.HumanResource
{
    public interface IPdsAddress : IEntity<long>
    {
        PdsAddressType Type { get; }
        int? HouseNumber { get; set; }
        int? BlockNumber { get; set; }
        int? LotNumber { get; set; }
        string Street { get; set; }
        string SubdivisionVillage { get; set; }
        IBarangay Barangay { get; set; }
        short? ZipCode { get; set; }
        string FullName { get; }
    }
}

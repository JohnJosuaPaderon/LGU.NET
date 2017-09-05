namespace LGU.Entities.Core
{
    public interface IPersonalDataSheetAddress : IEntity<long>
    {
        IPersonalDataSheet PersonalDataSheet { get; }
        PersonAddressType Type { get; }
        int? HouseNumber { get; set; }
        int? BlockNumber { get; set; }
        int? LotNumber { get; set; }
        string Street { get; set; }
        string SubdivisionVillage { get; set; }
        IBarangay Barangay { get; set; }
        short? ZipCode { get; set; }
    }
}

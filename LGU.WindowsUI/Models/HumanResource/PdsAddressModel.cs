using LGU.Entities.Core;
using LGU.Entities.HumanResource;

namespace LGU.Models.HumanResource
{
    public sealed class PdsAddressModel : ModelBase<IPdsAddress>
    {
        public PdsAddressModel(IPdsAddress source) : base(source)
        {
        }

        private long _Id;
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }

        private PdsAddressType _Type;
        public PdsAddressType Type
        {
            get { return _Type; }
            set { SetProperty(ref _Type, value); }
        }

        private int? _HouseNumber;
        public int? HouseNumber
        {
            get { return _HouseNumber; }
            set { SetProperty(ref _HouseNumber, value); }
        }

        private int? _BlockNumber;
        public int? BlockNumber
        {
            get { return _BlockNumber; }
            set { SetProperty(ref _BlockNumber, value); }
        }
        private int? _LotNumber;
        public int? LotNumber
        {
            get { return _LotNumber; }
            set { SetProperty(ref _LotNumber, value); }
        }

        private string _Street;
        public string Street
        {
            get { return _Street; }
            set { SetProperty(ref _Street, value); }
        }

        private string _SubdivisionVillage;
        public string SubdivisionVillage
        {
            get { return _SubdivisionVillage; }
            set { SetProperty(ref _SubdivisionVillage, value); }
        }

        private IBarangay _Barangay;
        public IBarangay Barangay
        {
            get { return _Barangay; }
            set { SetProperty(ref _Barangay, value); }
        }

        private short? _ZipCode;
        public short? ZipCode
        {
            get { return _ZipCode; }
            set { SetProperty(ref _ZipCode, value); }
        }

        public override IPdsAddress GetSource()
        {
            return new PdsAddress()
            {
                Id = Id,
                Type = Type,
                HouseNumber = HouseNumber,
                BlockNumber = BlockNumber,
                LotNumber = LotNumber,
                Street = Street,
                SubdivisionVillage = SubdivisionVillage,
                Barangay = Barangay,
                ZipCode = ZipCode
            };
        }
    }
}

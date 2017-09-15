using LGU.Entities.Core;
using LGU.EntityManagers.HumanResource;
using LGU.Processes;

namespace LGU.Entities.HumanResource
{
    public class PdsAddress : Entity<long>, IPdsAddress
    {
        static PdsAddress()
        {
            r_PdsAddressManager = ApplicationDomain.GetService<IPdsAddressManager>();
        }

        private static readonly IPdsAddressManager r_PdsAddressManager;

        private bool FullNameRefreshRequired;

        private int? _HouseNumber;
        private int? _BlockNumber;
        private int? _LotNumber;
        private string _Street;
        private string _SubdivisionVillage;
        private IBarangay _Barangay;
        private short? _ZipCode;
        private string _FullName;

        public PdsAddressType Type { get; set; }
        public int? HouseNumber
        {
            get { return _HouseNumber; }
            set
            {
                if (_HouseNumber != value)
                {
                    FullNameRefreshRequired = true;
                    _HouseNumber = value;
                }
            }
        }

        public int? BlockNumber
        {
            get { return _BlockNumber; }
            set
            {
                if (_BlockNumber != value)
                {
                    FullNameRefreshRequired = true;
                    _BlockNumber = value;
                }
            }
        }

        public int? LotNumber
        {
            get { return _LotNumber; }
            set
            {
                if (_LotNumber != value)
                {
                    FullNameRefreshRequired = true;
                    _LotNumber = value;
                }
            }
        }

        public string Street
        {
            get { return _Street; }
            set
            {
                if (_Street != value)
                {
                    FullNameRefreshRequired = true;
                    _Street = value;
                }
            }
        }

        public string SubdivisionVillage
        {
            get { return _SubdivisionVillage; }
            set
            {
                if (_SubdivisionVillage != value)
                {
                    FullNameRefreshRequired = true;
                    _SubdivisionVillage = value;
                }
            }
        }

        public IBarangay Barangay
        {
            get { return _Barangay; }
            set
            {
                if (_Barangay != value)
                {
                    _Barangay = value;
                    FullNameRefreshRequired = true;
                }
            }
        }

        public short? ZipCode
        {
            get { return _ZipCode; }
            set
            {
                if (_ZipCode != value)
                {
                    _ZipCode = value;
                    FullNameRefreshRequired = true;
                }
            }
        }

        public string FullName
        {
            get
            {
                if (FullNameRefreshRequired)
                {
                    var result = r_PdsAddressManager.ConstructFullName(this);

                    if (result.Status == ProcessResultStatus.Success)
                    {
                        _FullName = result.Data;
                    }

                    FullNameRefreshRequired = false;
                }

                return _FullName;
            }
        }

        public static bool operator ==(PdsAddress left, PdsAddress right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PdsAddress left, PdsAddress right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            var value = obj as PdsAddress;
            return Id.Equals(value.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}

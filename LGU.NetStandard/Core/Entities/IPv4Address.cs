using LGU.Core.EntityManagers;

namespace LGU.Core.Entities
{
    public class IPv4Address
    {
        private static IPv4AddressManager _Manager;

        public static IPv4AddressManager Manager
        {
            get
            {
                if (_Manager == null)
                {
                    throw LGUException.NullReference($"{nameof(Manager)} is not initialized.");
                }

                return _Manager;
            }
            set
            {
                _Manager = value;
            }
        }

        public byte Class1 { get; set; }
        public byte Class2 { get; set; }
        public byte Class3 { get; set; }
        public byte Class4 { get; set; }

        public static implicit operator IPv4Address(string value)
        {
            return Manager.ConvertFromString(value);
        }

        public static implicit operator IPv4Address(byte[] value)
        {
            return Manager.ConvertFromByteArray(value);
        }

        public static implicit operator string(IPv4Address value)
        {
            return Manager.ConvertToString(value);
        }

        public static implicit operator byte[](IPv4Address value)
        {
            return Manager.ConvertToByteArray(value);
        }

        public static bool operator ==(IPv4Address left, IPv4Address right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(IPv4Address left, IPv4Address right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            var value = obj as IPv4Address;
            return
                Class1.Equals(value.Class1) &&
                Class2.Equals(value.Class2) &&
                Class3.Equals(value.Class3) &&
                Class4.Equals(value.Class4);
        }

        public override int GetHashCode()
        {
            return
                Class1.GetHashCode() ^
                Class2.GetHashCode() ^
                Class3.GetHashCode() ^
                Class4.GetHashCode();
        }

        public override string ToString()
        {
            return Manager.ConvertToString(this);
        }
    }
}

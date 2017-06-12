using LGU.Core.Entities;

namespace LGU.Core.EntityProcesses
{
    public sealed class ConvertStringToIPv4Address : IProcess<IPv4Address>
    {
        public ConvertStringToIPv4Address(string ipv4AddressString)
        {
            if (string.IsNullOrWhiteSpace(ipv4AddressString))
            {
                throw LGUException.ArgumentNullOrWhiteSpace(nameof(ipv4AddressString), "IPv4 Address string is invalid.");
            }

            IPv4AddressString = ipv4AddressString;
        }

        private string IPv4AddressString;
        private string[] IPv4AddressClasses;

        public void Dispose()
        {
        }

        public IPv4Address Execute()
        {
            SplitIPv4Address();

            if (IPv4AddressClasses != null && IPv4AddressClasses.Length == 4)
            {
                return new IPv4Address()
                {
                    Class1 = GetByte(IPv4AddressClasses[0]),
                    Class2 = GetByte(IPv4AddressClasses[1]),
                    Class3 = GetByte(IPv4AddressClasses[2]),
                    Class4 = GetByte(IPv4AddressClasses[3])
                };
            }
            else
            {
                return null;
            }
        }

        private byte GetByte(string value)
        {
            byte.TryParse(value, out byte result);
            return result;
        }

        private void SplitIPv4Address()
        {
            IPv4AddressClasses = IPv4AddressString.Split(IPv4AddressOptions.Default.ClassSeparator);
        }
    }
}

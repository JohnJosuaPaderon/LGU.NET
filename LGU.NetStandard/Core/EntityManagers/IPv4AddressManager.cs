using LGU.Core.Entities;
using LGU.Core.EntityProcesses;

namespace LGU.Core.EntityManagers
{
    public class IPv4AddressManager : IIPv4AddressManager
    {
        public IPv4Address ConvertFromByteArray(byte[] value)
        {
            if (value != null && value.Length == 4)
            {
                return new IPv4Address()
                {
                    Class1 = value[0],
                    Class2 = value[1],
                    Class3 = value[2],
                    Class4 = value[3]
                };
            }
            else
            {
                return null;
            }
        }

        public IPv4Address ConvertFromString(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            else
            {
                using (var process = new ConvertStringToIPv4Address(value))
                {
                    return process.Execute();
                }
            }
        }

        public byte[] ConvertToByteArray(IPv4Address ipv4Address)
        {
            if (ipv4Address != null)
            {
                return new byte[]
                {
                    ipv4Address.Class1,
                    ipv4Address.Class2,
                    ipv4Address.Class3,
                    ipv4Address.Class4
                };
            }
            else
            {
                return null;
            }
        }

        public string ConvertToString(IPv4Address ipv4Address)
        {
            if (ipv4Address != null)
            {
                return string.Concat(
                    ipv4Address.Class1,
                    IPv4AddressOptions.Default.ClassSeparator,
                    ipv4Address.Class2,
                    IPv4AddressOptions.Default.ClassSeparator,
                    ipv4Address.Class3,
                    IPv4AddressOptions.Default.ClassSeparator,
                    ipv4Address.Class4);
            }
            else
            {
                return null;
            }
        }
    }
}

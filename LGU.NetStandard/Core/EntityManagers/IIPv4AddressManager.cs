using LGU.Core.Entities;

namespace LGU.Core.EntityManagers
{
    public interface IIPv4AddressManager
    {
        IPv4Address ConvertFromString(string value);
        IPv4Address ConvertFromByteArray(byte[] value);
        string ConvertToString(IPv4Address ipv4Address);
        byte[] ConvertToByteArray(IPv4Address ipv4Address);
    }
}

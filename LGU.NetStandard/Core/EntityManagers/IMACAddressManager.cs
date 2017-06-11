using LGU.Core.Entities;

namespace LGU.Core.EntityManagers
{
    public interface IMACAddressManager
    {
        string ConvertToString(MACAddress macAddress);
        MACAddress ConvertFromString(string stringValue);
        byte[] ConvertToByteArray(MACAddress macAddress);
        MACAddress ConvertFromByteArray(byte[] byteArray);
    }
}

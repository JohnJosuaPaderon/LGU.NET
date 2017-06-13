using LGU.Core.Entities;
using LGU.Core.EntityProcesses;

namespace LGU.Core.EntityManagers
{
    public class MACAddressManager : IMACAddressManager
    {
        public MACAddress ConvertFromByteArray(byte[] byteArray)
        {
            if (byteArray != null && byteArray.Length == 6)
            {
                return new MACAddress()
                {
                    Block1 = byteArray[0],
                    Block2 = byteArray[1],
                    Block3 = byteArray[2],
                    Block4 = byteArray[3],
                    Block5 = byteArray[4],
                    Block6 = byteArray[5]
                };
            }
            else
            {
                return null;
            }
        }

        public MACAddress ConvertFromString(string stringValue)
        {
            if (string.IsNullOrWhiteSpace(stringValue))
            {
                return null;
            }
            else
            {
                using (var process = new ConvertStringToMACAddress(stringValue))
                {
                    return process.Execute();
                }
            }
        }

        public byte[] ConvertToByteArray(MACAddress macAddress)
        {
            if (macAddress != null)
            {
                return new byte[]
                {
                    macAddress.Block1,
                    macAddress.Block2,
                    macAddress.Block3,
                    macAddress.Block4,
                    macAddress.Block5,
                    macAddress.Block6
                };
            }
            else
            {
                return null;
            }
        }

        public string ConvertToString(MACAddress macAddress)
        {
            if (macAddress != null)
            {
                using (var process = new ConvertMACAddressToString(macAddress))
                {
                    return process.Execute();
                }
            }
            else
            {
                return null;
            }
        }
    }
}

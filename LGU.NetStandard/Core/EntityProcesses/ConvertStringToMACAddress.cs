using LGU.Core.Entities;
using LGU.Utilities;

namespace LGU.Core.EntityProcesses
{
    public sealed class ConvertStringToMACAddress : IConvertStringToMACAddress
    {
        public ConvertStringToMACAddress(string macAddressString)
        {
            if (string.IsNullOrWhiteSpace(macAddressString))
            {
                throw LGUException.ArgumentNullOrWhiteSpace(nameof(macAddressString), "MAC Address string is not valid.");
            }

            MACAddressString = macAddressString;
        }

        public string MACAddressString { get; }
        public string[] MACAddressBlocks;

        public void Dispose()
        {
        }

        public MACAddress Execute()
        {
            SplitMACAddress();

            if (MACAddressBlocks != null && MACAddressBlocks.Length == 6)
            {
                return new MACAddress()
                {
                    Block1 = HexConverter.FromString(MACAddressBlocks[0]),
                    Block2 = HexConverter.FromString(MACAddressBlocks[1]),
                    Block3 = HexConverter.FromString(MACAddressBlocks[2]),
                    Block4 = HexConverter.FromString(MACAddressBlocks[3]),
                    Block5 = HexConverter.FromString(MACAddressBlocks[4]),
                    Block6 = HexConverter.FromString(MACAddressBlocks[5])
                };
            }
            else
            {
                return null;
            }
        }

        private void SplitMACAddress()
        {
            MACAddressBlocks = MACAddressString.Split(MACAddressOptions.Default.BlockSeparator);
        }
    }
}

using LGU.Core.Entities;
using System;
using System.Text;

namespace LGU.Core.EntityProcesses
{
    public sealed class ConvertMACAddressToString : IConvertMACAddressToString
    {
        public ConvertMACAddressToString(MACAddress macAddress)
        {
            MACAddress = macAddress ?? throw LGUException.ArgumentNull(nameof(macAddress), "MAC Address cannot be null.");
        }

        public MACAddress MACAddress { get; private set; }
        private StringBuilder StringBuilder;

        public void Dispose()
        {
            MACAddress = null;

            if (StringBuilder != null)
            {
                StringBuilder = null;
            }
        }

        public string Execute()
        {
            StringBuilder = new StringBuilder();

            StringBuilder.Append(ConvertSingle(MACAddress.Block1));
            StringBuilder.Append(MACAddressOptions.Default.BlockSeparator);
            StringBuilder.Append(ConvertSingle(MACAddress.Block2));
            StringBuilder.Append(MACAddressOptions.Default.BlockSeparator);
            StringBuilder.Append(ConvertSingle(MACAddress.Block3));
            StringBuilder.Append(MACAddressOptions.Default.BlockSeparator);
            StringBuilder.Append(ConvertSingle(MACAddress.Block4));
            StringBuilder.Append(MACAddressOptions.Default.BlockSeparator);
            StringBuilder.Append(ConvertSingle(MACAddress.Block5));
            StringBuilder.Append(MACAddressOptions.Default.BlockSeparator);
            StringBuilder.Append(ConvertSingle(MACAddress.Block6));

            return StringBuilder.ToString();
        }

        private string ConvertSingle(byte value)
        {
            return BitConverter.ToString(new byte[] { value });
        }
    }
}

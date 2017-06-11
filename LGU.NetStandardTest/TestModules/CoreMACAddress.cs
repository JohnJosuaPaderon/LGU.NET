using LGU.Core.Entities;
using LGU.Core.EntityManagers;
using LGU.Utilities;
using System;

namespace LGU.NetStandardTest.TestModules
{
    public sealed class CoreMACAddress : TestModule
    {
        public CoreMACAddress() : base(nameof(CoreMACAddress))
        {
        }

        public override void Start()
        {
            TestConversion();
        }

        private void TestConversion()
        {
            MACAddress.Manager = new MACAddressManager();
            MACAddressOptions.Default = new MACAddressOptions() { BlockSeparator = ':' };
            Console.WriteLine("--TEST CONVERSION--");
            var macAddress = new MACAddress()
            {
                Block1 = 3,
                Block2 = 7,
                Block3 = 15,
                Block4 = 31,
                Block5 = 63,
                Block6 = 127
            };
            string value = macAddress;
            Console.WriteLine(value);
            macAddress = value;
            Console.WriteLine(macAddress);
        }

        private void ReadUserInput()
        {
            ConsoleColorManager.InputHeader();
            Console.Write("CoreMACAddress::");
            ConsoleColorManager.Input();
        }
    }
}

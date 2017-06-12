using LGU.Entities;

namespace LGU.Core.Entities
{
    public abstract class Device : Entity<ulong>
    {
        public Device(DeviceType deviceType)
        {
            Type = deviceType;
        }
        
        public DeviceType Type { get; }
        public MACAddress MACAddress { get; set; }
        public IPv4Address IPv4Address { get; set; }
        public Accessibility Accessibility { get; set; }

        public override string ToString()
        {
            return Type.ToString();
        }
    }
}

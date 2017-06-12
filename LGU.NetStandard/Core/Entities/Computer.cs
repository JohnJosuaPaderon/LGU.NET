namespace LGU.Core.Entities
{
    public class Computer : Device
    {
        public Computer() : base(DeviceType.Computer)
        {

        }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}

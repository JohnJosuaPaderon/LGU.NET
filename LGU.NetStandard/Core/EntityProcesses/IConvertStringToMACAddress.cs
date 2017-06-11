using LGU.Core.Entities;

namespace LGU.Core.EntityProcesses
{
    public interface IConvertStringToMACAddress : IProcess<MACAddress>
    {
        string MACAddressString { get; }
    }
}

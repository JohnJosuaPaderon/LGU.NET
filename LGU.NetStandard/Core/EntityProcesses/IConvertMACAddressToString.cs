using LGU.Core.Entities;

namespace LGU.Core.EntityProcesses
{
    public interface IConvertMACAddressToString : IProcess<string>
    {
        MACAddress MACAddress { get; }
    }
}

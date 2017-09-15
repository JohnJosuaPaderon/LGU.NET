using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IConstructPdsAddressFullName : IProcess<string>
    {
        IPdsAddress PdsAddress { get; set; }
    }
}

using LGU.Entities;
using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityManagers.HumanResource
{
    public interface IPdsAddressManager : IEntityManager<IPdsAddress, long>
    {
        IProcessResult<string> ConstructFullName(IPdsAddress pdsAddress);
    }
}

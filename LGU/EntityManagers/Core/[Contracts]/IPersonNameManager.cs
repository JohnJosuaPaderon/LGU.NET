using LGU.Entities.Core;
using LGU.Processes;

namespace LGU.EntityManagers.Core
{
    public interface IPersonNameManager
    {
        IProcessResult<string> ConstructFullName(IPerson person);
        IProcessResult<string> ConstructMiddleInitials(IPerson person);
        IProcessResult<string> ConstructInformalFullName(IPerson person);
    }
}

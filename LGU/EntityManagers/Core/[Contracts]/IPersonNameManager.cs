using LGU.Entities.Core;
using LGU.Processes;

namespace LGU.EntityManagers.Core
{
    public interface IPersonNameManager
    {
        IProcessResult<string> ConstructFullName(Person person);
        IProcessResult<string> ConstructMiddleInitials(Person person);
        IProcessResult<string> ConstructInformalFullName(Person person);
    }
}

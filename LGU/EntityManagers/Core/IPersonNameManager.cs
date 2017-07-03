using LGU.Entities.Core;

namespace LGU.EntityManagers.Core
{
    public interface IPersonNameManager
    {
        IDataProcessResult<string> ConstructFullName(Person person);
        IDataProcessResult<string> ConstructMiddleInitials(Person person);
        IDataProcessResult<string> ConstructInformalFullName(Person person);
    }
}

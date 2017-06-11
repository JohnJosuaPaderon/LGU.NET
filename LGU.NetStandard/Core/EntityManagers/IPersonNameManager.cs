using LGU.Core.Entities;

namespace LGU.Core.EntityManagers
{
    public interface IPersonNameManager
    {
        string ConstructFullName(Person person);
        string ConstructInformalFullName(Person person);
        string ConstructMiddleIntials(Person person);
    }
}

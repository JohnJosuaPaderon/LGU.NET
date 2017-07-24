using LGU.Entities.Core;
using LGU.EntityProcesses.Core;
using LGU.Processes;

namespace LGU.EntityManagers.Core
{
    public class PersonNameManager : IPersonNameManager
    {
        private readonly IConstructPersonMiddleInitials r_ConstructPersonMiddleInitials;
        private readonly IConstructPersonFullName r_ConstructPersonFullName;
        private readonly IConstructPersonInformalFullName r_ConstructPersonInformalFullName;

        public PersonNameManager(IConstructPersonFullName constructPersonFullName, IConstructPersonInformalFullName constructPersonInformalFullName, IConstructPersonMiddleInitials constructPersonMiddleInitials)
        {
            r_ConstructPersonFullName = constructPersonFullName;
            r_ConstructPersonInformalFullName = constructPersonInformalFullName;
            r_ConstructPersonMiddleInitials = constructPersonMiddleInitials;
        }

        public IProcessResult<string> ConstructFullName(Person person)
        {
            r_ConstructPersonFullName.Person = person;
            return r_ConstructPersonFullName.Execute();
        }

        public IProcessResult<string> ConstructInformalFullName(Person person)
        {
            r_ConstructPersonInformalFullName.Person = person;
            return r_ConstructPersonInformalFullName.Execute();
        }

        public IProcessResult<string> ConstructMiddleInitials(Person person)
        {
            r_ConstructPersonMiddleInitials.Person = person;
            return r_ConstructPersonMiddleInitials.Execute();
        }
    }
}

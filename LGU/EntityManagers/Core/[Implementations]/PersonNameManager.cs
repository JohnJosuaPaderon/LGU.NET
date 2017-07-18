using LGU.Entities.Core;
using LGU.EntityProcesses.Core;
using LGU.Processes;
using System;

namespace LGU.EntityManagers.Core
{
    public class PersonNameManager : IPersonNameManager
    {
        private IConstructPersonMiddleInitials ConstructPersonMiddleInitials { get; }
        private IConstructPersonFullName ConstructPersonFullName { get; }
        private IConstructPersonInformalFullName ConstructPersonInformalFullName { get; }

        public PersonNameManager(IConstructPersonFullName constructPersonFullName, IConstructPersonInformalFullName constructPersonInformalFullName, IConstructPersonMiddleInitials constructPersonMiddleInitials)
        {
            ConstructPersonFullName = constructPersonFullName;
            ConstructPersonInformalFullName = constructPersonInformalFullName;
            ConstructPersonMiddleInitials = constructPersonMiddleInitials;
        }

        public IProcessResult<string> ConstructFullName(Person person)
        {
            ConstructPersonFullName.Person = person;
            return ConstructPersonFullName.Execute();
        }

        public IProcessResult<string> ConstructInformalFullName(Person person)
        {
            throw new NotImplementedException();
        }

        public IProcessResult<string> ConstructMiddleInitials(Person person)
        {
            ConstructPersonMiddleInitials.Person = person;
            return ConstructPersonMiddleInitials.Execute();
        }
    }
}

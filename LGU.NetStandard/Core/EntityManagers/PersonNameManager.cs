using LGU.Core.Entities;
using LGU.Core.EntityProcesses;

namespace LGU.Core.EntityManagers
{
    public class PersonNameManager : IPersonNameManager
    {
        public string ConstructFullName(Person person)
        {
            if (person != null)
            {
                using (var process = new ConstructPersonFullName(person))
                {
                    return process.Execute();
                }
            }
            else
            {
                return null;
            }
        }

        public string ConstructInformalFullName(Person person)
        {
            if (person != null)
            {
                using (var process = new ConstructPersonInformalFullName(person))
                {
                    return process.Execute();
                }
            }
            else
            {
                return null;
            }
        }

        public string ConstructMiddleIntials(Person person)
        {
            if (person != null)
            {
                using (var process = new ConstructPersonMiddleInitials(person, PersonOptions.Default))
                {
                    return process.Execute();
                }
            }
            else
            {
                return null;
            }
        }
    }
}

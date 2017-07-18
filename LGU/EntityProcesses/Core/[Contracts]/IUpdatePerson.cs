using LGU.Entities.Core;
using LGU.Processes;

namespace LGU.EntityProcesses.Core
{
    public interface IUpdatePerson : IProcess<Person>
    {
        Person Person { get; set; }
    }
}

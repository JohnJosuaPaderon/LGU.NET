using LGU.Entities.Core;
using LGU.Processes;

namespace LGU.EntityProcesses.Core
{
    public interface IGetPersonById : IProcess<Person>
    {
        long PersonId { get; set; }
    }
}

using LGU.Entities.Core;
using LGU.Processes;

namespace LGU.EntityProcesses.Core
{
    public interface IGetPersonById : IProcess<IPerson>
    {
        long PersonId { get; set; }
    }
}

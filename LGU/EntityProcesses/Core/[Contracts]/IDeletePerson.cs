using LGU.Entities.Core;
using LGU.Processes;

namespace LGU.EntityProcesses.Core
{
    public interface IDeletePerson : IProcess<IPerson>
    {
        IPerson Person { get; set; }
    }
}

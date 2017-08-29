using LGU.Entities.Core;
using LGU.Processes;

namespace LGU.EntityProcesses.Core
{
    public interface IUpdatePerson : IProcess<IPerson>
    {
        IPerson Person { get; set; }
    }
}

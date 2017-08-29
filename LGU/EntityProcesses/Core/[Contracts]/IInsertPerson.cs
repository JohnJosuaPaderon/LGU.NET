using LGU.Entities.Core;
using LGU.Processes;

namespace LGU.EntityProcesses.Core
{
    public interface IInsertPerson : IProcess<IPerson>
    {
        IPerson Person { get; set; }
    }
}

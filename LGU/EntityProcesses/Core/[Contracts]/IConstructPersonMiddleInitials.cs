using LGU.Entities.Core;
using LGU.Processes;

namespace LGU.EntityProcesses.Core
{
    public interface IConstructPersonMiddleInitials : IProcess<string>
    {
        Person Person { get; set; }
    }
}

using LGU.Entities.Core;
using LGU.Processes;

namespace LGU.EntityProcesses.Core
{
    public interface IConstructPersonFullName : IProcess<string>
    {
        Person Person { get; set; }
    }
}

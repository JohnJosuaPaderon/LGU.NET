using LGU.Entities.Core;
using LGU.Processes;

namespace LGU.EntityProcesses.Core
{
    public interface IGetModuleById : IProcess<Module>
    {
        short ModuleId { get; set; }
    }
}

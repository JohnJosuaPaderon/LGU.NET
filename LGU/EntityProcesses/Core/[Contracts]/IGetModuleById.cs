using LGU.Entities.Core;
using LGU.Processes;

namespace LGU.EntityProcesses.Core
{
    public interface IGetModuleById : IProcess<IModule>
    {
        short ModuleId { get; set; }
    }
}

using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IUpdateApplicationDocument : IProcess<IApplicationDocument>
    {
        IApplicationDocument ApplicationDocument { get; set; }
    }
}

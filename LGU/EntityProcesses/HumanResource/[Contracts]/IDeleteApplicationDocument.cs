using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IDeleteApplicationDocument : IProcess<IApplicationDocument>
    {
        IApplicationDocument ApplicationDocument { get; set; }
    }
}

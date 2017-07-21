using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertApplicationDocument : IProcess<ApplicationDocument>
    {
        ApplicationDocument ApplicationDocument { get; set; }
    }
}

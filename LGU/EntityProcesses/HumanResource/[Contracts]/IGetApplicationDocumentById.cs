using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetApplicationDocumentById : IProcess<IApplicationDocument>
    {
        long ApplicationDocumentId { get; set; }
    }
}

using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetApplicationDocumentById : IProcess<ApplicationDocument>
    {
        long ApplicationDocumentId { get; set; }
    }
}

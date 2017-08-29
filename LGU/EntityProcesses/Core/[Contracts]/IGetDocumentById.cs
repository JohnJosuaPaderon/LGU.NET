using LGU.Entities.Core;
using LGU.Processes;

namespace LGU.EntityProcesses.Core
{
    public interface IGetDocumentById : IProcess<IDocument>
    {
        long DocumentId { get; set; }
    }
}

using LGU.Entities.Core;
using LGU.Processes;

namespace LGU.EntityProcesses.Core
{
    public interface IGetDocumentById : IProcess<Document>
    {
        long DocumentId { get; set; }
    }
}

using LGU.Entities.Core;
using LGU.Processes;

namespace LGU.EntityProcesses.Core
{
    public interface IUpdateDocument : IProcess<Document>
    {
        Document Document { get; set; }
    }
}

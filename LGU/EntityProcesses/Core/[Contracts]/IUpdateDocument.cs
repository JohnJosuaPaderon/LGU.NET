using LGU.Entities.Core;
using LGU.Processes;

namespace LGU.EntityProcesses.Core
{
    public interface IUpdateDocument : IProcess<IDocument>
    {
        IDocument Document { get; set; }
    }
}

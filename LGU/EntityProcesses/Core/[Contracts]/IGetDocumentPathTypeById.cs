using LGU.Entities.Core;
using LGU.Processes;

namespace LGU.EntityProcesses.Core
{
    public interface IGetDocumentPathTypeById : IProcess<IDocumentPathType>
    {
        short DocumentPathTypeId { get; set; }
    }
}

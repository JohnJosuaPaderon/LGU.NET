using LGU.Entities.Core;
using LGU.Processes;

namespace LGU.EntityProcesses.Core
{
    public interface IGetDocumentPathTypeById : IProcess<DocumentPathType>
    {
        short DocumentPathTypeId { get; set; }
    }
}

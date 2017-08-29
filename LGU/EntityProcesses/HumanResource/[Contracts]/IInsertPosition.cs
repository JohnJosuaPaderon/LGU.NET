using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertPosition : IProcess<IPosition>
    {
        IPosition Position { get; set; }
    }
}

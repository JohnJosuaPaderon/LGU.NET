using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertPosition : IProcess<Position>
    {
        Position Position { get; set; }
    }
}

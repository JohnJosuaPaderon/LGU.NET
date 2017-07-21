using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IUpdatePosition : IProcess<Position>
    {
        Position Position { get; set; }
    }
}

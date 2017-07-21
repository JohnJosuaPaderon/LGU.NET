using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IDeletePosition : IProcess<Position>
    {
        Position Position { get; set; }
    }
}

using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetPositionById : IProcess<Position>
    {
        int PositionId { get; set; }
    }
}

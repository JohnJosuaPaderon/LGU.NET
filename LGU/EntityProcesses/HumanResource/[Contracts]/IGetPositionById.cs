using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetPositionById : IProcess<IPosition>
    {
        int PositionId { get; set; }
    }
}

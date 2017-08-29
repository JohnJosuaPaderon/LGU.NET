using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IDeletePosition : IProcess<IPosition>
    {
        IPosition Position { get; set; }
    }
}

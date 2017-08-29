using LGU.Entities.Core;
using LGU.Processes;

namespace LGU.EntityProcesses.Core
{
    public interface IGetGenderById : IProcess<IGender>
    {
        short GenderId { get; set; }
    }
}

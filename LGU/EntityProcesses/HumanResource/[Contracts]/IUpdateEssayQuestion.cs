using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IUpdateEssayQuestion : IProcess<IEssayQuestion>
    {
        IEssayQuestion EssayQuestion { get; set; }
    }
}

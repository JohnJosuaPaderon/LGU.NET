using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IUpdateEssayQuestion : IProcess<EssayQuestion>
    {
        EssayQuestion EssayQuestion { get; set; }
    }
}

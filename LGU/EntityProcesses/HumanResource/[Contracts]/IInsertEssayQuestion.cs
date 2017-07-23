using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertEssayQuestion : IProcess<EssayQuestion>
    {
        EssayQuestion EssayQuestion { get; set; }
    }
}

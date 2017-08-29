using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertEssayQuestion : IProcess<IEssayQuestion>
    {
        IEssayQuestion EssayQuestion { get; set; }
    }
}

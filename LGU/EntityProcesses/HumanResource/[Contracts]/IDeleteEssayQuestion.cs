using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IDeleteEssayQuestion : IProcess<EssayQuestion>
    {
        EssayQuestion EssayQuestion { get; set; }
    }
}

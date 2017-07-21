using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IUpdateApplication : IProcess<Application>
    {
        Application Application { get; set; }
    }
}

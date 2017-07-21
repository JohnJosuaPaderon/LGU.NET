using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IDeleteApplication : IProcess<Application>
    {
        Application Application { get; set; }
    }
}

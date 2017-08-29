using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IDeleteApplication : IProcess<IApplication>
    {
        IApplication Application { get; set; }
    }
}

using LGU.Entities.Core;
using LGU.Processes;

namespace LGU.EntityProcesses.Core
{
    public interface ILoginUser : IProcess<User>
    {
        UserCredentials UserCredentials { get; set; }
    }
}
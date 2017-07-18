using LGU.Entities.Core;
using LGU.Processes;

namespace LGU.EntityProcesses.Core
{
    public interface IDeleteUser : IProcess<User>
    {
        User User { get; set; }
    }
}

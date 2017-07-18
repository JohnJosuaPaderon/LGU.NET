using LGU.Entities.Core;
using LGU.Processes;

namespace LGU.EntityProcesses.Core
{
    public interface IGetUserById : IProcess<User>
    {
        long UserId { get; set; }
    }
}

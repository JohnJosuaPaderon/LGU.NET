using LGU.Entities.Core;
using LGU.Processes;

namespace LGU.EntityProcesses.Core
{
    public interface IGetUserStatusById : IProcess<UserStatus>
    {
        short UserStatusId { get; set; }
    }
}

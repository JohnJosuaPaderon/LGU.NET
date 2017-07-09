using LGU.Entities.Core;

namespace LGU.EntityProcesses.Core
{
    public interface IGetUserById : IDataProcess<User>
    {
        long UserId { get; set; }
    }
}

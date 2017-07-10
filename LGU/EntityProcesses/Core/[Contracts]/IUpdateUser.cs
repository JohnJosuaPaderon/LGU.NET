using LGU.Entities.Core;

namespace LGU.EntityProcesses.Core
{
    public interface IUpdateUser : IDataProcess<User>
    {
        User User { get; set; }
    }
}

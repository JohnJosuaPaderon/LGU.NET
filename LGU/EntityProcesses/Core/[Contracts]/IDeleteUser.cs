using LGU.Entities.Core;

namespace LGU.EntityProcesses.Core
{
    public interface IDeleteUser : IDataProcess<User>
    {
        User User { get; set; }
    }
}

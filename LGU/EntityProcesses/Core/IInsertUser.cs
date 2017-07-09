using LGU.Entities.Core;

namespace LGU.EntityProcesses.Core
{
    public interface IInsertUser : IDataProcess<User>
    {
        User User { get; set; }
    }
}

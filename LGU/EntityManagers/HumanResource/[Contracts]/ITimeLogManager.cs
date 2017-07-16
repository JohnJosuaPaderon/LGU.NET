using LGU.Entities;
using LGU.Entities.HumanResource;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public interface ITimeLogManager : IEntityManager<TimeLog, long>
    {
        IDataProcessResult<TimeLog> Log(Employee employee);
        Task<IDataProcessResult<TimeLog>> LogAsync(Employee employee);
        Task<IDataProcessResult<TimeLog>> LogAsync(Employee employee, CancellationToken cancellationToken);
    }
}

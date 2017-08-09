using LGU.Entities;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public interface ITimeLogManager : IEntityManager<TimeLog, long>
    {
        IProcessResult<TimeLog> Log(Employee employee);
        Task<IProcessResult<TimeLog>> LogAsync(Employee employee);
        Task<IProcessResult<TimeLog>> LogAsync(Employee employee, CancellationToken cancellationToken);
        IEnumerableProcessResult<TimeLog> GetActualListByEmployeeCutOff(Employee employee, ValueRange<DateTime> cutOff);
        Task<IEnumerableProcessResult<TimeLog>> GetActualListByEmployeeCutOffAsync(Employee employee, ValueRange<DateTime> cutOff);
        Task<IEnumerableProcessResult<TimeLog>> GetActualListByEmployeeCutOffAsync(Employee employee, ValueRange<DateTime> cutOff, CancellationToken cancellationToken);
    }
}

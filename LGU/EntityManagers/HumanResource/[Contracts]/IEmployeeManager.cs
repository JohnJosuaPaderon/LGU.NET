using LGU.Entities;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public interface IEmployeeManager : IEntityManager<Employee, long>
    {
        IEnumerableProcessResult<Employee> Search(string searchKey);
        Task<IEnumerableProcessResult<Employee>> SearchAsync(string searchKey);
        Task<IEnumerableProcessResult<Employee>> SearchAsync(string searchKey, CancellationToken cancellationToken);
        IEnumerableProcessResult<Employee> GetListWithTimeLog(ValueRange<DateTime> cutOff);
        Task<IEnumerableProcessResult<Employee>> GetListWithTimeLogAsync(ValueRange<DateTime> cutOff);
        Task<IEnumerableProcessResult<Employee>> GetListWithTimeLogAsync(ValueRange<DateTime> cutOff, CancellationToken cancellationToken);
        IEnumerableProcessResult<Employee> SearchWithTimeLog(string searchKey, ValueRange<DateTime> cutOff);
        Task<IEnumerableProcessResult<Employee>> SearchWithTimeLogAsync(string searchKey, ValueRange<DateTime> cutOff);
        Task<IEnumerableProcessResult<Employee>> SearchWithTimeLogAsync(string searchKey, ValueRange<DateTime> cutOff, CancellationToken cancellationToken);
    }
}

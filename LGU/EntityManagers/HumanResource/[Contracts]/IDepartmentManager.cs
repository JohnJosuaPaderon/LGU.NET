using LGU.Entities;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public interface IDepartmentManager : IEntityManager<Department, int>
    {
        IEnumerableProcessResult<Department> Search(string searchKey);
        Task<IEnumerableProcessResult<Department>> SearchAsync(string searchKey);
        Task<IEnumerableProcessResult<Department>> SearchAsync(string searchKey, CancellationToken cancellationToken);
        IEnumerableProcessResult<Department> GetListWithTimeLog(ValueRange<DateTime> cutOff);
        Task<IEnumerableProcessResult<Department>> GetListWithTimeLogAsync(ValueRange<DateTime> cutOff);
        Task<IEnumerableProcessResult<Department>> GetListWithTimeLogAsync(ValueRange<DateTime> cutOff, CancellationToken cancellationToken);
    }
}

using LGU.Entities;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public interface IDepartmentManager : IEntityManager<IDepartment, int>
    {
        IEnumerableProcessResult<IDepartment> Search(string searchKey);
        Task<IEnumerableProcessResult<IDepartment>> SearchAsync(string searchKey);
        Task<IEnumerableProcessResult<IDepartment>> SearchAsync(string searchKey, CancellationToken cancellationToken);
        IEnumerableProcessResult<IDepartment> GetListWithTimeLog(ValueRange<DateTime> cutOff);
        Task<IEnumerableProcessResult<IDepartment>> GetListWithTimeLogAsync(ValueRange<DateTime> cutOff);
        Task<IEnumerableProcessResult<IDepartment>> GetListWithTimeLogAsync(ValueRange<DateTime> cutOff, CancellationToken cancellationToken);
    }
}

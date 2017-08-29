using LGU.Entities;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public interface IEmployeeManager : IEntityManager<IEmployee, long>
    {
        IEnumerableProcessResult<IEmployee> Search(string searchKey);
        Task<IEnumerableProcessResult<IEmployee>> SearchAsync(string searchKey);
        Task<IEnumerableProcessResult<IEmployee>> SearchAsync(string searchKey, CancellationToken cancellationToken);
        IEnumerableProcessResult<IEmployee> GetListWithTimeLog(ValueRange<DateTime> cutOff);
        Task<IEnumerableProcessResult<IEmployee>> GetListWithTimeLogAsync(ValueRange<DateTime> cutOff);
        Task<IEnumerableProcessResult<IEmployee>> GetListWithTimeLogAsync(ValueRange<DateTime> cutOff, CancellationToken cancellationToken);
        IEnumerableProcessResult<IEmployee> SearchWithTimeLog(string searchKey, ValueRange<DateTime> cutOff);
        Task<IEnumerableProcessResult<IEmployee>> SearchWithTimeLogAsync(string searchKey, ValueRange<DateTime> cutOff);
        Task<IEnumerableProcessResult<IEmployee>> SearchWithTimeLogAsync(string searchKey, ValueRange<DateTime> cutOff, CancellationToken cancellationToken);
        IEnumerableProcessResult<IEmployee> GetListWithTimeLogByDepartment(ValueRange<DateTime> cutOff, IDepartment department);
        Task<IEnumerableProcessResult<IEmployee>> GetListWithTimeLogByDepartmentAsync(ValueRange<DateTime> cutOff, IDepartment department);
        Task<IEnumerableProcessResult<IEmployee>> GetListWithTimeLogByDepartmentAsync(ValueRange<DateTime> cutOff, IDepartment department, CancellationToken cancellationToken);
    }
}

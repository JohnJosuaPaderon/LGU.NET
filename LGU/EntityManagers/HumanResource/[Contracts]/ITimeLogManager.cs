using LGU.Entities;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public interface ITimeLogManager : IEntityManager<ITimeLog, long>
    {
        IProcessResult<ITimeLog> Log(IEmployee employee);
        Task<IProcessResult<ITimeLog>> LogAsync(IEmployee employee);
        Task<IProcessResult<ITimeLog>> LogAsync(IEmployee employee, CancellationToken cancellationToken);
        IEnumerableProcessResult<ITimeLog> GetActualListByEmployeeCutOff(IEmployee employee, ValueRange<DateTime> cutOff);
        Task<IEnumerableProcessResult<ITimeLog>> GetActualListByEmployeeCutOffAsync(IEmployee employee, ValueRange<DateTime> cutOff);
        Task<IEnumerableProcessResult<ITimeLog>> GetActualListByEmployeeCutOffAsync(IEmployee employee, ValueRange<DateTime> cutOff, CancellationToken cancellationToken);
        IEnumerableProcessResult<ITimeLog> GetListByCutOff(ValueRange<DateTime> cutOff);
        Task<IEnumerableProcessResult<ITimeLog>> GetListByCutOffAsync(ValueRange<DateTime> cutOff);
        Task<IEnumerableProcessResult<ITimeLog>> GetListByCutOffAsync(ValueRange<DateTime> cutOff, CancellationToken cancellationToken);
        IEnumerableProcessResult<ITimeLog> GetListByDepartmentCutOff(IDepartment department, ValueRange<DateTime> cutOff);
        Task<IEnumerableProcessResult<ITimeLog>> GetListByDepartmentCutOffAsync(IDepartment department, ValueRange<DateTime> cutOff);
        Task<IEnumerableProcessResult<ITimeLog>> GetListByDepartmentCutOffAsync(IDepartment department, ValueRange<DateTime> cutOff, CancellationToken cancellationToken);
        IEnumerableProcessResult<ITimeLog> GetListByEmployeeCutOff(IEmployee employee, ValueRange<DateTime> cutOff);
        Task<IEnumerableProcessResult<ITimeLog>> GetListByEmployeeCutOffAsync(IEmployee employee, ValueRange<DateTime> cutOff);
        Task<IEnumerableProcessResult<ITimeLog>> GetListByEmployeeCutOffAsync(IEmployee employee, ValueRange<DateTime> cutOff, CancellationToken cancellationToken);
    }
}

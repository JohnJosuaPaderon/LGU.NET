using LGU.Entities.HumanResource;
using LGU.Processes;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public interface IEmployeeFingerPrintSetManager : IDataManager<EmployeeFingerPrintSet>
    {
        IProcessResult<EmployeeFingerPrintSet> GetById(Employee employee);
        Task<IProcessResult<EmployeeFingerPrintSet>> GetByIdAsync(Employee employee);
        Task<IProcessResult<EmployeeFingerPrintSet>> GetByIdAsync(Employee employee, CancellationToken cancellationToken);
        IEnumerableProcessResult<EmployeeFingerPrintSet> GetUpdatedList(DateTime logDate);
        Task<IEnumerableProcessResult<EmployeeFingerPrintSet>> GetUpdatedListAsync(DateTime logDate);
        Task<IEnumerableProcessResult<EmployeeFingerPrintSet>> GetUpdatedListAsync(DateTime logDate, CancellationToken cancellationToken);
    }
}

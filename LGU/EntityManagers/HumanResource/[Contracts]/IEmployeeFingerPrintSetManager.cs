using LGU.Entities.HumanResource;
using LGU.Processes;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public interface IEmployeeFingerPrintSetManager : IDataManager<IEmployeeFingerPrintSet>
    {
        IProcessResult<IEmployeeFingerPrintSet> GetById(IEmployee employee);
        Task<IProcessResult<IEmployeeFingerPrintSet>> GetByIdAsync(IEmployee employee);
        Task<IProcessResult<IEmployeeFingerPrintSet>> GetByIdAsync(IEmployee employee, CancellationToken cancellationToken);
        IEnumerableProcessResult<IEmployeeFingerPrintSet> GetUpdatedList(DateTime logDate);
        Task<IEnumerableProcessResult<IEmployeeFingerPrintSet>> GetUpdatedListAsync(DateTime logDate);
        Task<IEnumerableProcessResult<IEmployeeFingerPrintSet>> GetUpdatedListAsync(DateTime logDate, CancellationToken cancellationToken);
    }
}

using LGU.Entities.HumanResource;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public interface IEmployeeFingerPrintSetManager : IDataManager<EmployeeFingerPrintSet>
    {
        IDataProcessResult<EmployeeFingerPrintSet> GetById(Employee employee);
        Task<IDataProcessResult<EmployeeFingerPrintSet>> GetByIdAsync(Employee employee);
        Task<IDataProcessResult<EmployeeFingerPrintSet>> GetByIdAsync(Employee employee, CancellationToken cancellationToken);
    }
}

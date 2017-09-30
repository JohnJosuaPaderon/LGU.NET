using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public interface IPayrollTypeManager
    {
        IProcessResult<IPayrollType> GetById(short payrollTypeId);
        Task<IProcessResult<IPayrollType>> GetByIdAsync(short payrollTypeId);
        Task<IProcessResult<IPayrollType>> GetByIdAsync(short payrollTypeId, CancellationToken cancellationToken);
        IEnumerableProcessResult<IPayrollType> GetList();
        Task<IEnumerableProcessResult<IPayrollType>> GetListAsync();
        Task<IEnumerableProcessResult<IPayrollType>> GetListAsync(CancellationToken cancellationToken);
    }
}

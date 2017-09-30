using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public interface IPayrollCutOffManager
    {
        IProcessResult<IPayrollCutOff> GetById(short payrollCutOffId);
        Task<IProcessResult<IPayrollCutOff>> GetByIdAsync(short payrollCutOffId);
        Task<IProcessResult<IPayrollCutOff>> GetByIdAsync(short payrollCutOffId, CancellationToken cancellationToken);
        IEnumerableProcessResult<IPayrollCutOff> GetList();
        Task<IEnumerableProcessResult<IPayrollCutOff>> GetListAsync();
        Task<IEnumerableProcessResult<IPayrollCutOff>> GetListAsync(CancellationToken cancellationToken);
    }
}

using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public interface IEmployeeWorkdayScheduleManager
    {
        IProcessResult<IEmployeeWorkdaySchedule> Delete(IEmployeeWorkdaySchedule employeeWorkdaySchedule);
        Task<IProcessResult<IEmployeeWorkdaySchedule>> DeleteAsync(IEmployeeWorkdaySchedule employeeWorkdaySchedule);
        Task<IProcessResult<IEmployeeWorkdaySchedule>> DeleteAsync(IEmployeeWorkdaySchedule employeeWorkdaySchedule, CancellationToken cancellationToken);
        IProcessResult<IEmployeeWorkdaySchedule> GetById(long employeeWorkdayScheduleId);
        Task<IProcessResult<IEmployeeWorkdaySchedule>> GetByIdAsync(long employeeWorkdayScheduleId);
        Task<IProcessResult<IEmployeeWorkdaySchedule>> GetByIdAsync(long employeeWorkdayScheduleId, CancellationToken cancellationToken);
        IProcessResult<IEmployeeWorkdaySchedule> Insert(IEmployeeWorkdaySchedule employeeWorkdaySchedule);
        Task<IProcessResult<IEmployeeWorkdaySchedule>> InsertAsync(IEmployeeWorkdaySchedule employeeWorkdaySchedule);
        Task<IProcessResult<IEmployeeWorkdaySchedule>> InsertAsync(IEmployeeWorkdaySchedule employeeWorkdaySchedule, CancellationToken cancellationToken);
        IProcessResult<IEmployeeWorkdaySchedule> Update(IEmployeeWorkdaySchedule employeeWorkdaySchedule);
        Task<IProcessResult<IEmployeeWorkdaySchedule>> UpdateAsync(IEmployeeWorkdaySchedule employeeWorkdaySchedule);
        Task<IProcessResult<IEmployeeWorkdaySchedule>> UpdateAsync(IEmployeeWorkdaySchedule employeeWorkdaySchedule, CancellationToken cancellationToken);
    }
}

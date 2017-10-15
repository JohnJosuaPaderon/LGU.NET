using LGU.Entities.HumanResource;
using LGU.Processes;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public interface IEmployeeFlexWorkScheduleManager
    {
        IProcessResult<IEmployeeFlexWorkSchedule> Insert(IEmployeeFlexWorkSchedule employeeFlexWorkSchedule);
        Task<IProcessResult<IEmployeeFlexWorkSchedule>> InsertAsync(IEmployeeFlexWorkSchedule employeeFlexWorkSchedule);
        Task<IProcessResult<IEmployeeFlexWorkSchedule>> InsertAsync(IEmployeeFlexWorkSchedule employeeFlexWorkSchedule, CancellationToken cancellationToken);
        IProcessResult<IEmployeeFlexWorkSchedule> GetByDate(DateTime date);
        Task<IProcessResult<IEmployeeFlexWorkSchedule>> GetByDateAsync(DateTime date);
        Task<IProcessResult<IEmployeeFlexWorkSchedule>> GetByDateAsync(DateTime date, CancellationToken cancellationToken);
        IProcessResult<IEmployeeFlexWorkSchedule> GetById(long employeeFlexWorkScheduleId);
        Task<IProcessResult<IEmployeeFlexWorkSchedule>> GetByIdAsync(long employeeFlexWorkScheduleId);
        Task<IProcessResult<IEmployeeFlexWorkSchedule>> GetByIdAsync(long employeeFlexWorkScheduleId, CancellationToken cancellationToken);
        IEnumerableProcessResult<IEmployeeFlexWorkSchedule> GetListByEmployee(IEmployee employee);
        Task<IEnumerableProcessResult<IEmployeeFlexWorkSchedule>> GetListByEmployeeAsync(IEmployee employee);
        Task<IEnumerableProcessResult<IEmployeeFlexWorkSchedule>> GetListByEmployeeAsync(IEmployee employee, CancellationToken cancellationToken);
    }
}

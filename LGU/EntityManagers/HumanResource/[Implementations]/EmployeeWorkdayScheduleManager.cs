using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class EmployeeWorkdayScheduleManager : EntityManagerBase<IEmployeeWorkdaySchedule, long>, IEmployeeWorkdayScheduleManager
    {
        private const string MESSAGE_INVALID = "Invalid employee workday schedule.";
        private const string MESSAGE_INVALID_IDENTIFIER = "Invalid employee workday schedule identifier.";
        private const string MESSAGE_INVALID_EMPLOYEE = "Invalid employee.";

        public EmployeeWorkdayScheduleManager(
            IDeleteEmployeeWorkdaySchedule delete,
            IGetEmployeeWorkdayScheduleById getById,
            IInsertEmployeeWorkdaySchedule insert,
            IUpdateEmployeeWorkdaySchedule update,
            IGetEmployeeWorkdayScheduleByEmployee getByEmployee)
        {
            _Delete = delete;
            _GetById = getById;
            _Insert = insert;
            _Update = update;
            _GetByEmployee = getByEmployee;

            _InvalidResult = new ProcessResult<IEmployeeWorkdaySchedule>(ProcessResultStatus.Failed, MESSAGE_INVALID);
            _InvalidIdentifierResult = new ProcessResult<IEmployeeWorkdaySchedule>(ProcessResultStatus.Failed, MESSAGE_INVALID_IDENTIFIER);
            _InvalidEmployeeResult = new ProcessResult<IEmployeeWorkdaySchedule>(ProcessResultStatus.Failed, MESSAGE_INVALID_EMPLOYEE);
        }

        private readonly IDeleteEmployeeWorkdaySchedule _Delete;
        private readonly IGetEmployeeWorkdayScheduleById _GetById;
        private readonly IInsertEmployeeWorkdaySchedule _Insert;
        private readonly IUpdateEmployeeWorkdaySchedule _Update;
        private readonly IGetEmployeeWorkdayScheduleByEmployee _GetByEmployee;
        private readonly IProcessResult<IEmployeeWorkdaySchedule> _InvalidResult;
        private readonly IProcessResult<IEmployeeWorkdaySchedule> _InvalidIdentifierResult;
        private readonly IProcessResult<IEmployeeWorkdaySchedule> _InvalidEmployeeResult;

        public IProcessResult<IEmployeeWorkdaySchedule> Delete(IEmployeeWorkdaySchedule employeeWorkdaySchedule)
        {
            if (employeeWorkdaySchedule != null)
            {
                _Delete.EmployeeWorkdaySchedule = employeeWorkdaySchedule;
                return RemoveIfSuccess(_Delete.Execute());
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IEmployeeWorkdaySchedule>> DeleteAsync(IEmployeeWorkdaySchedule employeeWorkdaySchedule)
        {
            if (employeeWorkdaySchedule != null)
            {
                _Delete.EmployeeWorkdaySchedule = employeeWorkdaySchedule;
                return RemoveIfSuccess(await _Delete.ExecuteAsync());
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IEmployeeWorkdaySchedule>> DeleteAsync(IEmployeeWorkdaySchedule employeeWorkdaySchedule, CancellationToken cancellationToken)
        {
            if (employeeWorkdaySchedule != null)
            {
                _Delete.EmployeeWorkdaySchedule = employeeWorkdaySchedule;
                return RemoveIfSuccess(await _Delete.ExecuteAsync(cancellationToken));
            }
            else
            {
                return _InvalidResult;
            }
        }

        public IProcessResult<IEmployeeWorkdaySchedule> GetById(long employeeWorkdayScheduleId)
        {
            if (employeeWorkdayScheduleId > 0)
            {
                if (StaticSource.ContainsId(employeeWorkdayScheduleId))
                {
                    return new ProcessResult<IEmployeeWorkdaySchedule>(StaticSource[employeeWorkdayScheduleId]);
                }
                else
                {
                    _GetById.EmployeeWorkdayScheduleId = employeeWorkdayScheduleId;
                    return AddUpdateIfSuccess(_GetById.Execute());
                }
            }
            else
            {
                return _InvalidIdentifierResult;
            }
        }

        public async Task<IProcessResult<IEmployeeWorkdaySchedule>> GetByIdAsync(long employeeWorkdayScheduleId)
        {
            if (employeeWorkdayScheduleId > 0)
            {
                if (StaticSource.ContainsId(employeeWorkdayScheduleId))
                {
                    return new ProcessResult<IEmployeeWorkdaySchedule>(StaticSource[employeeWorkdayScheduleId]);
                }
                else
                {
                    _GetById.EmployeeWorkdayScheduleId = employeeWorkdayScheduleId;
                    return AddUpdateIfSuccess(await _GetById.ExecuteAsync());
                }
            }
            else
            {
                return _InvalidIdentifierResult;
            }
        }

        public async Task<IProcessResult<IEmployeeWorkdaySchedule>> GetByIdAsync(long employeeWorkdayScheduleId, CancellationToken cancellationToken)
        {
            if (employeeWorkdayScheduleId > 0)
            {
                if (StaticSource.ContainsId(employeeWorkdayScheduleId))
                {
                    return new ProcessResult<IEmployeeWorkdaySchedule>(StaticSource[employeeWorkdayScheduleId]);
                }
                else
                {
                    _GetById.EmployeeWorkdayScheduleId = employeeWorkdayScheduleId;
                    return AddUpdateIfSuccess(await _GetById.ExecuteAsync(cancellationToken));
                }
            }
            else
            {
                return _InvalidIdentifierResult;
            }
        }

        public IProcessResult<IEmployeeWorkdaySchedule> Insert(IEmployeeWorkdaySchedule employeeWorkdaySchedule)
        {
            if (employeeWorkdaySchedule != null)
            {
                _Insert.EmployeeWorkdaySchedule = employeeWorkdaySchedule;
                return AddIfSuccess(_Insert.Execute());
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IEmployeeWorkdaySchedule>> InsertAsync(IEmployeeWorkdaySchedule employeeWorkdaySchedule)
        {
            if (employeeWorkdaySchedule != null)
            {
                _Insert.EmployeeWorkdaySchedule = employeeWorkdaySchedule;
                return AddIfSuccess(await _Insert.ExecuteAsync());
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IEmployeeWorkdaySchedule>> InsertAsync(IEmployeeWorkdaySchedule employeeWorkdaySchedule, CancellationToken cancellationToken)
        {
            if (employeeWorkdaySchedule != null)
            {
                _Insert.EmployeeWorkdaySchedule = employeeWorkdaySchedule;
                return AddIfSuccess(await _Insert.ExecuteAsync(cancellationToken));
            }
            else
            {
                return _InvalidResult;
            }
        }

        public IProcessResult<IEmployeeWorkdaySchedule> Update(IEmployeeWorkdaySchedule employeeWorkdaySchedule)
        {
            if (employeeWorkdaySchedule != null)
            {
                _Update.EmployeeWorkdaySchedule = employeeWorkdaySchedule;
                return UpdateIfSuccess(_Update.Execute());
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IEmployeeWorkdaySchedule>> UpdateAsync(IEmployeeWorkdaySchedule employeeWorkdaySchedule)
        {
            if (employeeWorkdaySchedule != null)
            {
                _Update.EmployeeWorkdaySchedule = employeeWorkdaySchedule;
                return UpdateIfSuccess(await _Update.ExecuteAsync());
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IEmployeeWorkdaySchedule>> UpdateAsync(IEmployeeWorkdaySchedule employeeWorkdaySchedule, CancellationToken cancellationToken)
        {
            if (employeeWorkdaySchedule != null)
            {
                _Update.EmployeeWorkdaySchedule = employeeWorkdaySchedule;
                return UpdateIfSuccess(await _Update.ExecuteAsync(cancellationToken));
            }
            else
            {
                return _InvalidResult;
            }
        }

        public IProcessResult<IEmployeeWorkdaySchedule> GetByEmployee(IEmployee employee)
        {
            if (employee != null)
            {
                _GetByEmployee.Employee = employee;
                return AddUpdateIfSuccess(_GetByEmployee.Execute());
            }
            else
            {
                return _InvalidEmployeeResult;
            }
        }

        public async Task<IProcessResult<IEmployeeWorkdaySchedule>> GetByEmployeeAsync(IEmployee employee)
        {
            if (employee != null)
            {
                _GetByEmployee.Employee = employee;
                return AddUpdateIfSuccess(await _GetByEmployee.ExecuteAsync());
            }
            else
            {
                return _InvalidEmployeeResult;
            }
        }

        public async Task<IProcessResult<IEmployeeWorkdaySchedule>> GetByEmployeeAsync(IEmployee employee, CancellationToken cancellationToken)
        {
            if (employee != null)
            {
                _GetByEmployee.Employee = employee;
                return AddUpdateIfSuccess(await _GetByEmployee.ExecuteAsync(cancellationToken));
            }
            else
            {
                return _InvalidEmployeeResult;
            }
        }
    }
}

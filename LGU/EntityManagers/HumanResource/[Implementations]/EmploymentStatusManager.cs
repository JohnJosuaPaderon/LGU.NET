﻿using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class EmploymentStatusManager : ManagerBase<EmploymentStatus, short>, IEmploymentStatusManager
    {
        private readonly IGetEmploymentStatusById r_GetEmploymentStatusById;
        private readonly IGetEmploymentStatusList r_GetEmploymentStatusList;

        public EmploymentStatusManager(
            IGetEmploymentStatusById getEmploymentStatusById,
            IGetEmploymentStatusList getEmploymentStatusList)
        {
            r_GetEmploymentStatusById = getEmploymentStatusById;
            r_GetEmploymentStatusList = getEmploymentStatusList;
        }

        public IProcessResult<EmploymentStatus> GetById(short id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<EmploymentStatus>(StaticSource[id]);
                }
                else
                {
                    r_GetEmploymentStatusById.EmploymentStatusId = id;
                    var result = r_GetEmploymentStatusById.Execute();
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<EmploymentStatus>(ProcessResultStatus.Failed, "Invalid employment status identifier.");
            }
        }

        public async Task<IProcessResult<EmploymentStatus>> GetByIdAsync(short id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<EmploymentStatus>(StaticSource[id]);
                }
                else
                {
                    r_GetEmploymentStatusById.EmploymentStatusId = id;
                    var result = await r_GetEmploymentStatusById.ExecuteAsync();
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<EmploymentStatus>(ProcessResultStatus.Failed, "Invalid employment status identifier.");
            }
        }

        public async Task<IProcessResult<EmploymentStatus>> GetByIdAsync(short id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<EmploymentStatus>(StaticSource[id]);
                }
                else
                {
                    r_GetEmploymentStatusById.EmploymentStatusId = id;
                    var result = await r_GetEmploymentStatusById.ExecuteAsync(cancellationToken);
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<EmploymentStatus>(ProcessResultStatus.Failed, "Invalid employment status identifier.");
            }
        }

        public IEnumerableProcessResult<EmploymentStatus> GetList()
        {
            var result = r_GetEmploymentStatusList.Execute();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<EmploymentStatus>> GetListAsync()
        {
            var result = await r_GetEmploymentStatusList.ExecuteAsync();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<EmploymentStatus>> GetListAsync(CancellationToken cancellationToken)
        {
            var result = await r_GetEmploymentStatusList.ExecuteAsync(cancellationToken);
            AddUpdateIfSuccess(result);

            return result;
        }
    }
}
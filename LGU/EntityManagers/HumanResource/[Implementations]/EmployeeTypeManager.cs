using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class EmployeeTypeManager : EntityManagerBase<IEmployeeType, short>, IEmployeeTypeManager
    {
        private readonly IGetEmployeeTypeById r_GetEmployeeTypeById;
        private readonly IGetEmployeeTypeList r_GetEmployeeTypeList;

        public EmployeeTypeManager(
            IGetEmployeeTypeById getEmployeeTypeById,
            IGetEmployeeTypeList getEmployeeTypeList)
        {
            r_GetEmployeeTypeById = getEmployeeTypeById;
            r_GetEmployeeTypeList = getEmployeeTypeList;
        }

        public IProcessResult<IEmployeeType> GetById(short id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IEmployeeType>(StaticSource[id]);
                }
                else
                {
                    r_GetEmployeeTypeById.EmployeeTypeId = id;
                    var result = r_GetEmployeeTypeById.Execute();
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<IEmployeeType>(ProcessResultStatus.Failed, "Invalid employee type identifier.");
            }
        }

        public async Task<IProcessResult<IEmployeeType>> GetByIdAsync(short id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IEmployeeType>(StaticSource[id]);
                }
                else
                {
                    r_GetEmployeeTypeById.EmployeeTypeId = id;
                    var result = await r_GetEmployeeTypeById.ExecuteAsync();
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<IEmployeeType>(ProcessResultStatus.Failed, "Invalid employee type identifier.");
            }
        }

        public async Task<IProcessResult<IEmployeeType>> GetByIdAsync(short id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IEmployeeType>(StaticSource[id]);
                }
                else
                {
                    r_GetEmployeeTypeById.EmployeeTypeId = id;
                    var result = await r_GetEmployeeTypeById.ExecuteAsync(cancellationToken);
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<IEmployeeType>(ProcessResultStatus.Failed, "Invalid employee type identifier.");
            }
        }

        public IEnumerableProcessResult<IEmployeeType> GetList()
        {
            var result = r_GetEmployeeTypeList.Execute();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<IEmployeeType>> GetListAsync()
        {
            var result = await r_GetEmployeeTypeList.ExecuteAsync();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<IEmployeeType>> GetListAsync(CancellationToken cancellationToken)
        {
            var result = await r_GetEmployeeTypeList.ExecuteAsync(cancellationToken);
            AddUpdateIfSuccess(result);

            return result;
        }
    }
}

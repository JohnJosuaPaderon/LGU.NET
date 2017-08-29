using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class PositionManager : ManagerBase<IPosition, int>, IPositionManager
    {
        private readonly IDeletePosition r_DeletePosition;
        private readonly IGetPositionById r_GetPositionById;
        private readonly IGetPositionList r_GetPositionList;
        private readonly IInsertPosition r_InsertPosition;
        private readonly IUpdatePosition r_UpdatePosition;

        public PositionManager(
            IDeletePosition deletePosition,
            IGetPositionById getPositionById,
            IGetPositionList getPositionList,
            IInsertPosition insertPosition,
            IUpdatePosition updatePosition)
        {
            r_DeletePosition = deletePosition;
            r_GetPositionById = getPositionById;
            r_GetPositionList = getPositionList;
            r_InsertPosition = insertPosition;
            r_UpdatePosition = updatePosition;
        }

        public IProcessResult<IPosition> Delete(IPosition data)
        {
            if (data != null)
            {
                r_DeletePosition.Position = data;
                var result = r_DeletePosition.Execute();
                RemoveIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<IPosition>(ProcessResultStatus.Failed, "Invalid position.");
            }
        }

        public async Task<IProcessResult<IPosition>> DeleteAsync(IPosition data)
        {
            if (data != null)
            {
                r_DeletePosition.Position = data;
                var result = await r_DeletePosition.ExecuteAsync();
                RemoveIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<IPosition>(ProcessResultStatus.Failed, "Invalid position.");
            }
        }

        public async Task<IProcessResult<IPosition>> DeleteAsync(IPosition data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_DeletePosition.Position = data;
                var result = await r_DeletePosition.ExecuteAsync(cancellationToken);
                RemoveIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<IPosition>(ProcessResultStatus.Failed, "Invalid position.");
            }
        }

        public IProcessResult<IPosition> GetById(int id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IPosition>(StaticSource[id]);
                }
                else
                {
                    r_GetPositionById.PositionId = id;
                    var result = r_GetPositionById.Execute();
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<IPosition>(ProcessResultStatus.Failed, "Invalid position identifier.");
            }
        }

        public async Task<IProcessResult<IPosition>> GetByIdAsync(int id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IPosition>(StaticSource[id]);
                }
                else
                {
                    r_GetPositionById.PositionId = id;
                    var result = await r_GetPositionById.ExecuteAsync();
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<IPosition>(ProcessResultStatus.Failed, "Invalid position identifier.");
            }
        }

        public async Task<IProcessResult<IPosition>> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IPosition>(StaticSource[id]);
                }
                else
                {
                    r_GetPositionById.PositionId = id;
                    var result = await r_GetPositionById.ExecuteAsync(cancellationToken);
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<IPosition>(ProcessResultStatus.Failed, "Invalid position identifier.");
            }
        }

        public IEnumerableProcessResult<IPosition> GetList()
        {
            var result = r_GetPositionList.Execute();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<IPosition>> GetListAsync()
        {
            var result = await r_GetPositionList.ExecuteAsync();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<IPosition>> GetListAsync(CancellationToken cancellationToken)
        {
            var result = await r_GetPositionList.ExecuteAsync(cancellationToken);
            AddUpdateIfSuccess(result);

            return result;
        }

        public IProcessResult<IPosition> Insert(IPosition data)
        {
            if (data != null)
            {
                r_InsertPosition.Position = data;
                var result = r_InsertPosition.Execute();
                AddIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<IPosition>(ProcessResultStatus.Failed, "Invalid position.");
            }
        }

        public async Task<IProcessResult<IPosition>> InsertAsync(IPosition data)
        {
            if (data != null)
            {
                r_InsertPosition.Position = data;
                var result = await r_InsertPosition.ExecuteAsync();
                AddIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<IPosition>(ProcessResultStatus.Failed, "Invalid position.");
            }
        }

        public async Task<IProcessResult<IPosition>> InsertAsync(IPosition data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_InsertPosition.Position = data;
                var result = await r_InsertPosition.ExecuteAsync(cancellationToken);
                AddIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<IPosition>(ProcessResultStatus.Failed, "Invalid position.");
            }
        }

        public IProcessResult<IPosition> Update(IPosition data)
        {
            if (data != null)
            {
                r_UpdatePosition.Position = data;
                var result = r_UpdatePosition.Execute();
                UpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<IPosition>(ProcessResultStatus.Failed, "Invalid position.");
            }
        }

        public async Task<IProcessResult<IPosition>> UpdateAsync(IPosition data)
        {
            if (data != null)
            {
                r_UpdatePosition.Position = data;
                var result = await r_UpdatePosition.ExecuteAsync();
                UpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<IPosition>(ProcessResultStatus.Failed, "Invalid position.");
            }
        }

        public async Task<IProcessResult<IPosition>> UpdateAsync(IPosition data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_UpdatePosition.Position = data;
                var result = await r_UpdatePosition.ExecuteAsync(cancellationToken);
                UpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<IPosition>(ProcessResultStatus.Failed, "Invalid position.");
            }
        }
    }
}

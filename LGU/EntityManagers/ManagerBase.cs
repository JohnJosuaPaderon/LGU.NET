using LGU.Entities;
using LGU.Processes;
using System;
using System.Linq;

namespace LGU.EntityManagers
{
    public abstract class ManagerBase<T, TIdentifier>
        where T : IEntity<TIdentifier>
    {
        protected static EntityCollection<T, TIdentifier> StaticSource { get; } = new EntityCollection<T, TIdentifier>();

        protected IProcessResult<T> AddIfSuccess(IProcessResult<T> result)
        {
            InvokeIfSuccess(result.Status, () => StaticSource.Add(result.Data));
            return result;
        }

        protected IEnumerableProcessResult<T> AddIfSuccess(IEnumerableProcessResult<T> result)
        {
            InvokeIfSuccessAndListNotEmpty(result, data => StaticSource.Add(data));
            return result;
        }

        protected IProcessResult<T> UpdateIfSuccess(IProcessResult<T> result)
        {
            InvokeIfSuccess(result.Status, () => StaticSource.Update(result.Data));
            return result;
        }

        protected IEnumerableProcessResult<T> UpdateIfSuccess(IEnumerableProcessResult<T> result)
        {
            InvokeIfSuccessAndListNotEmpty(result, data => StaticSource.Update(data));
            return result;
        }

        protected IProcessResult<T> AddUpdateIfSuccess(IProcessResult<T> result)
        {
            InvokeIfSuccess(result.Status, () => StaticSource.AddUpdate(result.Data));
            return result;
        }

        protected IEnumerableProcessResult<T> AddUpdateIfSuccess(IEnumerableProcessResult<T> result)
        {
            InvokeIfSuccessAndListNotEmpty(result, data => StaticSource.AddUpdate(data));
            return result;
        }

        protected IProcessResult<T> RemoveIfSuccess(IProcessResult<T> result)
        {
            InvokeIfSuccess(result.Status, () => StaticSource.Remove(result.Data));
            return result;
        }

        protected IEnumerableProcessResult<T> RemoveIfSuccess(IEnumerableProcessResult<T> result)
        {
            InvokeIfSuccessAndListNotEmpty(result, data => StaticSource.Remove(data));
            return result;
        }

        protected void InvokeIfSuccess(ProcessResultStatus status, Action expression)
        {
            if (status == ProcessResultStatus.Success)
            {
                expression();
            }
        }

        protected void InvokeIfSuccessAndListNotEmpty(IEnumerableProcessResult<T> result, Action<T> expression)
        {
            if (result.Status == ProcessResultStatus.Success && result.DataList != null && result.DataList.Any())
            {
                foreach (var item in result.DataList)
                {
                    expression(item);
                }
            }
        }
    }
}

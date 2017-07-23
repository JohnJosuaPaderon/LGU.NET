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

        protected void AddIfSuccess(IProcessResult<T> result)
        {
            InvokeIfSuccess(result.Status, () => StaticSource.Add(result.Data));
        }

        protected void AddIfSuccess(IEnumerableProcessResult<T> result)
        {
            InvokeIfSuccessAndListNotEmpty(result, data => StaticSource.Add(data));
        }

        protected void UpdateIfSuccess(IProcessResult<T> result)
        {
            InvokeIfSuccess(result.Status, () => StaticSource.Update(result.Data));
        }

        protected void UpdateIfSuccess(IEnumerableProcessResult<T> result)
        {
            InvokeIfSuccessAndListNotEmpty(result, data => StaticSource.Update(data));
        }

        protected void AddUpdateIfSuccess(IProcessResult<T> result)
        {
            InvokeIfSuccess(result.Status, () => StaticSource.AddUpdate(result.Data));
        }

        protected void AddUpdateIfSuccess(IEnumerableProcessResult<T> result)
        {
            InvokeIfSuccessAndListNotEmpty(result, data => StaticSource.AddUpdate(data));
        }

        protected void RemoveIfSuccess(IProcessResult<T> result)
        {
            InvokeIfSuccess(result.Status, () => StaticSource.Remove(result.Data));
        }

        protected void RemoveIfSuccess(IEnumerableProcessResult<T> result)
        {
            InvokeIfSuccessAndListNotEmpty(result, data => StaticSource.Remove(data));
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

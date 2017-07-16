using System;
using System.Linq;

namespace LGU.EntityManagers
{
    public abstract class ManagerBase
    {
        protected void InvokeIfSuccess(ProcessResultStatus status, Action expression)
        {
            if (status == ProcessResultStatus.Success)
            {
                expression();
            }
        }

        protected void InvokeIfSuccessAndListNotEmpty<T>(IEnumerableDataProcessResult<T> result, Action<T> expression)
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

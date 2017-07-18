using System.Collections.Generic;

namespace LGU.Processes
{
    public interface IEnumerableProcessResult<T> : IProcessResult
    {
        IEnumerable<T> DataList { get; }
    }
}

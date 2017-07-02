using System.Collections.Generic;

namespace LGU
{
    public interface IEnumerableDataProcessResult<T> : IProcessResult
    {
        IEnumerable<T> DataList { get; }
    }
}

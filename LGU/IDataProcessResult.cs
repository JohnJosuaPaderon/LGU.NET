using System.Collections.Generic;

namespace LGU
{
    public interface IDataProcessResult<T> : IProcessResult
    {
        T Data { get; }
    }
}

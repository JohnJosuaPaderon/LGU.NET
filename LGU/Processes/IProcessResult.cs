using System;

namespace LGU.Processes
{
    public interface IProcessResult
    {
        ProcessResultStatus Status { get; }
        string Message { get; }
        Exception Exception { get; }
    }

    public interface IProcessResult<T> : IProcessResult
    {
        T Data { get; }
    }
}

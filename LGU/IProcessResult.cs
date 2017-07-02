using System;

namespace LGU
{
    public interface IProcessResult
    {
        ProcessResultStatus Status { get; }
        string Message { get; }
        Exception Exception { get; }
    }
}

using System;
using System.Collections.Generic;

namespace LGU.Processes
{
    public class EnumerableProcessResult<T> : IEnumerableProcessResult<T>
    {
        public EnumerableProcessResult(ProcessResultStatus status) : this(status, null)
        {
        }

        public EnumerableProcessResult(Exception exception) : this("An exception has been thrown.", exception)
        {
        }

        public EnumerableProcessResult(IEnumerable<T> dataList) : this(dataList, ProcessResultStatus.Success)
        {
        }

        public EnumerableProcessResult(string message, Exception exception) : this(null, ProcessResultStatus.Failed, message, exception)
        {
        }

        public EnumerableProcessResult(IEnumerable<T> dataList, ProcessResultStatus status) : this(dataList, status, null)
        {
        }

        public EnumerableProcessResult(ProcessResultStatus status, string message) : this(null, status, message)
        {
        }

        public EnumerableProcessResult(IEnumerable<T> dataList, ProcessResultStatus status, string message) : this(dataList, status, message, null)
        {
        }

        public EnumerableProcessResult(IEnumerable<T> dataList, ProcessResultStatus status, string message, Exception exception)
        {
            DataList = dataList;
            Status = status;
            Message = message;
            Exception = exception;
        }

        public IEnumerable<T> DataList { get; }
        public ProcessResultStatus Status { get; }
        public string Message { get; }
        public Exception Exception { get; }
    }
}

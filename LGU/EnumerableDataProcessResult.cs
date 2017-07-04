using System;
using System.Collections.Generic;

namespace LGU
{
    public class EnumerableDataProcessResult<T> : IEnumerableDataProcessResult<T>
    {
        public EnumerableDataProcessResult(ProcessResultStatus status) : this(status, null)
        {
        }

        public EnumerableDataProcessResult(Exception exception) : this("An exception has been thrown.", exception)
        {
        }

        public EnumerableDataProcessResult(IEnumerable<T> dataList) : this(dataList, ProcessResultStatus.Success)
        {
        }

        public EnumerableDataProcessResult(string message, Exception exception) : this(null, ProcessResultStatus.Failed, message, exception)
        {
        }

        public EnumerableDataProcessResult(IEnumerable<T> dataList, ProcessResultStatus status) : this(dataList, status, null)
        {
        }

        public EnumerableDataProcessResult(ProcessResultStatus status, string message) : this(null, status, message)
        {
        }

        public EnumerableDataProcessResult(IEnumerable<T> dataList, ProcessResultStatus status, string message) : this(dataList, status, message, null)
        {
        }

        public EnumerableDataProcessResult(IEnumerable<T> dataList, ProcessResultStatus status, string message, Exception exception)
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

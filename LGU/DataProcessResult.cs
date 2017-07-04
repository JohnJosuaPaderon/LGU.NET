using System;

namespace LGU
{
    public struct DataProcessResult<T> : IDataProcessResult<T>
    {
        public DataProcessResult(ProcessResultStatus status) : this(status, null)
        {
        }

        public DataProcessResult(Exception exception) : this(default(T), ProcessResultStatus.Failed, "An exception has been thrown.", exception)
        {
        }

        public DataProcessResult(T data) : this(data, ProcessResultStatus.Success)
        {
        }

        public DataProcessResult(string message, Exception exception) : this(default(T), ProcessResultStatus.Failed, message, exception)
        {
        }

        public DataProcessResult(T data, ProcessResultStatus status) : this(data, status, null)
        {
        }

        public DataProcessResult(ProcessResultStatus status, string message) : this(default(T), status, message)
        {
        }

        public DataProcessResult(T data, ProcessResultStatus status, string message) : this(data, status, message, null)
        {
        }

        public DataProcessResult(T data, ProcessResultStatus status, string message, Exception exception)
        {
            Data = data;
            Status = status;
            Message = message;
            Exception = exception;
        }

        public T Data { get; }
        public ProcessResultStatus Status { get; }
        public string Message { get; }
        public Exception Exception { get; }
    }
}

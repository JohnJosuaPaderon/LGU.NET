using System;

namespace LGU.Processes
{
    public struct ProcessResult : IProcessResult
    {
        public ProcessResult(ProcessResultStatus status) : this(status, null)
        {
        }

        public ProcessResult(Exception exception) : this(ProcessResultStatus.Failed, ApplicationDomain.DebugMode ? exception.Message : "An exception has been thrown.", exception)
        {
        }

        public ProcessResult(string message, Exception exception) : this(ProcessResultStatus.Failed, message, exception)
        {
        }

        public ProcessResult(ProcessResultStatus status, string message) : this(status, message, null)
        {
        }

        public ProcessResult(ProcessResultStatus status, string message, Exception exception)
        {
            Status = status;
            Message = message;
            Exception = exception;
        }

        public ProcessResultStatus Status { get; }
        public string Message { get; }
        public Exception Exception { get; }
    }

    public struct ProcessResult<T> : IProcessResult<T>
    {
        public ProcessResult(ProcessResultStatus status) : this(status, null)
        {
        }

        public ProcessResult(Exception exception) : this(default(T), ProcessResultStatus.Failed, ApplicationDomain.DebugMode ? exception.Message : "An exception has been thrown.", exception)
        {
        }

        public ProcessResult(T data) : this(data, ProcessResultStatus.Success)
        {
        }

        public ProcessResult(string message, Exception exception) : this(default(T), ProcessResultStatus.Failed, message, exception)
        {
        }

        public ProcessResult(T data, ProcessResultStatus status) : this(data, status, null)
        {
        }

        public ProcessResult(ProcessResultStatus status, string message) : this(default(T), status, message)
        {
        }

        public ProcessResult(T data, ProcessResultStatus status, string message) : this(data, status, message, null)
        {
        }

        public ProcessResult(T data, ProcessResultStatus status, string message, Exception exception)
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

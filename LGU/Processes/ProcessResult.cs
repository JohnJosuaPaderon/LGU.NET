using System;

namespace LGU.Processes
{
    public struct ProcessResult : IProcessResult
    {
        private const string MESSAGE_EXCEPTION_THROWN = "An exception has been thrown.";
        private const string MESSAGE_SUCCESS = "Process successfully completed.";

        public static ProcessResult Failed(string message)
        {
            return new ProcessResult(ProcessResultStatus.Failed, message);
        }

        public static ProcessResult Failed(Exception exception)
        {
            return new ProcessResult(ProcessResultStatus.Failed, MESSAGE_EXCEPTION_THROWN, exception);
        }

        public static ProcessResult Failed(string message, Exception exception)
        {
            return new ProcessResult(ProcessResultStatus.Failed, message, exception);
        }

        public static ProcessResult Success()
        {
            return new ProcessResult(ProcessResultStatus.Success, MESSAGE_SUCCESS);
        }

        public static ProcessResult Success(string message)
        {
            return new ProcessResult(ProcessResultStatus.Success, message);
        }

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
        private const string MESSAGE_EXCEPTION_THROWN = "An exception has been thrown.";
        private const string MESSAGE_SUCCESS = "Process successfully completed.";
        private const string MESSAGE_NO_RESULT = "Process successfully completed but has no result.";

        public static ProcessResult<T> Failed(string message)
        {
            return new ProcessResult<T>(default(T), ProcessResultStatus.Failed, message);
        }

        public static ProcessResult<T> Failed(Exception exception)
        {
            return new ProcessResult<T>(default(T), ProcessResultStatus.Failed, MESSAGE_EXCEPTION_THROWN, exception);
        }

        public static ProcessResult<T> Failed(string message, Exception exception)
        {
            return new ProcessResult<T>(default(T), ProcessResultStatus.Failed, message, exception);
        }

        public static ProcessResult<T> Success(T data)
        {
            return new ProcessResult<T>(data, ProcessResultStatus.Success, MESSAGE_SUCCESS);
        }

        public static ProcessResult<T> Success(T data, string message)
        {
            return new ProcessResult<T>(data, ProcessResultStatus.Success, message);
        }

        public static ProcessResult<T> NoResult()
        {
            return new ProcessResult<T>(default(T), ProcessResultStatus.Undefined, MESSAGE_NO_RESULT);
        }

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

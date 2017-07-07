using System;

namespace LGU
{
    public struct ProcessResult : IProcessResult
    {
        public ProcessResult(ProcessResultStatus status) : this(status, null)
        {
        }

        public ProcessResult(Exception exception) : this(ProcessResultStatus.Failed, "An exception has been thrown.", exception)
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
}

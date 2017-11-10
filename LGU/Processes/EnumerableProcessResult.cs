using System;
using System.Collections.Generic;

namespace LGU.Processes
{
    public class EnumerableProcessResult<T> : IEnumerableProcessResult<T>
    {
        private const string MESSAGE_EXCEPTION_THROWN = "An exception has been thrown.";
        private const string MESSAGE_SUCCESS = "Process successfully completed.";
        private const string MESSAGE_NO_RESULT = "Process successfully completed but has no result.";

        public static EnumerableProcessResult<T> Failed(string message)
        {
            return new EnumerableProcessResult<T>(null, ProcessResultStatus.Failed, message);
        }

        public static EnumerableProcessResult<T> Failed(Exception exception)
        {
            return new EnumerableProcessResult<T>(null, ProcessResultStatus.Failed, MESSAGE_EXCEPTION_THROWN, exception);
        }

        public static EnumerableProcessResult<T> Failed(string message, Exception exception)
        {
            return new EnumerableProcessResult<T>(null, ProcessResultStatus.Failed, message, exception);
        }

        public static EnumerableProcessResult<T> Success(IEnumerable<T> dataList)
        {
            return new EnumerableProcessResult<T>(dataList, ProcessResultStatus.Success, MESSAGE_SUCCESS);
        }

        public static EnumerableProcessResult<T> Success(IEnumerable<T> dataList, string message)
        {
            return new EnumerableProcessResult<T>(dataList, ProcessResultStatus.Success, message);
        }

        public static EnumerableProcessResult<T> NoResult()
        {
            return new EnumerableProcessResult<T>(null, ProcessResultStatus.Undefined, MESSAGE_NO_RESULT);
        }

        public EnumerableProcessResult(ProcessResultStatus status) : this(status, null)
        {
        }

        public EnumerableProcessResult(Exception exception) : this(ApplicationDomain.DebugMode ? exception.Message : "An exception has been thrown.", exception)
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

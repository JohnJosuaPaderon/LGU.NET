using System;

namespace LGU
{
    /// <summary>
    /// Represents errors that occur during execution
    /// </summary>
    public partial class LGUException : Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="LGUException"/>
        /// </summary>
        public LGUException() : base("An undefined application error occured.")
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="LGUException"/>
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        public LGUException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="LGUException"/>
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        /// <param name="innerException">The exception that is the cause of the current exception</param>
        public LGUException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="LGUException"/>
        /// </summary>
        /// <param name="level">The severity of the exception</param>
        public LGUException(LGUExceptionLevel level) : base("An undefined application error occured.")
        {
            Level = level;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="LGUException"/>
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        /// <param name="level">The severity of the exception</param>
        public LGUException(string message, LGUExceptionLevel level) : base(message)
        {
            Level = level;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="LGUException"/>
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        /// <param name="innerException">The exception that is the cause of the current exception</param>
        /// <param name="level">The severity of the exception</param>
        public LGUException(string message, Exception innerException, LGUExceptionLevel level) : base(message, innerException)
        {
            Level = level;
        }

        public LGUExceptionLevel Level { get; }
    }
}

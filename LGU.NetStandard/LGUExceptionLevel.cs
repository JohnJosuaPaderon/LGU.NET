namespace LGU
{
    /// <summary>
    /// Enumeration of defined exception levels
    /// </summary>
    public enum LGUExceptionLevel
    {
        /// <summary>
        /// Exception that normally occurs; ie, A database connection failure or UI-related errors
        /// </summary>
        Normal = 0,

        /// <summary>
        /// Exception that can cause data failure; Application termination is optionally
        /// </summary>
        High = 1,

        /// <summary>
        /// Exception that really affects the system badly; Application termination should be issued immediately
        /// </summary>
        Fatal = 2   
    }
}

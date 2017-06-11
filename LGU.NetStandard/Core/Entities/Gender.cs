using System;

namespace LGU.Core.Entities
{
    /// <summary>
    /// Enumeration of defined gender types
    /// </summary>
    [Flags]
    public enum Gender
    {
        /// <summary>
        /// Gender is not set, undefined or unknown
        /// </summary>
        NotSet = 0,

        /// <summary>
        /// Gender is male, boy, man or any equivalent
        /// </summary>
        Male = 1,

        /// <summary>
        /// Gender is female, girl, woman or any equivalent
        /// </summary>
        Female = 2
    }
}

using System;

namespace LGU.Entities
{
    /// <summary>
    /// Collection of defined gender
    /// </summary>
    [Flags]
    public enum Gender
    {
        /// <summary>
        /// The gender is not set, undefined or unknown
        /// </summary>
        NotSet = 0,

        /// <summary>
        /// The gender is male, boy, man or any equivalent
        /// </summary>
        Male = 1,

        /// <summary>
        /// The gender is female, girl, woman or any equivalent
        /// </summary>
        Female = 2
    }
}

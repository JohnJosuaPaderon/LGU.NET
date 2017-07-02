using System;

namespace LGU.Entities
{
    /// <summary>
    /// Collection of defined operation available in <see cref="EntityCollection"/>
    /// </summary>
    [Flags]
    public enum EntityCollectionOperation
    {
        /// <summary>
        /// The operattion is not set
        /// </summary>
        NotSet = 0,

        /// <summary>
        /// Operation for adding an item
        /// </summary>
        Add = 1,

        /// <summary>
        /// Operation for removing an item
        /// </summary>
        Remove = 2,

        /// <summary>
        /// Operation for updating an item
        /// </summary>
        Update = 4,

        /// <summary>
        /// Operation for clearing the collection
        /// </summary>
        Clear = 8
    }
}

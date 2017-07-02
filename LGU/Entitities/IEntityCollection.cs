using System.Collections.Generic;

namespace LGU.Entities
{
    /// <summary>
    /// Exposes functionalities for managing a collection of <see cref="IEntity{TIdentifier}"/>
    /// </summary>
    /// <typeparam name="T">The type of the <see cref="IEntity{TIdentifier}"/></typeparam>
    /// <typeparam name="TIdentifier">The type of the <see cref="IEntity{TIdentifier}.Id"/></typeparam>
    public interface IEntityCollection<T, TIdentifier> : ICollection<T>
        where T : IEntity<TIdentifier>
    {
        /// <summary>
        /// Occurs when an item has been added to the collection
        /// </summary>
        event EntityCollectionEventHandler<T, TIdentifier> Added;

        /// <summary>
        /// Occurs when an item has been removed from the collection
        /// </summary>
        event EntityCollectionEventHandler<T, TIdentifier> Removed;

        /// <summary>
        /// Occurs when an item has been updated in the collection
        /// </summary>
        event EntityCollectionEventHandler<T, TIdentifier> Updated;

        /// <summary>
        /// Occurs when the collection has been cleared
        /// </summary>
        event EntityCollectionEventHandler Cleared;

        /// <summary>
        /// Indexer of the collection
        /// </summary>
        /// <param name="id">The identifier of an entity in the collection</param>
        /// <returns></returns>
        T this[TIdentifier id] { get; set; }

        /// <summary>
        /// Performs <see cref="ICollection{T}.Add(T)"/> when the argument doesn't exists, performs <see cref="Update(T)"/> otherwise
        /// </summary>
        /// <param name="item"></param>
        void AddUpdate(T item);

        /// <summary>
        /// Updates an entity that already exists in the collection
        /// </summary>
        /// <param name="item">The entity with new property values</param>
        void Update(T item);
    }
}

using System;

namespace LGU.Entities
{
    /// <summary>
    /// Encapsulates a method used for event handling in <see cref="EntityCollection"/>
    /// </summary>
    /// <param name="sender">The invoker</param>
    /// <param name="e">The event arguments</param>
    public delegate void EntityCollectionEventHandler(object sender, EntityCollectionEventArgs e);

    /// <summary>
    /// Encapsulates a method used for event handling in <see cref="EntityCollection"/>
    /// </summary>
    /// <typeparam name="T">Type of the <see cref="Entity{TIdentifier}"/></typeparam>
    /// <typeparam name="TIdentifier">Type of <see cref="Entity{TIdentifier}.Id"/></typeparam>
    /// <param name="sender">The invoker</param>
    /// <param name="e">The event arguments</param>
    public delegate void EntityCollectionEventHandler<T, TIdentifier>(object sender, EntityCollectionEventArgs<T, TIdentifier> e) where T : IEntity<TIdentifier>;

    /// <summary>
    /// Contains event data when <see cref="EntityCollectionEventHandler"/> has been invoked
    /// </summary>
    public class EntityCollectionEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes an instance of <see cref="EntityCollectionEventArgs"/>
        /// </summary>
        /// <param name="operation">The operation that has been performed in the collection</param>
        public EntityCollectionEventArgs(EntityCollectionOperation operation)
        {
            Operation = operation;
        }
        
        /// <summary>
        /// The operation performed in the collection
        /// </summary>
        public EntityCollectionOperation Operation { get; }
    }

    /// <summary>
    /// Contains event data when <see cref="EntityCollectionEventHandler{T, TIdentifier}"/> has been invoked; This class inherits <see cref="EntityCollectionEventArgs"/>
    /// </summary>
    /// <typeparam name="T">The type of the <see cref="Entity{TIdentifier}"/></typeparam>
    /// <typeparam name="TIdentifier">The type of the <see cref="Entity{TIdentifier}.Id"/></typeparam>
    public class EntityCollectionEventArgs<T, TIdentifier> : EntityCollectionEventArgs
        where T : IEntity<TIdentifier>
    {
        /// <summary>
        /// Initializes an instance of <see cref="EntityCollectionEventArgs{T, TIdentifier}"/>
        /// </summary>
        /// <param name="operation">The operation thas has been performed in the collecction</param>
        public EntityCollectionEventArgs(EntityCollectionOperation operation) : base(operation)
        {
        }

        /// <summary>
        /// Initializes an instance of <see cref="EntityCollectionEventArgs{T, TIdentifier}"/>
        /// </summary>
        /// <param name="operation">the operation that has been performed in the collection</param>
        /// <param name="data"></param>
        public EntityCollectionEventArgs(EntityCollectionOperation operation, T data) : base(operation)
        {
            Data = data;
        }

        /// <summary>
        /// That processed data when an operation has been performed
        /// </summary>
        public T Data { get; }
    }
}
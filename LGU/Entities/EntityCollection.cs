using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LGU.Entities
{
    /// <summary>
    /// Exposes functionalities for managing a collection of <see cref="IEntity{TIdentifier}"/>
    /// </summary>
    /// <typeparam name="T">The type of the <see cref="IEntity{TIdentifier}"/></typeparam>
    /// <typeparam name="TIdentifier">The type of the <see cref="IEntity{TIdentifier}.Id"/></typeparam>
    public class EntityCollection<T, TIdentifier> : IEntityCollection<T, TIdentifier>
        where T : IEntity<TIdentifier>
    {
        /// <summary>
        /// Initializes an instance of <see cref="EntityCollection{T, TIdentifier}"/> that contains nothing
        /// </summary>
        public EntityCollection()
        {
            Source = new Dictionary<TIdentifier, T>();
        }

        /// <summary>
        /// Initializes an instance of <see cref="EntityCollection{T, TIdentifier}"/> that initially contains the argument
        /// </summary>
        /// <param name="initialContent">Initial collection content</param>
        public EntityCollection(IEnumerable<T> initialContent)
        {
            if (initialContent == null && !initialContent.Any()) return;

            Source = initialContent.ToDictionary(e => e.Id);
        }

        /// <summary>
        /// Handles the actual collection content 
        /// </summary>
        protected Dictionary<TIdentifier, T> Source { get; }

        /// <summary>
        /// Gets or sets an entity in the collection using the <see cref="IEntity{TIdentifier}.Id"/> property
        /// </summary>
        /// <param name="id">The identifier of an entity</param>
        /// <returns></returns>
        public T this[TIdentifier id]
        {
            get
            {
                if (Equals(default(TIdentifier), id)) return default(T);

                if (Source.ContainsKey(id))
                {
                    return Source[id];
                }
                else
                {
                    return default(T);
                }
            }
            set
            {
                AddUpdate(value);
            }
        }

        /// <summary>
        /// Number of entities present in the collection
        /// </summary>
        public int Count => Source.Count;

        /// <summary>
        /// Determines if the collection is read-only; This always returns <see cref="false"/>
        /// </summary>
        public bool IsReadOnly => throw new NotImplementedException();

        /// <summary>
        /// Occurs when an item has been added to the collection
        /// </summary>
        public event EntityCollectionEventHandler<T, TIdentifier> Added;

        /// <summary>
        /// Occurs when an item has been removed from the collection
        /// </summary>
        public event EntityCollectionEventHandler<T, TIdentifier> Removed;

        /// <summary>
        /// Occurs when an item has been updated in the collection
        /// </summary>
        public event EntityCollectionEventHandler<T, TIdentifier> Updated;

        /// <summary>
        /// Occurs when the collection has been cleared
        /// </summary>
        public event EntityCollectionEventHandler Cleared;

        /// <summary>
        /// Adds an item to the collection
        /// </summary>
        /// <param name="item">The item to be added</param>
        public void Add(T item)
        {
            if (IsDefault(item)) return;
            if (Source.ContainsKey(item.Id)) return;

            UnsafeAdd(item);
        }

        /// <summary>
        /// Adds an item to the collection if the item doesn't exists, the collection will be updated otherwise
        /// </summary>
        /// <param name="item">The item to be added or updated</param>
        public void AddUpdate(T item)
        {
            if (IsDefault(item)) return;

            if (Source.ContainsKey(item.Id))
            {
                UnsafeUpdate(item);
            }
            else
            {
                UnsafeAdd(item);
            }
        }

        /// <summary>
        /// Clears the collection
        /// </summary>
        public void Clear()
        {
            if (!Source.Any()) return;

            Source.Clear();
            OnCleared();
        }

        /// <summary>
        /// Returns true if the item is already in the list, returns false otherwise
        /// </summary>
        /// <param name="item">The item to be checked</param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            if (IsDefault(item)) return false;
            if (!Source.Any()) return false;

            return UnsafeContains(item);
        }

        public bool ContainsId(TIdentifier id)
        {
            if (!Source.Any()) return false;

            return Source.ContainsKey(id);
        }

        /// <summary>
        /// Copies <see cref="EntityCollection{T, TIdentifier}"/> elements to an existing one-dimensional <see cref="Array"/>, starting at the specified array index
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="Array"/> that is the destination of the elements copied from <see cref="EntityCollection{T, TIdentifier}"/>. The <see cref="Array"/> must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            Source.Values.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="EntityCollection{T, TIdentifier}"/>
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return Source.Values.GetEnumerator();
        }

        /// <summary>
        /// Determines if the item is default
        /// </summary>
        /// <param name="item">The item to be checked</param>
        /// <returns></returns>
        protected virtual bool IsDefault(T item)
        {
            return Equals(default(T), item);
        }
        
        /// <summary>
        /// Invokes <see cref="Added"/>
        /// </summary>
        /// <param name="item">The item added to the collection</param>
        protected virtual void OnAdded(T item)
        {
            Added?.Invoke(this, new EntityCollectionEventArgs<T, TIdentifier>(EntityCollectionOperation.Add, item));
        }

        /// <summary>
        /// Invokes <see cref="Cleared"/>
        /// </summary>
        protected virtual void OnCleared()
        {
            Cleared?.Invoke(this, new EntityCollectionEventArgs(EntityCollectionOperation.Clear));
        }

        /// <summary>
        /// Invokes <see cref="Removed"/>
        /// </summary>
        /// <param name="item">The item removed from the collection</param>
        protected virtual void OnRemoved(T item)
        {
            Removed?.Invoke(this, new EntityCollectionEventArgs<T, TIdentifier>(EntityCollectionOperation.Remove, item));
        }

        /// <summary>
        /// Invokes <see cref="Updated"/>
        /// </summary>
        /// <param name="item">The item updated in the collection</param>
        protected virtual void OnUpdated(T item)
        {
            Updated?.Invoke(this, new EntityCollectionEventArgs<T, TIdentifier>(EntityCollectionOperation.Update, item));
        }

        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="item">the item to be removed</param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            if (IsDefault(item)) return false;
            if (!UnsafeContains(item)) return false;

            return UnsafeRemove(item);
        }

        /// <summary>
        /// Adds the item to the collection directly
        /// </summary>
        /// <param name="item">The item to be added</param>
        protected virtual void UnsafeAdd(T item)
        {
            Source.Add(item.Id, item);
            OnAdded(item);
        }

        /// <summary>
        /// Determines wether the item is already exists in the collection; This has no validations and directly operates with the <see cref="Source"/>
        /// </summary>
        /// <param name="item">The item to be checked</param>
        /// <returns></returns>
        protected virtual bool UnsafeContains(T item)
        {
            return Source.ContainsKey(item.Id);
        }

        /// <summary>
        /// Removes the item from the collection directly
        /// </summary>
        /// <param name="item">The item to be removed</param>
        /// <returns></returns>
        protected virtual bool UnsafeRemove(T item)
        {
            var result = Source.Remove(item.Id);
            OnRemoved(item);
            return result;
        }

        /// <summary>
        /// Updates the item in the collection directly
        /// </summary>
        /// <param name="item">The item to be updated</param>
        protected virtual void UnsafeUpdate(T item)
        {
            Source[item.Id] = item;
            OnUpdated(item);
        }

        /// <summary>
        /// Updates an item in the collection
        /// </summary>
        /// <param name="item"></param>
        public void Update(T item)
        {
            if (IsDefault(item)) return;
            if (!Source.Any()) return;

            UnsafeUpdate(item);
        }
        
        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="EntityCollection{T, TIdentifier}"/>
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

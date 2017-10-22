using System.Collections.Generic;

namespace LGU.Entities
{
    public interface IEntityCollection<T> : ICollection<T>
    {
        event EntityCollectionEventHandler<T> Added;
        event EntityCollectionRangedEventHandler<T> RangeAdded;
        event EntityCollectionEventHandler<T> Removed;
        event EntityCollectionEventHandler<T> Updated;
        event EntityCollectionEventHandler Cleared;

        void AddRange(IEnumerable<T> items);
        void AddUpdate(T item);
        void Update(T item);
    }

    public interface IEntityCollection<T, TIdentifier> : ICollection<T>
        where T : IEntity<TIdentifier>
    {
        event EntityCollectionEventHandler<T, TIdentifier> Added;
        event EntityCollectionEventHandler<T, TIdentifier> Removed;
        event EntityCollectionEventHandler<T, TIdentifier> Updated;
        event EntityCollectionEventHandler Cleared;

        T this[TIdentifier id] { get; set; }

        void AddUpdate(T item);
        void Update(T item);
    }
}

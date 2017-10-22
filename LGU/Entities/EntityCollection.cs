using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LGU.Entities
{
    public class EntityCollection<T> : IEntityCollection<T>
    {
        public EntityCollection()
        {
            _Source = new List<T>();
        }

        protected readonly List<T> _Source;

        public int Count => _Source.Count;

        public bool IsReadOnly => false;

        public event EntityCollectionEventHandler<T> Added;
        public event EntityCollectionEventHandler<T> Removed;
        public event EntityCollectionEventHandler<T> Updated;
        public event EntityCollectionEventHandler Cleared;
        public event EntityCollectionRangedEventHandler<T> RangeAdded;

        public void Add(T item)
        {
            if (IsDefault(item)) return;

            UnsafeAdd(item);
        }

        public void AddUpdate(T item)
        {
            if (IsDefault(item)) return;

            if (_Source.Contains(item))
            {
                UnsafeUpdate(item);
            }
            else
            {
                UnsafeAdd(item);
            }
        }

        public void Clear()
        {
            if (!_Source.Any()) return;

            _Source.Clear();
            OnCleared();
        }

        public bool Contains(T item)
        {
            if (IsDefault(item)) return false;
            if (!_Source.Any()) return false;

            return UnsafeContains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _Source.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _Source.GetEnumerator();
        }

        protected virtual bool IsDefault(T item)
        {
            return Equals(default(T), item);
        }

        protected virtual void OnAdded(T item)
        {
            Added?.Invoke(this, new EntityCollectionEventArgs<T>(EntityCollectionOperation.Add, item));
        }

        protected virtual void OnAdded(IEnumerable<T> items)
        {
            RangeAdded?.Invoke(this, new EntityCollectionRangedEventArgs<T>(EntityCollectionOperation.Add, items));
        }

        protected virtual void OnCleared()
        {
            Cleared?.Invoke(this, new EntityCollectionEventArgs(EntityCollectionOperation.Clear));
        }

        protected virtual void OnRemoved(T item)
        {
            Removed?.Invoke(this, new EntityCollectionEventArgs<T>(EntityCollectionOperation.Remove, item));
        }

        protected virtual void OnUpdated(T item)
        {
            Updated?.Invoke(this, new EntityCollectionEventArgs<T>(EntityCollectionOperation.Update, item));
        }

        public bool Remove(T item)
        {
            if (IsDefault(item)) return false;
            if (!UnsafeContains(item)) return false;

            return UnsafeRemove(item);
        }

        protected virtual void UnsafeAdd(T item)
        {
            _Source.Add(item);
            OnAdded(item);
        }

        protected virtual void UnsafeAdd(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                _Source.Add(item);
            }

            OnAdded(items);
        }

        protected virtual bool UnsafeContains(T item)
        {
            return _Source.Contains(item);
        }

        protected virtual bool UnsafeRemove(T item)
        {
            var result = _Source.Remove(item);
            OnRemoved(item);
            return result;
        }

        protected virtual void UnsafeUpdate(T item)
        {
            var index = _Source.IndexOf(item);
            _Source[index] = item;

            OnUpdated(item);
        }

        public void Update(T item)
        {
            if (IsDefault(item)) return;
            if (!_Source.Any()) return;

            UnsafeUpdate(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void AddRange(IEnumerable<T> items)
        {
            if (items != null && items.Any())
            {
                var validItems = new List<T>();

                foreach (var item in items)
                {
                    if (!Contains(item))
                    {
                        validItems.Add(item);
                    }
                }

                UnsafeAdd(validItems);
            }
        }
    }

    public class EntityCollection<T, TIdentifier> : IEntityCollection<T, TIdentifier>
        where T : IEntity<TIdentifier>
    {
        public EntityCollection()
        {
            Source = new Dictionary<TIdentifier, T>();
        }
        
        public EntityCollection(IEnumerable<T> initialContent)
        {
            if (initialContent == null && !initialContent.Any()) return;

            Source = initialContent.ToDictionary(e => e.Id);
        }
        
        protected Dictionary<TIdentifier, T> Source { get; }
        
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
        
        public int Count => Source.Count;
        public bool IsReadOnly => throw new NotImplementedException();
        
        public event EntityCollectionEventHandler<T, TIdentifier> Added;
        public event EntityCollectionEventHandler<T, TIdentifier> Removed;
        public event EntityCollectionEventHandler<T, TIdentifier> Updated;
        public event EntityCollectionEventHandler Cleared;
        
        public void Add(T item)
        {
            if (IsDefault(item)) return;
            if (Source.ContainsKey(item.Id)) return;

            UnsafeAdd(item);
        }
        
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
        
        public void Clear()
        {
            if (!Source.Any()) return;

            Source.Clear();
            OnCleared();
        }
        
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
        
        public void CopyTo(T[] array, int arrayIndex)
        {
            Source.Values.CopyTo(array, arrayIndex);
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            return Source.Values.GetEnumerator();
        }
        
        protected virtual bool IsDefault(T item)
        {
            return Equals(default(T), item);
        }
        
        protected virtual void OnAdded(T item)
        {
            Added?.Invoke(this, new EntityCollectionEventArgs<T, TIdentifier>(EntityCollectionOperation.Add, item));
        }
        
        protected virtual void OnCleared()
        {
            Cleared?.Invoke(this, new EntityCollectionEventArgs(EntityCollectionOperation.Clear));
        }
        
        protected virtual void OnRemoved(T item)
        {
            Removed?.Invoke(this, new EntityCollectionEventArgs<T, TIdentifier>(EntityCollectionOperation.Remove, item));
        }
        
        protected virtual void OnUpdated(T item)
        {
            Updated?.Invoke(this, new EntityCollectionEventArgs<T, TIdentifier>(EntityCollectionOperation.Update, item));
        }
        
        public bool Remove(T item)
        {
            if (IsDefault(item)) return false;
            if (!UnsafeContains(item)) return false;

            return UnsafeRemove(item);
        }
        
        protected virtual void UnsafeAdd(T item)
        {
            Source.Add(item.Id, item);
            OnAdded(item);
        }

        protected virtual bool UnsafeContains(T item)
        {
            return Source.ContainsKey(item.Id);
        }
        
        protected virtual bool UnsafeRemove(T item)
        {
            var result = Source.Remove(item.Id);
            OnRemoved(item);
            return result;
        }
        
        protected virtual void UnsafeUpdate(T item)
        {
            Source[item.Id] = item;
            OnUpdated(item);
        }
        
        public void Update(T item)
        {
            if (IsDefault(item)) return;
            if (!Source.Any()) return;

            UnsafeUpdate(item);
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;

namespace LGU.Configurations
{
    public sealed class ApplicationSettingCollection : ICollection<ApplicationSetting>
    {
        public ApplicationSettingCollection()
        {
            Source = new Dictionary<string, ApplicationSetting>();
        }

        private Dictionary<string, ApplicationSetting> Source { get; }

        public ApplicationSetting this[string key]
        {
            get
            {
                if (string.IsNullOrWhiteSpace(key))
                {
                    throw new ArgumentException("Key cannot be null or white space.");
                }
                else
                {
                    return Source[key];
                }
            }
            set
            {
                if (string.IsNullOrWhiteSpace(key))
                {
                    throw new ArgumentException("Key cannot be null or white space.");
                }
                else
                {
                    Source[key] = value;
                }
            }
        }

        public int Count => Source.Count;

        public bool IsReadOnly => false;

        public void Add(ApplicationSetting item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else if (Source.ContainsKey(item.Key))
            {
                throw new ArgumentException("Application setting could not be duplicated.", nameof(item));
            }
            else
            {
                Source.Add(item.Key, item);
            }
        }

        public void Clear()
        {
            Source.Clear();
        }

        public bool Contains(ApplicationSetting item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                return Source.ContainsKey(item.Key);
            }
        }

        public void CopyTo(ApplicationSetting[] array, int arrayIndex)
        {
            Source.Values.CopyTo(array, arrayIndex);
        }

        public IEnumerator<ApplicationSetting> GetEnumerator()
        {
            return Source.Values.GetEnumerator();
        }

        public bool Remove(ApplicationSetting item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                return Source.Remove(item.Key);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

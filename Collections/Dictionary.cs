using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Collections
{
    public struct Element<TKey, TValue>
    {
        public TKey Key;
        public TValue Value;
        public int Next;
    }

    public class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly int[] buckets;
        private Element<TKey, TValue>[] elements;
        private int freeIndex;

        public Dictionary(int capacity)
        {
            buckets = new int[capacity];
            elements = new Element<TKey, TValue>[capacity];

            InitializeArrays();

            freeIndex = 0;
            IsReadOnly = false;
        }

        public ICollection<TKey> Keys
        {
            get
            {
                ICollection<TKey> collection = new Collection<TKey>();

                for (int i = 0; i < Count; i++)
                {
                    collection.Add(elements[i].Key);
                }

                return collection;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                ICollection<TValue> collection = new Collection<TValue>();

                for (int i = 0; i < Count; i++)
                {
                    collection.Add(elements[i].Value);
                }

                return collection;
            }
        }

        public int Count { get; private set; }

        public bool IsReadOnly { get; private set; }

        public TValue this[TKey key]
        {
            get
            {
                int index = SearchElementIndex(key);

                if (index >= 0)
                {
                    return elements[index].Value;
                }

                throw new KeyNotFoundException("Key not found in the Dictionary");
            }

            set
            {
                if (IsReadOnly)
                {
                    throw new NotSupportedException("Dictionary is read only and cannot be modified.");
                }

                int index = SearchElementIndex(key);

                if (index >= 0)
                {
                    elements[index].Value = value;
                }
                else
                {
                    Add(key, value);
                }
            }
        }

        public void Add(TKey key, TValue value)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("Dictionary is read only and cannot be modified.");
            }

            if (key == null)
            {
                throw new ArgumentNullException(nameof(key), "Key cannot be null");
            }

            if (SearchElementIndex(key) >= 0)
            {
                throw new ArgumentException("Key already exist on the Dictionary", nameof(key));
            }

            if (freeIndex == -1)
            {
                ExtendCapacity();
            }

            int keyBucket = Math.Abs(key.GetHashCode()) % buckets.Length;

            int newFreeIndex = elements[freeIndex].Next;

            elements[freeIndex].Key = key;
            elements[freeIndex].Value = value;
            elements[freeIndex].Next = buckets[keyBucket];

            buckets[keyBucket] = freeIndex;

            freeIndex = newFreeIndex;
            Count++;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("Dictionary is read only and cannot be modified.");
            }

            Count = 0;

            InitializeArrays();

            InitializeNewElements(buckets.Length);

            freeIndex = 0;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            int index = SearchElementIndex(item.Key);

            if (index < 0)
            {
                return false;
            }

            bool equalNullValue = elements[index].Value == null && item.Value == null;

            return equalNullValue || elements[index].Value.Equals(item.Value);
        }

        public bool ContainsKey(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key), "Key cannot be null");
            }

            return SearchElementIndex(key) >= 0;
        }

        public bool ContainsValue(TValue value)
        {
            ICollection<TValue> collection = Values;

            return collection.Contains(value);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(TKey key)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new System.NotImplementedException();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        public void ToReadOnly()
        {
            IsReadOnly = true;
        }

        private int SearchElementIndex(TKey key)
        {
            int keyBucket = Math.Abs(key.GetHashCode()) % buckets.Length;

            int index = buckets[keyBucket];

            while (index >= 0)
            {
                if (elements[index].Key.Equals(key))
                {
                    break;
                }

                index = elements[index].Next;
            }

            return index;
        }

        private void ExtendCapacity()
        {
            const int Double = 2;

            int capacity = elements.Length;

            Array.Resize(ref elements, capacity * Double);

            InitializeNewElements(capacity);

            freeIndex = capacity;
        }

        private void InitializeArrays()
        {
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = -1;
                elements[i].Next = i + 1;
            }

            elements[elements.Length - 1].Next = -1;
        }

        private void InitializeNewElements(int index)
        {
            for (; index < elements.Length; index++)
            {
                elements[index].Next = index + 1;
            }

            elements[elements.Length - 1].Next = -1;
        }
    }
}

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
            this.buckets = new int[capacity];
            this.elements = new Element<TKey, TValue>[capacity];

            for (int i = 0; i < capacity; i++)
            {
                this.buckets[i] = -1;
                this.elements[i].Next = i + 1;
            }

            this.elements[capacity - 1].Next = -1;
            this.freeIndex = 0;
            this.IsReadOnly = false;
        }

        public ICollection<TKey> Keys
        {
            get
            {
                ICollection<TKey> collection = new Collection<TKey>();

                for (int i = 0; i < this.Count; i++)
                {
                    collection.Add(this.elements[i].Key);
                }

                return collection;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                ICollection<TValue> collection = new Collection<TValue>();

                for (int i = 0; i < this.Count; i++)
                {
                    collection.Add(this.elements[i].Value);
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
                    return this.elements[index].Value;
                }

                throw new KeyNotFoundException("Key not found in the Dictionary");
            }

            set
            {
                int index = SearchElementIndex(key);

                if (index >= 0)
                {
                    this.elements[index].Value = value;
                }
                else
                {
                    this.Add(key, value);
                }
            }
        }

        public void Add(TKey key, TValue value)
        {
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

            int keyBucket = Math.Abs(key.GetHashCode()) % this.buckets.Length;

            int newFreeIndex = this.elements[freeIndex].Next;

            this.elements[freeIndex].Key = key;
            this.elements[freeIndex].Value = value;
            this.elements[freeIndex].Next = buckets[keyBucket];

            this.buckets[keyBucket] = freeIndex;

            this.freeIndex = newFreeIndex;
            this.Count++;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new System.NotImplementedException();
        }

        public bool ContainsKey(TKey key)
        {
            throw new System.NotImplementedException();
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
            this.IsReadOnly = true;
        }

        private int SearchElementIndex(TKey key)
        {
            int keyBucket = Math.Abs(key.GetHashCode()) % this.buckets.Length;

            int index = this.buckets[keyBucket];

            while (index >= 0)
            {
                if (this.elements[index].Key.Equals(key))
                {
                    break;
                }

                index = this.elements[index].Next;
            }

            return index;
        }

        private void ExtendCapacity()
        {
            const int Double = 2;

            int capacity = this.elements.Length;

            Array.Resize(ref this.elements, capacity * Double);

            for (int i = capacity; i < this.elements.Length; i++)
            {
                this.elements[i].Next = i + 1;
            }

            this.elements[this.elements.Length - 1].Next = -1;

            freeIndex = this.elements[capacity].Next;
        }
    }
}

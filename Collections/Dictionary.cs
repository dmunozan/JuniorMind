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
        private readonly Element<TKey, TValue>[] elements;
        private int freeIndex;

        public Dictionary(int capacity)
        {
            this.buckets = new int[capacity];
            this.elements = new Element<TKey, TValue>[capacity];

            for (int i = 0; i < capacity; i++)
            {
                this.buckets[i] = -1;
            }

            freeIndex = 0;
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

        public ICollection<TValue> Values => throw new System.NotImplementedException();

        public int Count { get; private set; }

        public bool IsReadOnly => throw new System.NotImplementedException();

        public TValue this[TKey key] { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void Add(TKey key, TValue value)
        {
            int keyBucket = Math.Abs(key.GetHashCode()) % this.buckets.Length;

            this.elements[freeIndex].Key = key;
            this.elements[freeIndex].Value = value;
            this.elements[freeIndex].Next = buckets[keyBucket];

            this.buckets[keyBucket] = freeIndex;

            this.freeIndex++;
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
    }
}

﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    public class List<T> : IList<T>
    {
        const string IndexExceptionMessage = "Index has to be a positive integer smaller than the size of the collection";
        const string NotSupportedExceptionMessage = "List is read only and cannot be modified.";
        T[] listArray;

        public List()
        {
            const int BaseSize = 4;
            this.listArray = new T[BaseSize];
        }

        public int Count { get; private set; }

        public bool IsReadOnly { get; private set; }

        public virtual T this[int index]
        {
            get => this.listArray[index];
            set
            {
                if (this.IsReadOnly)
                {
                    throw new NotSupportedException(NotSupportedExceptionMessage);
                }

                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException("index", IndexExceptionMessage);
                }

                this.listArray[index] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int currentIndex = 0;

            foreach (T item in listArray)
            {
                if (currentIndex == this.Count)
                {
                    yield break;
                }

                currentIndex++;
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public virtual void Add(T item)
        {
            if (this.IsReadOnly)
            {
                throw new NotSupportedException(NotSupportedExceptionMessage);
            }

            this.EnsureCapacity();

            this.listArray[this.Count] = item;
            this.Count++;
        }

        public int IndexOf(T item)
        {
            int currentIndex = Array.IndexOf(this.listArray, item);

            return (currentIndex >= 0 && currentIndex < this.Count) ? currentIndex : -1;
        }

        public bool Contains(T item)
        {
            return this.IndexOf(item) >= 0;
        }

        public void Clear()
        {
            if (this.IsReadOnly)
            {
                throw new NotSupportedException(NotSupportedExceptionMessage);
            }

            this.Count = 0;
        }

        public virtual void Insert(int index, T item)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), IndexExceptionMessage);
            }

            this.EnsureCapacity();

            Array.Copy(this.listArray, index, this.listArray, index + 1, this.Count - index);

            this.listArray[index] = item;
            this.Count++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), IndexExceptionMessage);
            }

            Array.Copy(this.listArray, index + 1, this.listArray, index, this.Count - index - 1);
            this.Count--;
        }

        public void Remove(T item)
        {
            this.RemoveAt(this.IndexOf(item));
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "The destination array must be a valid array");
            }

            bool isOutOfBounds = arrayIndex < 0 || arrayIndex >= array.Length;

            if (isOutOfBounds)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), IndexExceptionMessage);
            }

            bool isNotLongEnough = array.Length - arrayIndex < this.Count;

            if (isNotLongEnough)
            {
                throw new ArgumentException("There is not enough space from the given index to the end of the array", nameof(array));
            }

            Array.Copy(this.listArray, 0, array, arrayIndex, this.Count);
        }

        bool ICollection<T>.Remove(T item)
        {
            int index = this.IndexOf(item);

            this.RemoveAt(index);

            return index > -1;
        }

        public void ToReadOnly()
        {
            this.IsReadOnly = true;
        }

        private void EnsureCapacity()
        {
            const int Double = 2;

            if (this.Count < this.listArray.Length)
            {
                return;
            }

            Array.Resize(ref this.listArray, this.listArray.Length * Double);
        }
    }
}

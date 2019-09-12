using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    public class List<T> : IList<T>
    {
        T[] listArray;

        public List()
        {
            const int BaseSize = 4;
            this.listArray = new T[BaseSize];
        }

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public virtual T this[int index]
        {
            get => this.listArray[index];
            set
            {
                if (index < 0 || index >= this.Count)
                {
                    return;
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
            this.Count = 0;
        }

        public virtual void Insert(int index, T item)
        {
            if (index < 0 || index >= this.Count)
            {
                return;
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
                return;
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
            throw new NotImplementedException();
        }

        bool ICollection<T>.Remove(T item)
        {
            throw new NotImplementedException();
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

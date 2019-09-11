using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    public class List<T> : IEnumerable<T>
    {
        T[] listArray;

        public List()
        {
            const int BaseSize = 4;
            this.listArray = new T[BaseSize];
        }

        public int Count { get; private set; }

        public T this[int index]
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

            foreach (T element in listArray)
            {
                if (currentIndex == this.Count)
                {
                    yield break;
                }

                currentIndex++;
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(T element)
        {
            this.EnsureCapacity();

            this.listArray[this.Count] = element;
            this.Count++;
        }

        public int IndexOf(T element)
        {
            int currentIndex = Array.IndexOf(this.listArray, element);

            return (currentIndex >= 0 && currentIndex < this.Count) ? currentIndex : -1;
        }

        public bool Contains(T element)
        {
            return this.IndexOf(element) >= 0;
        }

        public void Clear()
        {
            this.Count = 0;
        }

        public void Insert(int index, T element)
        {
            if (index < 0 || index >= this.Count)
            {
                return;
            }

            this.EnsureCapacity();

            Array.Copy(this.listArray, index, this.listArray, index + 1, this.Count - index);

            this.listArray[index] = element;
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

        public void Remove(T element)
        {
            this.RemoveAt(this.IndexOf(element));
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

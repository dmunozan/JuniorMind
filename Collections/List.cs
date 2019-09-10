using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    public class List<T> : IEnumerable<T>
    {
        readonly T[] listArray;

        public List()
        {
            const int BaseSize = 4;
            this.listArray = new T[BaseSize];
        }

        public int Count { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Add(T element)
        {
            this.listArray[this.Count] = element;
            this.Count++;
        }

        public int IndexOf(T element)
        {
            return Array.IndexOf(this.listArray, element);
        }

        public bool Contains(T element)
        {
            return this.IndexOf(element) >= 0;
        }
    }
}

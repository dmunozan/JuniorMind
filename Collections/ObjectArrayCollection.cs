using System;
using System.Collections;

namespace Collections
{
    public class ObjectArrayCollection : IEnumerable
    {
        object[] objectArrayCollection;

        public ObjectArrayCollection()
        {
            const int BaseSize = 4;
            this.objectArrayCollection = new object[BaseSize];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public object this[int index]
        {
            get => this.objectArrayCollection[index];
            set
            {
                if (index < 0 || index >= this.Count)
                {
                    return;
                }

                this.objectArrayCollection[index] = value;
            }
        }

        public void Add(object element)
        {
            this.EnsureCapacity();

            this.objectArrayCollection[this.Count] = element;
            this.Count++;
        }

        public int IndexOf(object element)
        {
            int currentIndex = Array.IndexOf(this.objectArrayCollection, element);

            return (currentIndex >= 0 && currentIndex < this.Count) ? currentIndex : -1;
        }

        public bool Contains(object element)
        {
            return this.IndexOf(element) >= 0;
        }

        public void Clear()
        {
            this.Count = 0;
        }

        public void Insert(int index, object element)
        {
            if (index < 0 || index >= this.Count)
            {
                return;
            }

            this.EnsureCapacity();

            Array.Copy(this.objectArrayCollection, index, this.objectArrayCollection, index + 1, this.Count - index);

            this.objectArrayCollection[index] = element;
            this.Count++;
        }

        public void Remove(object element)
        {
            this.RemoveAt(this.IndexOf(element));
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                return;
            }

            Array.Copy(this.objectArrayCollection, index + 1, this.objectArrayCollection, index, this.Count - index - 1);
            this.Count--;
        }

        public IEnumerator GetEnumerator()
        {
            int currentIndex = 0;

            foreach (object o in objectArrayCollection)
            {
                if (currentIndex == this.Count)
                {
                    yield break;
                }

                currentIndex++;
                yield return o;
            }
        }

        private void EnsureCapacity()
        {
            const int Double = 2;

            if (this.Count < this.objectArrayCollection.Length)
            {
                return;
            }

            Array.Resize(ref this.objectArrayCollection, this.objectArrayCollection.Length * Double);
        }
    }
}

using System;

namespace Collections
{
    public class ObjectArray
    {
        object[] objectArray;

        public ObjectArray()
        {
            const int BaseSize = 4;
            this.objectArray = new object[BaseSize];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public object this[int index]
        {
            get => this.objectArray[index];
            set
            {
                if (index < 0 || index >= this.Count)
                {
                    return;
                }

                this.objectArray[index] = value;
            }
        }

        public void Add(object element)
        {
            this.EnsureCapacity();

            this.objectArray[this.Count] = element;
            this.Count++;
        }

        public int IndexOf(object element)
        {
            int currentIndex = Array.IndexOf(this.objectArray, element);

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

            Array.Copy(this.objectArray, index, this.objectArray, index + 1, this.Count - index);

            this.objectArray[index] = element;
            this.Count++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                return;
            }

            Array.Copy(this.objectArray, index + 1, this.objectArray, index, this.Count - index - 1);
            this.Count--;
        }

        private void EnsureCapacity()
        {
            const int Double = 2;

            if (this.Count < this.objectArray.Length)
            {
                return;
            }

            Array.Resize(ref this.objectArray, this.objectArray.Length * Double);
        }
    }
}

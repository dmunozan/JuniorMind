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
            return Array.IndexOf(this.objectArray, element);
        }

        public bool Contains(object element)
        {
            return this.IndexOf(element) >= 0;
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

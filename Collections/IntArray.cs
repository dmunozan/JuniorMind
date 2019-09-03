using System;

namespace Collections
{
    public class IntArray
    {
        int count;
        int[] intArray;

        public IntArray()
        {
            const int BaseSize = 4;
            this.intArray = new int[BaseSize];
            this.count = 0;
        }

        public bool Contains(int element)
        {
            return this.IndexOf(element) >= 0;
        }

        public void Add(int element)
        {
            this.EnsureCapacity();

            this.intArray[this.count] = element;
            this.count++;
        }

        public int Count()
        {
            return this.count;
        }

        public int Element(int index)
        {
            return this.intArray[index];
        }

        public void SetElement(int index, int element)
        {
            if (index < 0 || index >= this.count)
            {
                return;
            }

            this.intArray[index] = element;
        }

        public int IndexOf(int element)
        {
            int currentIndex = Array.IndexOf(this.intArray, element);

            return (currentIndex >= 0 && currentIndex < this.count) ? currentIndex : -1;
        }

        public void Insert(int index, int element)
        {
            if (index < 0 || index >= this.count)
            {
                return;
            }

            this.EnsureCapacity();

            Array.Copy(this.intArray, index, this.intArray, index + 1, this.count - index - 1);

            this.intArray[index] = element;
        }

        public void Clear()
        {
            this.count = 0;
        }

        public void Remove(int element)
        {
            this.RemoveAt(Array.IndexOf(this.intArray, element));
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.count)
            {
                return;
            }

            Array.Copy(this.intArray, index + 1, this.intArray, index, this.count - index - 1);
            this.count--;
        }

        private void EnsureCapacity()
        {
            const int Double = 2;

            if (this.count <= this.intArray.Length)
            {
                return;
            }

            Array.Resize(ref this.intArray, this.intArray.Length * Double);
        }
    }
}

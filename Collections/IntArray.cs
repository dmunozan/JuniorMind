using System;
using System.Collections.Generic;

namespace Collections
{
    public class IntArray
    {
        int index;
        int[] intArray;

        public IntArray()
        {
            const int BaseSize = 4;
            this.intArray = new int[BaseSize];
            this.index = 0;
        }

        public bool Contains(int element)
        {
            int currentIndex = Array.IndexOf(this.intArray, element);
            return currentIndex >= 0 && currentIndex < this.index;
        }

        public void Add(int element)
        {
            const int Double = 2;
            if (this.index > this.intArray.Length)
            {
                Array.Resize(ref this.intArray, this.intArray.Length * Double);
            }

            this.intArray[index] = element;
            this.index++;
        }

        public int Count()
        {
            return this.index;
        }

        public int Element(int index)
        {
            return this.intArray[index];
        }

        public void SetElement(int index, int element)
        {
            if (index < 0 || index >= this.index)
            {
                return;
            }

            this.intArray[index] = element;
        }

        public int IndexOf(int element)
        {
            return Array.IndexOf(this.intArray, element);
        }

        public void Insert(int index, int element)
        {
            if (index < 0 || index >= this.index)
            {
                return;
            }

            const int Double = 2;
            if (this.index > this.intArray.Length)
            {
                Array.Resize(ref this.intArray, this.intArray.Length * Double);
            }

            Array.Copy(this.intArray, index, this.intArray, index + 1, this.index - index - 1);

            this.intArray[index] = element;
        }

        public void Clear()
        {
            this.index = 0;
        }

        public void Remove(int element)
        {
            this.RemoveAt(Array.IndexOf(this.intArray, element));
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.index)
            {
                return;
            }

            Array.Copy(this.intArray, index + 1, this.intArray, index, this.index - index - 1);
            this.index--;
        }
    }
}

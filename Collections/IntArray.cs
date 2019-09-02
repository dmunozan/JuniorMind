using System;
using System.Collections.Generic;

namespace Collections
{
    public class IntArray
    {
        readonly int index;
        int[] intArray;

        public IntArray()
        {
            const int BaseSize = 4;
            this.intArray = new int[BaseSize];
            this.index = 0;
        }

        public bool Contains(int element)
        {
            return Array.IndexOf(this.intArray, element) >= 0;
        }

        public void Add(int element)
        {
            Array.Resize(ref this.intArray, this.intArray.Length + 1);
            this.intArray[this.intArray.Length - 1] = element;
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
            if (index < 0 || index >= this.intArray.Length)
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
            if (index < 0 || index >= this.intArray.Length)
            {
                return;
            }

            Array.Resize(ref this.intArray, this.intArray.Length + 1);
            Array.Copy(this.intArray, index, this.intArray, index + 1, this.intArray.Length - index - 1);

            this.intArray[index] = element;
        }

        public void Clear()
        {
            this.intArray = new int[0];
        }

        public void Remove(int element)
        {
            this.RemoveAt(Array.IndexOf(this.intArray, element));
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.intArray.Length)
            {
                return;
            }

            Array.Copy(this.intArray, index + 1, this.intArray, index, this.intArray.Length - index - 1);
            Array.Resize(ref this.intArray, this.intArray.Length - 1);
        }
    }
}

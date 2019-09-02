using System;
using System.Collections.Generic;

namespace Collections
{
    public class IntArray
    {
        int[] intArray;

        public IntArray()
        {
            this.intArray = new int[0];
        }

        public bool Contains(int element)
        {
            return Array.IndexOf(intArray, element) >= 0;
        }

        public void Add(int element)
        {
            Array.Resize(ref this.intArray, this.intArray.Length + 1);
            this.intArray[this.intArray.Length - 1] = element;
        }

        public int Count()
        {
            return intArray.Length;
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

            int[] newArray = new int[this.intArray.Length + 1];
            Array.Copy(this.intArray, 0, newArray, 0, index);
            newArray[index] = element;
            Array.Copy(this.intArray, index, newArray, index + 1, this.intArray.Length - index);
            this.intArray = newArray;
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

            int[] newArray = new int[this.intArray.Length - 1];
            Array.Copy(this.intArray, 0, newArray, 0, index);
            Array.Copy(this.intArray, index + 1, newArray, index, this.intArray.Length - index - 1);
            this.intArray = newArray;
        }
    }
}

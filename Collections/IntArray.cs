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
            int[] newArray = new int[this.intArray.Length + 1];
            intArray.CopyTo(newArray, 0);
            newArray[this.intArray.Length] = element;
            this.intArray = newArray;
        }

        public int Count()
        {
            return intArray.Length;
        }

        public int Element(int index)
        {
            return this.intArray[index];
        }
    }
}

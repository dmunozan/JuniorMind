using System;

namespace Collections
{
    public class IntArray
    {
        readonly int[] intArray;

        public IntArray()
        {
            this.intArray = new int[0];
        }

        public bool Contains(int element)
        {
            Console.WriteLine(intArray + "" + element);
            return false;
        }
    }
}

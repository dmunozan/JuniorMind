﻿using System;

namespace Collections
{
    public class IntArray
    {
        int[] intArray;

        public IntArray()
        {
            const int BaseSize = 4;
            this.intArray = new int[BaseSize];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get => this.intArray[index];
            set
            {
                if (index < 0 || index >= this.Count)
                {
                    return;
                }

                this.intArray[index] = value;
            }
        }

        public bool Contains(int element)
        {
            return this.IndexOf(element) >= 0;
        }

        public void Add(int element)
        {
            this.EnsureCapacity();

            this.intArray[this.Count] = element;
            this.Count++;
        }

        public int IndexOf(int element)
        {
            int currentIndex = Array.IndexOf(this.intArray, element);

            return (currentIndex >= 0 && currentIndex < this.Count) ? currentIndex : -1;
        }

        public void Insert(int index, int element)
        {
            if (index < 0 || index >= this.Count)
            {
                return;
            }

            this.EnsureCapacity();

            Array.Copy(this.intArray, index, this.intArray, index + 1, this.Count - index - 1);

            this.intArray[index] = element;
        }

        public void Clear()
        {
            this.Count = 0;
        }

        public void Remove(int element)
        {
            this.RemoveAt(this.IndexOf(element));
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                return;
            }

            Array.Copy(this.intArray, index + 1, this.intArray, index, this.Count - index - 1);
            this.Count--;
        }

        private void EnsureCapacity()
        {
            const int Double = 2;

            if (this.Count < this.intArray.Length)
            {
                return;
            }

            Array.Resize(ref this.intArray, this.intArray.Length * Double);
        }
    }
}

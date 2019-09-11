using System;
using System.Collections.Generic;

namespace Collections
{
    public class SortedList<T> : List<T>
        where T : IComparable<T>
    {
        public SortedList() : base()
        {
        }

        public override void Add(T element)
        {
            int position = 0;
            for (int i = 0; i < this.Count; i++)
            {
                if (element.CompareTo(this[i]) < 0)
                {
                    break;
                }

                position++;
            }

            if (position == this.Count)
            {
                base.Add(element);
            }
            else
            {
                Insert(position, element);
            }
        }
    }
}

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

        public override T this[int index]
        {
            set
            {
                if (this[index + 1].CompareTo(value) < 0)
                {
                    return;
                }

                base[index] = value;
            }
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
                base.Insert(position, element);
            }
        }

        public override void Insert(int index, T element)
        {
            if (this[index].CompareTo(element) < 0 || (index != 0 && this[index - 1].CompareTo(element) > 0))
            {
                return;
            }

            base.Insert(index, element);
        }
    }
}

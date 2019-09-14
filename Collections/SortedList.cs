using System;
using System.Collections.Generic;

namespace Collections
{
    public class SortedList<T> : List<T>
        where T : IComparable<T>
    {
        const string InvalidOperationExceptionMessage = "Operation not allowed as it would break the sorting.";

        public SortedList() : base()
        {
        }

        public override T this[int index]
        {
            set
            {
                if ((index + 1 != this.Count && this[index + 1].CompareTo(value) < 0) || (index != 0 && this[index - 1].CompareTo(value) > 0))
                {
                    throw new InvalidOperationException(InvalidOperationExceptionMessage);
                }

                base[index] = value;
            }
        }

        public override void Add(T item)
        {
            int position = 0;
            for (int i = 0; i < this.Count; i++)
            {
                if (item.CompareTo(this[i]) < 0)
                {
                    break;
                }

                position++;
            }

            if (position == this.Count)
            {
                base.Add(item);
            }
            else
            {
                base.Insert(position, item);
            }
        }

        public override void Insert(int index, T item)
        {
            if (this[index].CompareTo(item) < 0 || (index != 0 && this[index - 1].CompareTo(item) > 0))
            {
                return;
            }

            base.Insert(index, item);
        }
    }
}

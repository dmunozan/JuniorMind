using System;

namespace Collections
{
    public class SortedIntArray : IntArray
    {
        public SortedIntArray() : base()
        {
        }

        public override void Add(int element)
        {
            int position = 0;
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i] >= element)
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

        public override void Insert(int index, int element)
        {
            if (this[index] < element || (index != 0 && this[index - 1] > element))
            {
                return;
            }

            base.Insert(index, element);
        }
    }
}

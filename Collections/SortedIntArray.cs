using System;

namespace Collections
{
    public class SortedIntArray : IntArray
    {
        public SortedIntArray() : base()
        {
        }

        public override int this[int index]
        {
            set
            {
                if (index + 1 != this.Count && this[index + 1] < value)
                {
                    return;
                }

                base[index] = value;
            }
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

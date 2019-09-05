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
                    position = i;
                    break;
                }
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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public class OrderedEnumerable<TElement> : IOrderedEnumerable<TElement>
    {
        readonly List<TElement> orderedList;

        public OrderedEnumerable(IEnumerable<TElement> source)
        {
            orderedList = new List<TElement>(source);
        }

        public IOrderedEnumerable<TElement> CreateOrderedEnumerable<TKey>(Func<TElement, TKey> keySelector, IComparer<TKey> comparer, bool descending)
        {
            Console.WriteLine(keySelector + "" + comparer + descending);

            return this;
        }

        public IEnumerator<TElement> GetEnumerator()
        {
            foreach (var item in orderedList)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

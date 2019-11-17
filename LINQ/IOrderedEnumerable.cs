using System;
using System.Collections;
using System.Collections.Generic;

namespace LINQ
{
    public class IOrderedEnumerable<TElement> : IEnumerable<TElement>
    {
        readonly List<TElement> orderedList = new List<TElement>();

        public IOrderedEnumerable(IEnumerable<TElement> source)
        {
            orderedList.AddRange(source);
        }

        public IOrderedEnumerable<TElement> CreateOrderedEnumerable<TKey>(Func<TElement, TKey> keySelector, IComparer<TKey> comparer)
        {
            Console.WriteLine(keySelector + "" + comparer);

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

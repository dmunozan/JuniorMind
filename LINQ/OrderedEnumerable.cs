using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public class OrderedEnumerable<TElement, TPrimaryKey> : IOrderedEnumerable<TElement>
    {
        readonly Func<TElement, TPrimaryKey> keySelector;
        readonly IComparer<TPrimaryKey> comparer;
        List<TElement> orderedEnumerableList;

        public OrderedEnumerable(
            IEnumerable<TElement> source,
            Func<TElement, TPrimaryKey> keySelector,
            IComparer<TPrimaryKey> comparer)
        {
            source ??= new List<TElement>();

            this.keySelector = keySelector;
            this.comparer = comparer;

            this.orderedEnumerableList = MergeSort(source, keySelector, comparer);
        }

        public IOrderedEnumerable<TElement> CreateOrderedEnumerable<TSecondaryKey>(
            Func<TElement, TSecondaryKey> keySelector,
            IComparer<TSecondaryKey> comparer,
            bool descending)
        {
            this.orderedEnumerableList = MergeSort(this.orderedEnumerableList, keySelector, comparer);

            return this;
        }

        public IEnumerator<TElement> GetEnumerator()
        {
            foreach (var item in orderedEnumerableList)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private List<TElement> MergeSort<TKey>(
            IEnumerable<TElement> source,
            Func<TElement, TKey> keySelector,
            IComparer<TKey> comparer)
        {
            List<TElement> unorderedList = new List<TElement>(source);

            if (unorderedList.Count <= 1)
            {
                return unorderedList;
            }

            List<TElement> left = new List<TElement>();
            List<TElement> right = new List<TElement>();

            int middle = unorderedList.Count / 2;
            for (int i = 0; i < middle; i++)
            {
                left.Add(unorderedList[i]);
            }

            for (int i = middle; i < unorderedList.Count; i++)
            {
                right.Add(unorderedList[i]);
            }

            left = MergeSort(left, keySelector, comparer);
            right = MergeSort(right, keySelector, comparer);

            return Merge(left, right, keySelector, comparer);
        }

        private List<TElement> Merge<TKey>(
            List<TElement> left,
            List<TElement> right,
            Func<TElement, TKey> keySelector,
            IComparer<TKey> comparer)
        {
            List<TElement> orderedList = new List<TElement>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (CompareValues(
                        left.First(),
                        right.First(),
                        keySelector,
                        comparer) <= 0)
                    {
                        orderedList.Add(left.First());
                        left.Remove(left.First());
                    }
                    else
                    {
                        orderedList.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Count > 0)
                {
                    orderedList.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    orderedList.Add(right.First());
                    right.Remove(right.First());
                }
            }

            return orderedList;
        }

        private int CompareValues<TKey>(
            TElement leftElement,
            TElement rightElement,
            Func<TElement, TKey> keySelector,
            IComparer<TKey> comparer)
        {
            int result = this.comparer.Compare(
                this.keySelector(leftElement),
                this.keySelector(rightElement));

            if (result == 0)
            {
                result = comparer.Compare(
                keySelector(leftElement),
                keySelector(rightElement));
            }

            return result;
        }
    }
}

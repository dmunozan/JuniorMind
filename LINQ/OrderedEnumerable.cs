using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public class OrderedEnumerable<TElement, TPrimaryKey> : IOrderedEnumerable<TElement>
    {
        IComparer<TElement> currentComparer;
        List<TElement> orderedEnumerableList;

        public OrderedEnumerable(
            IEnumerable<TElement> source,
            Func<TElement, TPrimaryKey> keySelector,
            IComparer<TPrimaryKey> comparer)
        {
            source ??= new List<TElement>();

            currentComparer = Comparer<TElement>.Create(
                (leftElement, rightElement) =>
                {
                    return comparer.Compare(
                        keySelector(leftElement),
                        keySelector(rightElement));
                });

            orderedEnumerableList = MergeSort(source);
        }

        public IOrderedEnumerable<TElement> CreateOrderedEnumerable<TSecondaryKey>(
            Func<TElement, TSecondaryKey> keySelector,
            IComparer<TSecondaryKey> comparer,
            bool descending)
        {
            IComparer<TElement> compoundComparer = currentComparer;

            currentComparer = Comparer<TElement>.Create(
                (leftElement, rightElement) =>
                {
                    int result = compoundComparer.Compare(
                        leftElement,
                        rightElement);

                    if (result == 0)
                    {
                        result = comparer.Compare(
                        keySelector(leftElement),
                        keySelector(rightElement));
                    }

                    return result;
                });

            orderedEnumerableList = MergeSort(orderedEnumerableList);

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

        private List<TElement> MergeSort(
            IEnumerable<TElement> source)
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

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        private List<TElement> Merge(
            List<TElement> left,
            List<TElement> right)
        {
            List<TElement> orderedList = new List<TElement>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (currentComparer.Compare(
                        left.First(),
                        right.First()) <= 0)
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
    }
}

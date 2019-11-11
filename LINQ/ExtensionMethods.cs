using System;
using System.Collections.Generic;

namespace LINQ
{
    public static class ExtensionMethods
    {
        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            CheckNullElement(source);

            CheckNullElement(predicate);

            foreach (var element in source)
            {
                if (!predicate(element))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            CheckNullElement(source);

            CheckNullElement(predicate);

            foreach (var element in source)
            {
                if (predicate(element))
                {
                    return true;
                }
            }

            return false;
        }

        public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            CheckNullElement(source);

            CheckNullElement(predicate);

            foreach (var element in source)
            {
                if (predicate(element))
                {
                    return element;
                }
            }

            throw new InvalidOperationException("No element satisfies the condition");
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            CheckNullElement(source);

            CheckNullElement(selector);

            return source.InternalSelect(selector);
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            CheckNullElement(source);

            CheckNullElement(selector);

            List<TResult> result = new List<TResult>();

            foreach (TSource element in source)
            {
                result.AddRange(selector(element));
            }

            return result;
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            CheckNullElement(source);

            CheckNullElement(predicate);

            return source.InternalWhere(predicate);
        }

        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
        {
            CheckNullElement(source);

            CheckNullElement(keySelector);

            CheckNullElement(elementSelector);

            Dictionary<TKey, TElement> dictionary = new Dictionary<TKey, TElement>();

            foreach (var element in source)
            {
                dictionary.Add(keySelector(element), elementSelector(element));
            }

            return dictionary;
        }

        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
        {
            CheckNullElement(first);

            CheckNullElement(second);

            CheckNullElement(resultSelector);

            return first.InternalZip(second, resultSelector);
        }

        public static TAccumulate Aggregate<TSource, TAccumulate>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> func)
        {
            CheckNullElement(source);

            CheckNullElement(func);

            TAccumulate result = seed;

            foreach (var element in source)
            {
                result = func(result, element);
            }

            return result;
        }

        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
            this IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector)
        {
            CheckNullElement(outer);

            CheckNullElement(inner);

            CheckNullElement(outerKeySelector);

            CheckNullElement(innerKeySelector);

            CheckNullElement(resultSelector);

            return outer.ComparatorSelector(
                inner,
                (outerElement, innerElement) => outerKeySelector(outerElement).Equals(innerKeySelector(innerElement)),
                (outerElement, innerElement) => resultSelector(outerElement, innerElement));
        }

        public static IEnumerable<TSource> Distinct<TSource>(
            this IEnumerable<TSource> source,
            IEqualityComparer<TSource> comparer)
        {
            CheckNullElement(source);

            comparer ??= EqualityComparer<TSource>.Default;

            return new HashSet<TSource>(source, comparer);
        }

        public static IEnumerable<TSource> Union<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            CheckNullElement(first);

            CheckNullElement(second);

            List<TSource> result = new List<TSource>();

            result.AddRange(first);
            result.AddRange(second);

            return result.Distinct(comparer);
        }

        public static IEnumerable<TSource> Intersect<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            CheckNullElement(first);

            CheckNullElement(second);

            comparer ??= EqualityComparer<TSource>.Default;

            return first.ComparatorSelector(
                second,
                (firstListElement, secondListElement) => comparer.GetHashCode(firstListElement) == comparer.GetHashCode(secondListElement),
                (firstListElement, secondListElement) => firstListElement);
        }

        public static IEnumerable<TSource> Except<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            List<TSource> result = new List<TSource>();

            comparer ??= EqualityComparer<TSource>.Default;

            foreach (var element in first.Distinct(comparer))
            {
                if (!second.Any(num => comparer.GetHashCode(num) == comparer.GetHashCode(element)))
                {
                    result.Add(element);
                }
            }

            return result;
        }

        public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            Func<TKey, IEnumerable<TElement>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            CheckNullElement(source);

            CheckNullElement(keySelector);

            CheckNullElement(elementSelector);

            CheckNullElement(resultSelector);

            comparer ??= EqualityComparer<TKey>.Default;

            List<TResult> result = new List<TResult>();

            List<TKey> uniqueKeyList = new List<TKey>();

            uniqueKeyList.AddRange(source.Select(keySelector).Distinct(comparer));

            KeyElementList<TKey, TElement>[] keyElementLists = new KeyElementList<TKey, TElement>[uniqueKeyList.Count];

            int index = 0;

            foreach (var keyItem in uniqueKeyList)
            {
                keyElementLists[index].Key = keyItem;
                keyElementLists[index].ElementList = new List<TElement>();
                index++;
            }

            TKey key;

            foreach (var sourceElement in source)
            {
                key = keySelector(sourceElement);

                foreach (var keyElementList in keyElementLists)
                {
                    if (comparer.GetHashCode(key) == comparer.GetHashCode(keyElementList.Key))
                    {
                        keyElementList.ElementList.Add(elementSelector(sourceElement));
                        break;
                    }
                }
            }

            foreach (var keyElementList in keyElementLists)
            {
                result.Add(resultSelector(keyElementList.Key, keyElementList.ElementList));
            }

            return result;
        }

        private static IEnumerable<TResult> ComparatorSelector<TOuter, TInner, TResult>(
            this IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner,
            Func<TOuter, TInner, bool> comparator,
            Func<TOuter, TInner, TResult> resultSelector)
        {
            foreach (var outerElement in outer)
            {
                foreach (var innerElement in inner)
                {
                    if (comparator(outerElement, innerElement))
                    {
                        yield return resultSelector(outerElement, innerElement);
                    }
                }
            }
        }

        private static IEnumerable<TResult> InternalSelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach (var element in source)
            {
                yield return selector(element);
            }
        }

        private static IEnumerable<TSource> InternalWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (var element in source)
            {
                if (predicate(element))
                {
                    yield return element;
                }
            }
        }

        private static IEnumerable<TResult> InternalZip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
        {
            var firstEnumerator = first.GetEnumerator();
            var secondEnumerator = second.GetEnumerator();

            while (firstEnumerator.MoveNext() && secondEnumerator.MoveNext())
            {
                yield return resultSelector(firstEnumerator.Current, secondEnumerator.Current);
            }
        }

        private static void CheckNullElement(object obj)
        {
            if (obj != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(obj), "One of the arguments is null");
        }

        private struct KeyElementList<TKey, TElement>
        {
            public TKey Key;
            public List<TElement> ElementList;
        }
    }
}

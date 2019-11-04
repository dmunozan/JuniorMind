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

            return InternalSelect(source, selector);
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

            List<TSource> result = new List<TSource>();

            foreach (var element in source)
            {
                if (predicate(element))
                {
                    result.Add(element);
                }
            }

            return result;
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

            List<TResult> result = new List<TResult>();

            var firstEnumerator = first.GetEnumerator();
            var secondEnumerator = second.GetEnumerator();

            while (firstEnumerator.MoveNext() && secondEnumerator.MoveNext())
            {
                result.Add(resultSelector(firstEnumerator.Current, secondEnumerator.Current));
            }

            return result;
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

            List<TResult> result = new List<TResult>();

            foreach (var outerElement in outer)
            {
                foreach (var innerElement in inner)
                {
                    if (outerKeySelector(outerElement).Equals(innerKeySelector(innerElement)))
                    {
                        result.Add(resultSelector(outerElement, innerElement));
                    }
                }
            }

            return result;
        }

        public static IEnumerable<TSource> Distinct<TSource>(
            this IEnumerable<TSource> source,
            IEqualityComparer<TSource> comparer)
        {
            CheckNullElement(source);

            List<TSource> result = new List<TSource>();

            comparer = comparer ?? EqualityComparer<TSource>.Default;

            bool foundElement = false;

            foreach (var sourceElement in source)
            {
                foreach (var resultElement in result)
                {
                    if (comparer.Equals(sourceElement, resultElement))
                    {
                        foundElement = true;
                        break;
                    }
                }

                if (!foundElement)
                {
                    result.Add(sourceElement);
                }
            }

            return result;
        }

        public static IEnumerable<TSource> Union<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            List<TSource> result = new List<TSource>();

            if (first == null || second == null || comparer == null)
            {
                return result;
            }

            result.AddRange(first);
            result.AddRange(second);

            return result.Distinct(comparer);
        }

        private static IEnumerable<TResult> InternalSelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach (var element in source)
            {
                yield return selector(element);
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
    }
}

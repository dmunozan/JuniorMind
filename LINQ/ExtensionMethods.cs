using System;
using System.Collections.Generic;

namespace LINQ
{
    public static class ExtensionMethods
    {
        const string Source = "Source";
        const string Predicate = "Predicate";
        const string Selector = "Selector";

        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            CheckNullElement(source, Source);

            CheckNullElement(predicate, Predicate);

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
            CheckNullElement(source, Source);

            CheckNullElement(predicate, Predicate);

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
            CheckNullElement(source, Source);

            CheckNullElement(predicate, Predicate);

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
            CheckNullElement(source, Source);

            CheckNullElement(selector, Selector);

            return InternalSelect(source, selector);
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            CheckNullElement(source, Source);

            CheckNullElement(selector, Selector);

            List<TResult> result = new List<TResult>();

            foreach (TSource element in source)
            {
                result.AddRange(selector(element));
            }

            return result;
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            CheckNullElement(source, Source);

            CheckNullElement(predicate, Predicate);

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
            Dictionary<TKey, TElement> dictionary = new Dictionary<TKey, TElement>();

            if (source == null)
            {
                return dictionary;
            }

            foreach (var element in source)
            {
                dictionary.TryAdd(keySelector(element), elementSelector(element));
            }

            return dictionary;
        }

        private static IEnumerable<TResult> InternalSelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach (var element in source)
            {
                yield return selector(element);
            }
        }

        private static void CheckNullElement(object obj, string objName)
        {
            if (obj != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(obj), objName + " argument is null");
        }
    }
}

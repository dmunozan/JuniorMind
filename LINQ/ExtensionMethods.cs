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

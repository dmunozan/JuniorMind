using System;
using System.Collections.Generic;

namespace LINQ
{
    public static class ExtensionMethods
    {
        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "Source argument is null");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate), "Predicate argument is null");
            }

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
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "Source argument is null");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate), "Predicate argument is null");
            }

            foreach (var element in source)
            {
                if (predicate(element))
                {
                    return true;
                }
            }

            return false;
        }
    }
}

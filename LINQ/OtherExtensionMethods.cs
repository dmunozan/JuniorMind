using System;
using System.Collections.Generic;

namespace LINQ
{
    public static class OtherExtensionMethods
    {
        public static IEnumerable<int> Range(int start, int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "count is less than 0");
            }

            if ((long)start + (long)count - 1 > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(start), "the last value of the range is over MaxValue");
            }

            return InternalRange(start, count);
        }

        public static IEnumerable<TResult> Empty<TResult>()
        {
            foreach (var element in new List<TResult>())
            {
                yield return element;
            }
        }

        public static IEnumerable<TResult> Repeat<TResult>(TResult element, int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "count is less than 0");
            }

            return InternalRepeat(element, count);
        }

        public static int Count<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            Console.WriteLine(source + "" + predicate);

            return 0;
        }

        private static IEnumerable<int> InternalRange(int start, int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return start + i;
            }
        }

        private static IEnumerable<TResult> InternalRepeat<TResult>(TResult element, int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return element;
            }
        }
    }
}

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
            CheckNullElement(source);

            CheckNullElement(predicate);

            int count = 0;

            foreach (var element in source)
            {
                if (predicate(element))
                {
                    if (count == int.MaxValue)
                    {
                        throw new OverflowException(nameof(count));
                    }

                    count++;
                }
            }

            return count;
        }

        public static IEnumerable<TSource> Concat<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second)
        {
            List<TSource> concatenatedList = new List<TSource>(first);

            concatenatedList.AddRange(second);

            return concatenatedList.InternalConcat();
        }

        public static TSource LinqSingle<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            CheckNullElement(source);

            CheckNullElement(predicate);

            if (!source.Any(x => true))
            {
                throw new InvalidOperationException("The sequence is empty");
            }

            bool found = false;
            TSource singleElement = default;

            foreach (var element in source)
            {
                if (predicate(element))
                {
                    if (found)
                    {
                        throw new InvalidOperationException("More than one element satisfies the condition");
                    }

                    found = true;
                    singleElement = element;
                }
            }

            if (found)
            {
                return singleElement;
            }

            throw new InvalidOperationException("No element satisfies the condition");
        }

        public static TSource Last<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            CheckNullElement(source);

            CheckNullElement(predicate);

            if (!source.Any(x => true))
            {
                throw new InvalidOperationException("The sequence is empty");
            }

            bool found = false;
            TSource lastElement = default;

            foreach (var element in source)
            {
                if (predicate(element))
                {
                    found = true;
                    lastElement = element;
                }
            }

            if (found)
            {
                return lastElement;
            }

            throw new InvalidOperationException("No element satisfies the condition");
        }

        public static IEnumerable<TSource> TakeWhile<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            CheckNullElement(source);

            CheckNullElement(predicate);

            return source.InternalTakeWhile(predicate);
        }

        public static IEnumerable<TSource> SkipWhile<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            CheckNullElement(source);

            return source.InternalSkipWhile(predicate);
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

        private static IEnumerable<TSource> InternalConcat<TSource>(
            this IEnumerable<TSource> concatenatedList)
        {
            foreach (var element in concatenatedList)
            {
                yield return element;
            }
        }

        private static IEnumerable<TSource> InternalTakeWhile<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            foreach (var element in source)
            {
                if (!predicate(element))
                {
                    yield break;
                }

                yield return element;
            }
        }

        private static IEnumerable<TSource> InternalSkipWhile<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            bool yieldValues = false;

            foreach (var element in source)
            {
                if (yieldValues || !predicate(element))
                {
                    yieldValues = true;
                    yield return element;
                }
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

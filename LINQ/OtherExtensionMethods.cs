using System;
using System.Collections.Generic;

namespace LINQ
{
    public class OtherExtensionMethods
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
            for (int i = 0; i < count; i++)
            {
                yield return element;
            }
        }

        private static IEnumerable<int> InternalRange(int start, int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return start + i;
            }
        }
    }
}

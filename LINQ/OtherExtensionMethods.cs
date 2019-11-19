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

            if (count > 0 && start > int.MaxValue - (count - 1))
            {
                throw new ArgumentOutOfRangeException(nameof(start), "the last value of the range is over MaxValue");
            }

            return InternalRange(start, count);
        }

        private static IEnumerable<int> InternalRange(int start, int count)
        {
            int end = start + count;

            while (start < end)
            {
                yield return start;
                start++;
            }
        }
    }
}

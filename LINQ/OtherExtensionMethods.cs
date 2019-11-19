using System.Collections.Generic;

namespace LINQ
{
    public class OtherExtensionMethods
    {
        public static IEnumerable<int> Range(int start, int count)
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

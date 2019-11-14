using System.Collections;
using System.Collections.Generic;

namespace LINQ
{
    public class IOrderedEnumerable<TElement> : IEnumerable<TElement>
    {
        public IEnumerator<TElement> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}

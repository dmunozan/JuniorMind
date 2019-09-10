using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    public class List<T> : IEnumerable<T>
    {
        public List()
        {
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}

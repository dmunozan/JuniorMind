using System;
using System.Collections;

namespace Collections
{
    public class ObjectArrayEnumerator : IEnumerator
    {
        public ObjectArrayEnumerator()
        {
        }

        public object Current => null;

        public bool MoveNext()
        {
            return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections;

namespace Collections
{
    public class ObjectArrayEnumerator : IEnumerator
    {
        ObjectArrayCollection objectArrayCollection;
        int index;

        public ObjectArrayEnumerator(ObjectArrayCollection objectArrayCollection)
        {
            this.objectArrayCollection = objectArrayCollection;
            index = -1;
        }

        public object Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}

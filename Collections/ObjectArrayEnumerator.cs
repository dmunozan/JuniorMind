using System;
using System.Collections;

namespace Collections
{
    public class ObjectArrayEnumerator : IEnumerator
    {
        readonly ObjectArrayCollection objectArrayCollection;
        readonly int index;
        readonly object currentObject = null;

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

using System;
using System.Collections;

namespace Collections
{
    public class ObjectArrayEnumerator : IEnumerator
    {
        readonly ObjectArrayCollection objectArrayCollection;
        int currentIndex;

        public ObjectArrayEnumerator(ObjectArrayCollection objectArrayCollection)
        {
            this.objectArrayCollection = objectArrayCollection;
            this.currentIndex = -1;
        }

        public object Current
        {
            get
            {
                if (currentIndex == -1)
                {
                    return null;
                }

                return objectArrayCollection[currentIndex];
            }
        }

        public bool MoveNext()
        {
            if (currentIndex == objectArrayCollection.Count - 1)
            {
                return false;
            }

            currentIndex++;
            return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}

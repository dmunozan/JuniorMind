using System;

namespace Collections
{
    public class SingleLinkedList<T>
    {
        public SingleLinkedList()
        {
            Count = 0;
            First = null;
        }

        public int Count { get; private set; }

        public Node<T> First { get; private set; }

        public void AddFirst(Node<T> node)
        {
            this.First = node;
            this.Count++;
        }
    }
}

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
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node), "Not possible to add null to a Single Linked List");
            }

            if (this.First != null)
            {
                node.NextNode = this.First;
            }

            node.List = this;
            this.First = node;
            this.Count++;
        }
    }
}

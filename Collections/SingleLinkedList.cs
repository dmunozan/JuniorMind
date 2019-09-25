using System;

namespace Collections
{
    public class SingleLinkedList<T>
    {
        public SingleLinkedList()
        {
            Count = 0;
            First = null;
            Last = null;
        }

        public int Count { get; private set; }

        public Node<T> First { get; private set; }

        public Node<T> Last { get; set; }

        public void AddFirst(Node<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node), "Not possible to add null to a Single Linked List");
            }

            if (node.List != null)
            {
                throw new InvalidOperationException("Not possible to add the node as it belongs to a different Single Linked List");
            }

            if (this.Count != 0)
            {
                node.NextNode = this.First;
            }
            else
            {
                this.Last = node;
            }

            node.List = this;
            this.First = node;
            this.Count++;
        }

        public Node<T> AddFirst(T value)
        {
            Node<T> node = new Node<T>(value);

            this.AddFirst(node);

            return node;
        }

        public void AddAfter(Node<T> node, Node<T> newNode)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node), "Not possible to add null to a Single Linked List");
            }

            if (newNode == null)
            {
                throw new ArgumentNullException(nameof(newNode), "Not possible to add null to a Single Linked List");
            }

            if (node.List != this)
            {
                throw new InvalidOperationException("Node is not in the current Single Linked List");
            }

            if (newNode.List != null)
            {
                throw new InvalidOperationException("Not possible to add the node as it belongs to a different Single Linked List");
            }

            if (this.Last == node)
            {
                this.Last = newNode;
            }

            newNode.List = this;
            newNode.NextNode = node.NextNode;
            node.NextNode = newNode;
            this.Count++;
        }
    }
}

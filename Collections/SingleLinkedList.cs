using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    public class SingleLinkedList<T> : ICollection<T>
    {
        public SingleLinkedList()
        {
            Count = 0;
            First = null;
            Last = null;
        }

        public int Count { get; private set; }

        public Node<T> First { get; private set; }

        public Node<T> Last { get; private set; }

        public bool IsReadOnly => throw new NotImplementedException();

        public void AddFirst(Node<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node), "Not possible to add null node to a Single Linked List");
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
                throw new ArgumentNullException(nameof(node), "Not possible to search for null in a Single Linked List");
            }

            if (newNode == null)
            {
                throw new ArgumentNullException(nameof(newNode), "Not possible to add null node to a Single Linked List");
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

        public Node<T> AddAfter(Node<T> node, T value)
        {
            Node<T> newNode = new Node<T>(value);

            this.AddAfter(node, newNode);

            return newNode;
        }

        public void AddBefore(Node<T> node, Node<T> newNode)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node), "Not possible to search for null in a Single Linked List");
            }

            if (node.List != this)
            {
                throw new InvalidOperationException("Node is not in the current Single Linked List");
            }

            Node<T> auxNode = this.First;

            if (auxNode == node)
            {
                this.AddFirst(newNode);
                return;
            }

            while (auxNode != null && auxNode.NextNode != node)
            {
                auxNode = auxNode.NextNode;
            }

            this.AddAfter(auxNode, newNode);
        }

        public Node<T> AddBefore(Node<T> node, T value)
        {
            Node<T> newNode = new Node<T>(value);

            this.AddBefore(node, newNode);

            return newNode;
        }

        public void AddLast(Node<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node), "Not possible to add null node to a Single Linked List");
            }

            if (this.Count == 0)
            {
                this.First = node;
            }
            else
            {
                this.Last.NextNode = node;
            }

            this.Last = node;
            node.List = this;
            this.Count++;
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> auxNode = this.First;

            while (auxNode != null)
            {
                yield return auxNode.Value;
                auxNode = auxNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

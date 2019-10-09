using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    public class DoubleLinkedList<T> : ICollection<T>
    {
        const string NullAdd = "nullAdd";
        const string NullSearch = "nullSearch";
        const string NullArray = "nullArray";
        const string NotNullList = "NotNullList";
        const string NotThisList = "NotThisList";

        public DoubleLinkedList()
        {
            Count = 0;
            First = null;
            Last = null;
            IsReadOnly = false;
        }

        public int Count { get; private set; }

        public Node<T> First { get; private set; }

        public Node<T> Last { get; private set; }

        public bool IsReadOnly { get; private set; }

        public void AddFirst(Node<T> node)
        {
            CheckModifiability();

            CheckNullElement(node, NullAdd);

            CheckList(node.List, NotNullList);

            if (this.Count != 0)
            {
                node.NextNode = this.First;
            }
            else
            {
                this.Last = node;
            }

            node.List = new SingleLinkedList<T>(); // this
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
            CheckModifiability();

            CheckNullElement(node, NullSearch);

            CheckNullElement(newNode, NullAdd);

            CheckList(node.List, NotThisList);

            CheckList(newNode.List, NotNullList);

            if (this.Last == node)
            {
                this.Last = newNode;
            }

            newNode.List = new SingleLinkedList<T>(); // this
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
            CheckModifiability();

            CheckNullElement(node, NullSearch);

            CheckList(node.List, NotThisList);

            if (this.First == node)
            {
                this.AddFirst(newNode);
                return;
            }

            this.AddAfter(FindPreviousNode(node), newNode);
        }

        public Node<T> AddBefore(Node<T> node, T value)
        {
            Node<T> newNode = new Node<T>(value);

            this.AddBefore(node, newNode);

            return newNode;
        }

        public void AddLast(Node<T> node)
        {
            CheckModifiability();

            CheckNullElement(node, NullAdd);

            CheckList(node.List, NotNullList);

            if (this.Count == 0)
            {
                this.First = node;
            }
            else
            {
                this.Last.NextNode = node;
            }

            this.Last = node;
            node.List = new SingleLinkedList<T>(); // this
            this.Count++;
        }

        public Node<T> AddLast(T value)
        {
            Node<T> node = new Node<T>(value);

            this.AddLast(node);

            return node;
        }

        public Node<T> Find(T value)
        {
            return Find(value, this.First);
        }

        public Node<T> FindLast(T value)
        {
            Node<T> auxNode = Find(value, this.First);

            Node<T> foundNode = null;

            while (auxNode != null)
            {
                foundNode = auxNode;

                auxNode = Find(value, auxNode.NextNode);
            }

            return foundNode;
        }

        public void Remove(Node<T> node)
        {
            CheckModifiability();

            CheckNullElement(node, NullSearch);

            CheckList(node.List, NotThisList);

            Node<T> previousNode = null;

            if (this.First != node)
            {
                previousNode = FindPreviousNode(node);
                previousNode.NextNode = node.NextNode;
            }
            else
            {
                this.First = node.NextNode;
            }

            if (node == this.Last)
            {
                this.Last = previousNode;
            }

            node.NextNode = null;
            node.List = null;
            this.Count--;
        }

        public void RemoveFirst()
        {
            CheckIfEmpty();

            this.Remove(this.First);
        }

        public void RemoveLast()
        {
            CheckIfEmpty();

            this.Remove(this.Last);
        }

        public void Add(T item)
        {
            this.AddFirst(item);
        }

        public void Clear()
        {
            while (this.Count > 0)
            {
                this.Remove(this.First);
            }
        }

        public bool Contains(T item)
        {
            return this.Find(item) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            CheckNullElement(array, NullArray);

            if (arrayIndex < 0 || arrayIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Index has to be a positive integer smaller than the size of the collection");
            }

            bool isNotLongEnough = array.Length - arrayIndex < this.Count;

            if (isNotLongEnough)
            {
                throw new ArgumentException("There is not enough space from the given index to the end of the array", nameof(array));
            }

            Node<T> auxNode = this.First;

            while (auxNode != null)
            {
                array[arrayIndex] = auxNode.Value;
                arrayIndex++;
                auxNode = auxNode.NextNode;
            }
        }

        public bool Remove(T item)
        {
            if (this.IsReadOnly)
            {
                return false;
            }

            Node<T> foundNode = Find(item);

            if (foundNode == null)
            {
                return false;
            }

            Remove(foundNode);

            return true;
        }

        public void ToReadOnly()
        {
            this.IsReadOnly = true;
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

        private Node<T> FindPreviousNode(Node<T> node)
        {
            Node<T> auxNode = this.First;

            if (auxNode != node)
            {
                while (auxNode != null && auxNode.NextNode != node)
                {
                    auxNode = auxNode.NextNode;
                }
            }

            return auxNode;
        }

        private Node<T> Find(T value, Node<T> startNode)
        {
            while (startNode != null)
            {
                if ((value == null && startNode.Value == null) || startNode.Value.Equals(value))
                {
                    break;
                }

                startNode = startNode.NextNode;
            }

            return startNode;
        }

        private void CheckModifiability()
        {
            if (!this.IsReadOnly)
            {
                return;
            }

            throw new NotSupportedException("The Single Linked List is read only and cannot be modified");
        }

        private void CheckNullElement(object element, string type)
        {
            if (element != null)
            {
                return;
            }

            if (type == "nullAdd")
            {
                throw new ArgumentNullException(nameof(element), "Not possible to add null node to a Single Linked List");
            }

            if (type == "nullSearch")
            {
                throw new ArgumentNullException(nameof(element), "Not possible to search for null in a Single Linked List");
            }

            throw new ArgumentNullException(nameof(element), "The destination array must be a valid array");
        }

        private void CheckList(SingleLinkedList<T> list, string type)
        {
            if (list != null && type == "NotNullList")
            {
                throw new InvalidOperationException("Not possible to add the node as it belongs to a different Single Linked List");
            }

            // this
            if (list == new SingleLinkedList<T>() || type != "NotThisList")
            {
                return;
            }

            throw new InvalidOperationException("Node is not in the current Single Linked List");
        }

        private void CheckIfEmpty()
        {
            if (this.Count > 0)
            {
                return;
            }

            throw new InvalidOperationException("The current Single Linked List is empty");
        }
    }
}
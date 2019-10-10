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

        public DNode<T> First { get; private set; }

        public DNode<T> Last { get; private set; }

        public bool IsReadOnly { get; private set; }

        public void AddFirst(DNode<T> node)
        {
            CheckModifiability();

            CheckNullElement(node, NullAdd);

            CheckList(node.List, NotNullList);

            if (this.Count != 0)
            {
                this.First.PreviousNode = node;
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

        public DNode<T> AddFirst(T value)
        {
            DNode<T> node = new DNode<T>(value);

            this.AddFirst(node);

            return node;
        }

        public void AddAfter(DNode<T> node, DNode<T> newNode)
        {
            CheckModifiability();

            CheckNullElement(node, NullSearch);

            CheckNullElement(newNode, NullAdd);

            CheckList(node.List, NotThisList);

            CheckList(newNode.List, NotNullList);

            newNode.List = this;
            newNode.NextNode = node.NextNode;
            node.NextNode = newNode;
            newNode.PreviousNode = node;
            this.Count++;

            if (this.Last == node)
            {
                this.Last = newNode;
            }
            else
            {
                newNode.NextNode.PreviousNode = newNode;
            }
        }

        public DNode<T> AddAfter(DNode<T> node, T value)
        {
            DNode<T> newNode = new DNode<T>(value);

            this.AddAfter(node, newNode);

            return newNode;
        }

        public void AddBefore(DNode<T> node, DNode<T> newNode)
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

        public DNode<T> AddBefore(DNode<T> node, T value)
        {
            DNode<T> newNode = new DNode<T>(value);

            this.AddBefore(node, newNode);

            return newNode;
        }

        public void AddLast(DNode<T> node)
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
                node.PreviousNode = this.Last;
            }

            this.Last = node;
            node.List = this;
            this.Count++;
        }

        public DNode<T> AddLast(T value)
        {
            DNode<T> node = new DNode<T>(value);

            this.AddLast(node);

            return node;
        }

        public DNode<T> Find(T value)
        {
            return Find(value, this.First);
        }

        public DNode<T> FindLast(T value)
        {
            DNode<T> auxNode = Find(value, this.First);

            DNode<T> foundNode = null;

            while (auxNode != null)
            {
                foundNode = auxNode;

                auxNode = Find(value, auxNode.NextNode);
            }

            return foundNode;
        }

        public void Remove(DNode<T> node)
        {
            CheckModifiability();

            CheckNullElement(node, NullSearch);

            CheckList(node.List, NotThisList);

            DNode<T> previousNode = null;

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

            DNode<T> auxNode = this.First;

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

            DNode<T> foundNode = Find(item);

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
            DNode<T> auxNode = this.First;

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

        private DNode<T> FindPreviousNode(DNode<T> node)
        {
            DNode<T> auxNode = this.First;

            if (auxNode != node)
            {
                while (auxNode != null && auxNode.NextNode != node)
                {
                    auxNode = auxNode.NextNode;
                }
            }

            return auxNode;
        }

        private DNode<T> Find(T value, DNode<T> startNode)
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

        private void CheckList(DoubleLinkedList<T> list, string type)
        {
            if (list != null && type == "NotNullList")
            {
                throw new InvalidOperationException("Not possible to add the node as it belongs to a different Single Linked List");
            }

            if (list == this || type != "NotThisList")
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
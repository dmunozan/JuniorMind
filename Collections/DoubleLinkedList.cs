using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    public class DoubleLinkedList<T> : ICollection<T>
    {
        const string NullAdd = "NullAdd";
        const string NullSearch = "NullSearch";
        const string NullArray = "NullArray";
        const string NotNullList = "NotNullList";
        const string NotThisList = "NotThisList";
        const string RightDirection = "RightDirection";
        const string LeftDirection = "LeftDirection";

        private readonly DNode<T> sentinel = new DNode<T>(default);

        public DoubleLinkedList()
        {
            Count = 0;
            sentinel.NextNode = sentinel;
            sentinel.PreviousNode = sentinel;
            IsReadOnly = false;
        }

        public int Count { get; private set; }

        public DNode<T> First
        {
            get
            {
                if (this.Count == 0)
                {
                    return null;
                }

                return sentinel.NextNode;
            }

            private set
            {
                sentinel.NextNode = value;
            }
        }

        public DNode<T> Last
        {
            get
            {
                if (this.Count == 0)
                {
                    return null;
                }

                return sentinel.PreviousNode;
            }

            private set
            {
                sentinel.PreviousNode = value;
            }
        }

        public bool IsReadOnly { get; private set; }

        public void AddFirst(DNode<T> node)
        {
            CheckModifiability();

            CheckNullElement(node, NullAdd);

            CheckList(node.List, NotNullList);

            node.List = this;
            this.sentinel.NextNode.PreviousNode = node;
            node.NextNode = this.sentinel.NextNode;
            this.sentinel.NextNode = node;
            node.PreviousNode = this.sentinel;
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

            AddAfterNode(node, newNode);
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

            this.AddAfter(node.PreviousNode, newNode);
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

            node.List = this;
            this.sentinel.PreviousNode.NextNode = node;
            node.PreviousNode = this.sentinel.PreviousNode;
            this.sentinel.PreviousNode = node;
            node.NextNode = this.sentinel;
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
            return Find(value, this.First, RightDirection);
        }

        public DNode<T> FindLast(T value)
        {
            return Find(value, this.Last, LeftDirection);
        }

        public void Remove(DNode<T> node)
        {
            CheckModifiability();

            CheckNullElement(node, NullSearch);

            CheckList(node.List, NotThisList);

            node.PreviousNode.NextNode = node.NextNode;
            node.NextNode.PreviousNode = node.PreviousNode;

            node.NextNode = null;
            node.PreviousNode = null;
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

            DNode<T> auxNode = this.sentinel.NextNode;

            while (auxNode != this.sentinel)
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
            DNode<T> auxNode = this.sentinel.NextNode;

            while (auxNode != this.sentinel)
            {
                yield return auxNode.Value;
                auxNode = auxNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private DNode<T> Find(T value, DNode<T> startNode, string direction)
        {
            while (startNode != this.sentinel)
            {
                if ((value == null && startNode.Value == null) || startNode.Value.Equals(value))
                {
                    break;
                }

                startNode = (direction == RightDirection) ? startNode.NextNode : startNode.PreviousNode;
            }

            return (startNode == this.sentinel) ? null : startNode;
        }

        private void AddAfterNode(DNode<T> node, DNode<T> newNode)
        {
            newNode.List = this;
            newNode.NextNode = node.NextNode;
            node.NextNode = newNode;
            newNode.PreviousNode = node;
            newNode.NextNode.PreviousNode = newNode;
            this.Count++;
        }

        private void CheckModifiability()
        {
            if (!this.IsReadOnly)
            {
                return;
            }

            throw new NotSupportedException("The Double Linked List is read only and cannot be modified");
        }

        private void CheckNullElement(object element, string type)
        {
            if (element != null)
            {
                return;
            }

            if (type == "NullAdd")
            {
                throw new ArgumentNullException(nameof(element), "Not possible to add null node to a Double Linked List");
            }

            if (type == "NullSearch")
            {
                throw new ArgumentNullException(nameof(element), "Not possible to search a null node in a Double Linked List");
            }

            throw new ArgumentNullException(nameof(element), "The destination array must be a valid array");
        }

        private void CheckList(DoubleLinkedList<T> list, string type)
        {
            if (list != null && type == "NotNullList")
            {
                throw new InvalidOperationException("Not possible to add the node as it belongs to a different Double Linked List");
            }

            if (list == this || type != "NotThisList")
            {
                return;
            }

            throw new InvalidOperationException("Node is not in the current Double Linked List");
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
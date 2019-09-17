using System;
using System.Collections.Generic;
using System.Text;

namespace Collections
{
    public class Node<T>
    {
        public Node(T value)
        {
            Value = value;
        }

        public T Value { get; }
    }
}

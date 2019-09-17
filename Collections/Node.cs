namespace Collections
{
    public class Node<T>
    {
        public Node(T value)
        {
            Value = value;
            NextNode = null;
        }

        public T Value { get; }

        public Node<T> NextNode { get; set; }
    }
}

namespace Collections
{
    public class DNode<T>
    {
        public DNode(T value)
        {
            Value = value;
            PreviousNode = null;
            NextNode = null;
            List = null;
        }

        public T Value { get; }

        public DNode<T> PreviousNode { get; set; }

        public DNode<T> NextNode { get; set; }

        public DoubleLinkedList<T> List { get; set; }
    }
}

namespace Collections
{
    public class SingleLinkedList<T>
    {
        public SingleLinkedList()
        {
            Count = 0;
            First = null;
        }

        public int Count { get; }

        public Node<T> First { get; }
    }
}

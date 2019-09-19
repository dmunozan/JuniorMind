namespace Collections
{
    public class Node<T>
    {
        public Node(T value)
        {
            Value = value;
            NextNode = null;
            List = null;
        }

        public T Value { get; }

        public Node<T> NextNode { get; set; }

        public SingleLinkedList<T> List { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Node<T> objNode = (Node<T>)obj;
            return Value.Equals(objNode.Value);
        }
    }
}

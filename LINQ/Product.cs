namespace LINQ
{
    public class Product
    {
        readonly int quantity;

        public Product(string name, int quantity)
        {
            Name = name;
            this.quantity = quantity;
        }

        public string Name { get; set; }
    }
}

using System.Collections.Generic;

namespace LINQ
{
    public class Product
    {
        public Product(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
            Features = new List<Feature>();
        }

        public Product(string name, int quantity, ICollection<Feature> features)
        {
            Name = name;
            Quantity = quantity;
            Features = features;
        }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public ICollection<Feature> Features { get; }
    }
}

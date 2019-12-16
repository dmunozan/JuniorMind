using System;
using System.Collections;
using System.Collections.Generic;

namespace LINQ
{
    public class Stock : IEnumerable
    {
        readonly Dictionary<string, Product> productList;

        public Stock()
        {
            productList = new Dictionary<string, Product>();
        }

        public void Add(Product product)
        {
            if (product == null)
            {
                return;
            }

            productList.Add(product.Name, product);
        }

        public int Check(Product product)
        {
            if (product == null)
            {
                return -1;
            }

            if (productList.ContainsKey(product.Name))
            {
                return productList[product.Name].Quantity;
            }

            return -1;
        }

        public IEnumerator GetEnumerator()
        {
            return productList.GetEnumerator();
        }
    }
}

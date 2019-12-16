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

        public int Check(Product product)
        {
            Console.WriteLine(product);

            return -1;
        }

        public IEnumerator GetEnumerator()
        {
            return productList.GetEnumerator();
        }
    }
}

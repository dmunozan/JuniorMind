using System;
using System.Collections;
using System.Collections.Generic;

namespace LINQ
{
    public delegate void ProcessProduct(Product product);

    public class Stock : IEnumerable
    {
        readonly Dictionary<string, Product> productList;

        public Stock()
        {
            productList = new Dictionary<string, Product>();
        }

        public void Add(Product product)
        {
            CheckNullArgument(product);

            if (productList.ContainsKey(product.Name))
            {
                productList[product.Name].Quantity += product.Quantity;
            }
            else
            {
                productList.Add(product.Name, product);
            }
        }

        public bool Remove(Product product, ProcessProduct processProduct)
        {
            CheckNullArgument(product);

            CheckNullArgument(processProduct);

            const int FirstNotificationLimit = 10;

            if (!productList.ContainsKey(product.Name))
            {
                return false;
            }

            int leftAmount = productList[product.Name].Quantity - product.Quantity;

            if (leftAmount < 0)
            {
                processProduct(productList[product.Name]);
                return false;
            }

            productList[product.Name].Quantity = leftAmount;

            if (leftAmount >= FirstNotificationLimit)
            {
                return true;
            }

            processProduct(productList[product.Name]);
            return true;
        }

        public int Check(Product product)
        {
            CheckNullArgument(product);

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

        private void CheckNullArgument(object obj)
        {
            if (obj != null)
            {
                return;
            }

            const string errorMessage = nameof(obj) + " cannot be null";

            throw new ArgumentNullException(nameof(obj), errorMessage);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public delegate void ProcessProduct(Product product);

    public class Stock : IEnumerable
    {
        readonly Dictionary<string, Product> productList;
        readonly ProcessProduct processProduct;

        public Stock(ProcessProduct processProduct)
        {
            CheckNullArgument(processProduct);

            productList = new Dictionary<string, Product>();
            this.processProduct = processProduct;
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

        public bool Remove(Product product)
        {
            CheckNullArgument(product);

            if (!productList.ContainsKey(product.Name))
            {
                return false;
            }

            int initialAmount = productList[product.Name].Quantity;
            int leftAmount = initialAmount - product.Quantity;

            if (leftAmount < 0)
            {
                return false;
            }

            productList[product.Name].Quantity = leftAmount;

            CheckNotification(initialAmount, leftAmount, productList[product.Name]);

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

        private void CheckNotification(int initialAmount, int leftAmount, Product product)
        {
            int[] notifications = { 9, 4, 1 };

            int limit = notifications.First(n => initialAmount > n || n == notifications[^1]);

            if (initialAmount <= limit || leftAmount > limit)
            {
                return;
            }

            processProduct(product);
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

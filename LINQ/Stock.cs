using System;
using System.Collections;
using System.Collections.Generic;

namespace LINQ
{
    public class Stock : IEnumerable
    {
        readonly Dictionary<string, Product> productList;

        readonly Action<Product> lowAmountNotification =
            product => Console.WriteLine(
                "There are {0} {1} left", product.Quantity, product);

        readonly Action<Product> notEnoughNotification =
            product => Console.WriteLine(
                "There are not enough {0} to satisfy the request. Only {1} left.", product, product.Quantity);

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

        public bool Remove(Product product)
        {
            CheckNullArgument(product);

            const int FirstNotificationLimit = 10;

            if (!productList.ContainsKey(product.Name))
            {
                return false;
            }

            int leftAmount = productList[product.Name].Quantity - product.Quantity;

            if (leftAmount < 0)
            {
                notEnoughNotification(product);
                return false;
            }

            productList[product.Name].Quantity = leftAmount;

            if (productList[product.Name].Quantity >= FirstNotificationLimit)
            {
                return true;
            }

            lowAmountNotification(productList[product.Name]);
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

        private void CheckNullArgument(Product product)
        {
            if (product != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(product), "Product cannot be null");
        }
    }
}

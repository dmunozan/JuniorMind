﻿using System;
using System.Collections;
using System.Collections.Generic;

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

            const int FirstNotificationLimit = 10;

            if (!productList.ContainsKey(product.Name))
            {
                return false;
            }

            int leftAmount = productList[product.Name].Quantity - product.Quantity;

            if (leftAmount < 0)
            {
                return false;
            }

            if (productList[product.Name].Quantity < FirstNotificationLimit)
            {
                processProduct(productList[product.Name]);
            }

            productList[product.Name].Quantity = leftAmount;

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

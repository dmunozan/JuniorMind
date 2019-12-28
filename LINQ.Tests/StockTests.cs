using System;
using Xunit;

namespace LINQ.Tests
{
    public class StockTests
    {
        [Fact]
        public void StockWhenAnyShouldCreateEmptyStock()
        {
            bool notificationSent = false;

            Action<Product> notification =
            product =>
            {
                // Notification will not be sent at any given moment
                notificationSent = true;
            };

            ProcessProduct testNotification = new ProcessProduct(notification);

            Stock stockTest = new Stock(testNotification);

            Assert.Empty(stockTest);
            Assert.False(notificationSent);
        }

        [Fact]
        public void StockWhenNullProcessProductShouldThrowException()
        {
            bool notificationSent = false;

            Action<Product> notification =
            product =>
            {
                // Notification will not be sent at any given moment
                notificationSent = true;
            };

            ProcessProduct testNotification = null;

            Stock stockTest;

            Assert.Throws<ArgumentNullException>(() => stockTest = new Stock(testNotification));
            Assert.False(notificationSent);
        }

        [Fact]
        public void AddWhenProductNoExistShouldAddProduct()
        {
            bool notificationSent = false;

            Action<Product> notification =
            product =>
            {
                // Notification will not be sent at any given moment
                notificationSent = true;
            };

            ProcessProduct testNotification = new ProcessProduct(notification);

            Stock stockTest = new Stock(testNotification);

            Product testProduct = new Product("apricot", 8);

            stockTest.Add(testProduct);

            Assert.Equal(8, stockTest.Check(testProduct));
            Assert.False(notificationSent);
        }

        [Fact]
        public void AddWhenProductExistShouldIncreaseQuantity()
        {
            bool notificationSent = false;

            Action<Product> notification =
            product =>
            {
                // Notification will not be sent at any given moment
                notificationSent = true;
            };

            ProcessProduct testNotification = new ProcessProduct(notification);

            Stock stockTest = new Stock(testNotification);

            Product testProduct = new Product("apricot", 8);

            stockTest.Add(testProduct);
            stockTest.Add(testProduct);

            Assert.Equal(16, stockTest.Check(testProduct));
            Assert.False(notificationSent);
        }

        [Fact]
        public void AddWhenNullProductShouldThrowException()
        {
            bool notificationSent = false;

            Action<Product> notification =
            product =>
            {
                // Notification will not be sent at any given moment
                notificationSent = true;
            };

            ProcessProduct testNotification = new ProcessProduct(notification);

            Stock stockTest = new Stock(testNotification);

            Product testProduct = null;

            Assert.Throws<ArgumentNullException>(() => stockTest.Add(testProduct));
            Assert.False(notificationSent);
        }

        [Fact]
        public void RemoveWhenProductExistAndThereIsAtLeast10ProductsLeftShouldReturnTrueAndRemoveQuantity()
        {
            bool notificationSent = false;

            Action<Product> notification =
            product =>
            {
                // Notification will not be sent at any given moment
                notificationSent = true;
            };

            ProcessProduct testNotification = new ProcessProduct(notification);

            Stock stockTest = new Stock(testNotification);

            Product testProduct = new Product("apricot", 16);

            stockTest.Add(testProduct);

            Product productToRemove = new Product("apricot", 6);

            Assert.True(stockTest.Remove(productToRemove));
            Assert.Equal(10, stockTest.Check(testProduct));
            Assert.False(notificationSent);
        }

        [Fact]
        public void RemoveWhenThereIsLessThan10ProductsShouldSendNotification()
        {
            Product testProduct = new Product("apricot", 9);

            Product notifiedProduct = null;

            Action<Product> notification =
            product =>
            {
                notifiedProduct = product;
            };

            ProcessProduct testNotification = new ProcessProduct(notification);

            Stock stockTest = new Stock(testNotification);

            stockTest.Add(testProduct);

            Product productToRemove = new Product("apricot", 7);

            Assert.True(stockTest.Remove(productToRemove));
            Assert.Equal(2, stockTest.Check(testProduct));
            Assert.Equal(testProduct.Name, notifiedProduct.Name);
            Assert.Equal(2, notifiedProduct.Quantity);
        }

        [Fact]
        public void RemoveWhenProductExistAndThereIsNotEnoughProductsShouldReturnFalse()
        {
            Product testProduct = new Product("apricot", 16);

            bool notificationSent = false;

            Action<Product> notification =
            product =>
            {
                // Notification will not be sent at any given moment
                notificationSent = true;
            };

            ProcessProduct testNotification = new ProcessProduct(notification);

            Stock stockTest = new Stock(testNotification);

            stockTest.Add(testProduct);

            Product productToRemove = new Product("apricot", 20);

            Assert.False(stockTest.Remove(productToRemove));

            Assert.Equal(16, stockTest.Check(new Product("apricot", 0)));
            Assert.False(notificationSent);
        }

        [Fact]
        public void RemoveWhenProductNoExistShouldReturnFalse()
        {
            bool notificationSent = false;

            Action<Product> notification =
            product =>
            {
                // Notification will not be sent at any given moment
                notificationSent = true;
            };

            ProcessProduct testNotification = new ProcessProduct(notification);

            Stock stockTest = new Stock(testNotification);

            Product productToRemove = new Product("apricot", 6);

            Assert.False(stockTest.Remove(productToRemove));
            Assert.False(notificationSent);
        }

        [Fact]
        public void RemoveWhenNullProductShouldThrowException()
        {
            Product testProduct = null;

            bool notificationSent = false;

            Action<Product> notification =
            product =>
            {
                // Notification will not be sent at any given moment
                notificationSent = true;
            };

            ProcessProduct testNotification = new ProcessProduct(notification);

            Stock stockTest = new Stock(testNotification);

            Assert.Throws<ArgumentNullException>(() => stockTest.Remove(testProduct));
            Assert.False(notificationSent);
        }

        [Fact]
        public void CheckWhenProductNoExistShouldReturnMinus1()
        {
            Product testProduct = new Product("apricot", 8);

            bool notificationSent = false;

            Action<Product> notification =
            product =>
            {
                // Notification will not be sent at any given moment
                notificationSent = true;
            };

            ProcessProduct testNotification = new ProcessProduct(notification);

            Stock stockTest = new Stock(testNotification);

            Assert.Equal(-1, stockTest.Check(testProduct));
            Assert.False(notificationSent);
        }

        [Fact]
        public void CheckWhenProductExistShouldReturnQuantity()
        {
            Product testProduct = new Product("apricot", 8);

            bool notificationSent = false;

            Action<Product> notification =
            product =>
            {
                // Notification will not be sent at any given moment
                notificationSent = true;
            };

            ProcessProduct testNotification = new ProcessProduct(notification);

            Stock stockTest = new Stock(testNotification);

            stockTest.Add(testProduct);

            Assert.Equal(8, stockTest.Check(testProduct));
            Assert.False(notificationSent);
        }

        [Fact]
        public void CheckWhenNullProductShouldThrowException()
        {
            Product testProduct = null;

            bool notificationSent = false;

            Action<Product> notification =
            product =>
            {
                // Notification will not be sent at any given moment
                notificationSent = true;
            };

            ProcessProduct testNotification = new ProcessProduct(notification);

            Stock stockTest = new Stock(testNotification);

            Assert.Throws<ArgumentNullException>(() => stockTest.Check(testProduct));
            Assert.False(notificationSent);
        }
    }
}

using System;
using Xunit;

namespace LINQ.Tests
{
    public class StockTests
    {
        [Fact]
        public void StockWhenAnyShouldCreateEmptyStock()
        {
            Action<Product> notification =
            product =>
            {
                // Notification will not be sent at any given moment
                Assert.True(false);
            };

            ProcessProduct testNotification = new ProcessProduct(notification);

            Stock stockTest = new Stock(testNotification);

            Assert.Empty(stockTest);
        }

        [Fact]
        public void StockWhenNullProcessProductShouldThrowException()
        {
            Action<Product> notification =
            product =>
            {
                // Notification will not be sent at any given moment
                Assert.True(false);
            };

            ProcessProduct testNotification = null;

            Stock stockTest;

            Assert.Throws<ArgumentNullException>(() => stockTest = new Stock(testNotification));
        }

        [Fact]
        public void AddWhenProductNoExistShouldAddProduct()
        {
            Action<Product> notification =
            product =>
            {
                // Notification will not be sent at any given moment
                Assert.True(false);
            };

            ProcessProduct testNotification = new ProcessProduct(notification);

            Stock stockTest = new Stock(testNotification);

            Product testProduct = new Product("apricot", 8);

            stockTest.Add(testProduct);

            Assert.Equal(8, stockTest.Check(testProduct));
        }

        [Fact]
        public void AddWhenProductExistShouldIncreaseQuantity()
        {
            Action<Product> notification =
            product =>
            {
                // Notification will not be sent at any given moment
                Assert.True(false);
            };

            ProcessProduct testNotification = new ProcessProduct(notification);

            Stock stockTest = new Stock(testNotification);

            Product testProduct = new Product("apricot", 8);

            stockTest.Add(testProduct);
            stockTest.Add(testProduct);

            Assert.Equal(16, stockTest.Check(testProduct));
        }

        [Fact]
        public void AddWhenNullProductShouldThrowException()
        {
            Action<Product> notification =
            product =>
            {
                // Notification will not be sent at any given moment
                Assert.True(false);
            };

            ProcessProduct testNotification = new ProcessProduct(notification);

            Stock stockTest = new Stock(testNotification);

            Product testProduct = null;

            Assert.Throws<ArgumentNullException>(() => stockTest.Add(testProduct));
        }

        [Fact]
        public void RemoveWhenProductExistAndThereIsAtLeast10ProductsLeftShouldReturnTrueAndRemoveQuantity()
        {
            Action<Product> notification =
            product =>
            {
                // Notification will not be sent at any given moment
                Assert.True(false);
            };

            ProcessProduct testNotification = new ProcessProduct(notification);

            Stock stockTest = new Stock(testNotification);

            Product testProduct = new Product("apricot", 16);

            stockTest.Add(testProduct);

            Product productToRemove = new Product("apricot", 6);

            Assert.True(stockTest.Remove(productToRemove));
            Assert.Equal(10, stockTest.Check(testProduct));
        }

        [Fact]
        public void RemoveWhenThereIsLessThan10ProductsShouldSendNotification()
        {
            Product testProduct = new Product("apricot", 9);

            Action<Product> notification =
            product =>
            {
                Assert.Equal(testProduct, product);
                Assert.Equal(9, product.Quantity);
            };

            ProcessProduct testNotification = new ProcessProduct(notification);

            Stock stockTest = new Stock(testNotification);

            stockTest.Add(testProduct);

            Product productToRemove = new Product("apricot", 7);

            Assert.True(stockTest.Remove(productToRemove));
            Assert.Equal(2, stockTest.Check(testProduct));
        }

        [Fact]
        public void RemoveWhenProductExistAndThereIsNotEnoughProductsShouldReturnFalse()
        {
            Product testProduct = new Product("apricot", 16);

            Action<Product> notification =
            product =>
            {
                // Notification will not be sent at any given moment
                Assert.True(false);
            };

            ProcessProduct testNotification = new ProcessProduct(notification);

            Stock stockTest = new Stock(testNotification);

            stockTest.Add(testProduct);

            Product productToRemove = new Product("apricot", 20);

            Assert.False(stockTest.Remove(productToRemove));

            Assert.Equal(16, stockTest.Check(new Product("apricot", 0)));
        }

        [Fact]
        public void RemoveWhenProductNoExistShouldReturnFalse()
        {
            Action<Product> notification =
            product =>
            {
                // Notification will not be sent at any given moment
                Assert.True(false);
            };

            ProcessProduct testNotification = new ProcessProduct(notification);

            Stock stockTest = new Stock(testNotification);

            Product productToRemove = new Product("apricot", 6);

            Assert.False(stockTest.Remove(productToRemove));
        }

        [Fact]
        public void RemoveWhenNullProductShouldThrowException()
        {
            Product testProduct = null;

            Action<Product> notification =
            product =>
            {
                // Notification will not be sent at any given moment
                Assert.True(false);
            };

            ProcessProduct testNotification = new ProcessProduct(notification);

            Stock stockTest = new Stock(testNotification);

            Assert.Throws<ArgumentNullException>(() => stockTest.Remove(testProduct));
        }

        [Fact]
        public void CheckWhenProductNoExistShouldReturnMinus1()
        {
            Product testProduct = new Product("apricot", 8);

            Action<Product> notification =
            product =>
            {
                // Notification will not be sent at any given moment
                Assert.True(false);
            };

            ProcessProduct testNotification = new ProcessProduct(notification);

            Stock stockTest = new Stock(testNotification);

            Assert.Equal(-1, stockTest.Check(testProduct));
        }

        [Fact]
        public void CheckWhenProductExistShouldReturnQuantity()
        {
            Product testProduct = new Product("apricot", 8);

            Action<Product> notification =
            product =>
            {
                // Notification will not be sent at any given moment
                Assert.True(false);
            };

            ProcessProduct testNotification = new ProcessProduct(notification);

            Stock stockTest = new Stock(testNotification);

            stockTest.Add(testProduct);

            Assert.Equal(8, stockTest.Check(testProduct));
        }

        [Fact]
        public void CheckWhenNullProductShouldThrowException()
        {
            Product testProduct = null;

            Action<Product> notification =
            product =>
            {
                // Notification will not be sent at any given moment
                Assert.True(false);
            };

            ProcessProduct testNotification = new ProcessProduct(notification);

            Stock stockTest = new Stock(testNotification);

            Assert.Throws<ArgumentNullException>(() => stockTest.Check(testProduct));
        }
    }
}

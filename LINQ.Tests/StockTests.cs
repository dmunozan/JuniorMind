using System;
using Xunit;

namespace LINQ.Tests
{
    public class StockTests
    {
        [Fact]
        public void StockWhenAnyShouldCreateEmptyStock()
        {
            Stock stockTest = new Stock();

            Assert.Empty(stockTest);
        }

        [Fact]
        public void AddWhenProductNoExistShouldAddProduct()
        {
            Stock stockTest = new Stock();

            Product testProduct = new Product("apricot", 8);

            stockTest.Add(testProduct);

            Assert.Equal(8, stockTest.Check(testProduct));
        }

        [Fact]
        public void AddWhenProductExistShouldIncreaseQuantity()
        {
            Stock stockTest = new Stock();

            Product testProduct = new Product("apricot", 8);

            stockTest.Add(testProduct);
            stockTest.Add(testProduct);

            Assert.Equal(16, stockTest.Check(testProduct));
        }

        [Fact]
        public void AddWhenNullProductShouldThrowException()
        {
            Stock stockTest = new Stock();

            Product testProduct = null;

            Assert.Throws<ArgumentNullException>(() => stockTest.Add(testProduct));
        }

        [Fact]
        public void RemoveWhenProductExistAndThereIsAtLeast10ProductsLeftShouldReturnTrueAndRemoveQuantity()
        {
            Stock stockTest = new Stock();

            Product testProduct = new Product("apricot", 16);

            stockTest.Add(testProduct);

            Product productToRemove = new Product("apricot", 6);

            Action<Product> notification =
            product =>
            {
                // Notification will not be sent
                Assert.Equal(testProduct, product);
                Assert.Equal(10, product.Quantity);
            };

            ProcessProduct testNotification = new ProcessProduct(notification);

            Assert.True(stockTest.Remove(productToRemove, testNotification));
            Assert.Equal(10, stockTest.Check(testProduct));
        }

        [Fact]
        public void RemoveWhenProductExistAndThereIs9ProductsLeftShouldReturnTrueRemoveQuantityAndSendNotification()
        {
            Stock stockTest = new Stock();

            Product testProduct = new Product("apricot", 16);

            stockTest.Add(testProduct);

            Product productToRemove = new Product("apricot", 7);

            Action<Product> notification =
            product =>
            {
                Assert.Equal(testProduct, product);
                Assert.Equal(9, product.Quantity);
            };

            ProcessProduct testNotification = new ProcessProduct(notification);

            Assert.True(stockTest.Remove(productToRemove, testNotification));
            Assert.Equal(9, stockTest.Check(testProduct));
        }

        [Fact]
        public void RemoveWhenProductExistAndThereIs5ProductsLeftShouldReturnTrueRemoveQuantityAndSendNotification()
        {
            Stock stockTest = new Stock();

            Product testProduct = new Product("apricot", 16);

            stockTest.Add(testProduct);

            Product productToRemove = new Product("apricot", 11);

            Action<Product> notification =
            product =>
            {
                Assert.Equal(testProduct, product);
                Assert.Equal(5, product.Quantity);
            };

            ProcessProduct testNotification = new ProcessProduct(notification);

            Assert.True(stockTest.Remove(productToRemove, testNotification));
            Assert.Equal(5, stockTest.Check(testProduct));
        }

        [Fact]
        public void RemoveWhenProductExistAndThereIs4ProductsLeftShouldReturnTrueRemoveQuantityAndSendNotification()
        {
            Stock stockTest = new Stock();

            Product testProduct = new Product("apricot", 16);

            stockTest.Add(testProduct);

            Product productToRemove = new Product("apricot", 12);

            Action<Product> notification =
            product =>
            {
                Assert.Equal(testProduct, product);
                Assert.Equal(4, product.Quantity);
            };

            ProcessProduct testNotification = new ProcessProduct(notification);

            Assert.True(stockTest.Remove(productToRemove, testNotification));
            Assert.Equal(4, stockTest.Check(testProduct));
        }

        [Fact]
        public void RemoveWhenProductExistAndThereIs2ProductsLeftShouldReturnTrueRemoveQuantityAndSendNotification()
        {
            Stock stockTest = new Stock();

            Product testProduct = new Product("apricot", 16);

            stockTest.Add(testProduct);

            Product productToRemove = new Product("apricot", 14);

            Action<Product> notification =
            product =>
            {
                Assert.Equal(testProduct, product);
                Assert.Equal(2, product.Quantity);
            };

            ProcessProduct testNotification = new ProcessProduct(notification);

            Assert.True(stockTest.Remove(productToRemove, testNotification));
            Assert.Equal(2, stockTest.Check(testProduct));
        }

        [Fact]
        public void RemoveWhenProductExistAndThereIs1ProductsLeftShouldReturnTrueRemoveQuantityAndSendNotification()
        {
            Stock stockTest = new Stock();

            Product testProduct = new Product("apricot", 16);

            stockTest.Add(testProduct);

            Product productToRemove = new Product("apricot", 15);

            Action<Product> notification =
            product =>
            {
                Assert.Equal(testProduct, product);
                Assert.Equal(1, product.Quantity);
            };

            ProcessProduct testNotification = new ProcessProduct(notification);

            Assert.True(stockTest.Remove(productToRemove, testNotification));
            Assert.Equal(1, stockTest.Check(testProduct));
        }

        [Fact]
        public void RemoveWhenProductExistAndThereIs0ProductsLeftShouldReturnTrueRemoveQuantityAndSendNotification()
        {
            Stock stockTest = new Stock();

            Product testProduct = new Product("apricot", 16);

            stockTest.Add(testProduct);

            Product productToRemove = new Product("apricot", 16);

            Action<Product> notification =
            product =>
            {
                Assert.Equal(testProduct, product);
                Assert.Equal(0, product.Quantity);
            };

            ProcessProduct testNotification = new ProcessProduct(notification);

            Assert.True(stockTest.Remove(productToRemove, testNotification));
            Assert.Equal(0, stockTest.Check(testProduct));
        }

        [Fact]
        public void RemoveWhenProductExistAndThereIsNotEnoughProductsShouldReturnFalseAndSendNotification()
        {
            Stock stockTest = new Stock();

            Product testProduct = new Product("apricot", 16);

            stockTest.Add(testProduct);

            Product productToRemove = new Product("apricot", 20);

            Action<Product> notification =
            product =>
            {
                Assert.Equal(testProduct, product);
                Assert.Equal(16, product.Quantity);
            };

            ProcessProduct testNotification = new ProcessProduct(notification);

            Assert.False(stockTest.Remove(productToRemove, testNotification));

            Assert.Equal(16, stockTest.Check(new Product("apricot", 0)));
        }

        [Fact]
        public void RemoveWhenProductNoExistShouldReturnFalse()
        {
            Stock stockTest = new Stock();

            Product productToRemove = new Product("apricot", 6);

            Action<Product> notification =
            product =>
            {
                // Notification will not be sent
                Assert.Equal(new Product("apricot", 6), product);
                Assert.Equal(16, product.Quantity);
            };

            ProcessProduct testNotification = new ProcessProduct(notification);

            Assert.False(stockTest.Remove(productToRemove, testNotification));
        }

        [Fact]
        public void RemoveWhenNullProcessProductShouldThrowException()
        {
            Stock stockTest = new Stock();

            Product testProduct = new Product("apricot", 16);

            Action<Product> notification =
            product =>
            {
                // Notification will not be sent
                Assert.Equal(testProduct, product);
                Assert.Equal(16, product.Quantity);
            };

            ProcessProduct testNotification = null;

            Assert.Throws<ArgumentNullException>(() => stockTest.Remove(testProduct, testNotification));
        }

        [Fact]
        public void RemoveWhenNullProductShouldThrowException()
        {
            Stock stockTest = new Stock();

            Product testProduct = null;

            Action<Product> notification =
            product =>
            {
                // Notification will not be sent
                Assert.Equal(testProduct, product);
                Assert.Equal(16, product.Quantity);
            };

            ProcessProduct testNotification = new ProcessProduct(notification);

            Assert.Throws<ArgumentNullException>(() => stockTest.Remove(testProduct, testNotification));
        }

        [Fact]
        public void CheckWhenProductNoExistShouldReturnMinus1()
        {
            Stock stockTest = new Stock();

            Product testProduct = new Product("apricot", 8);

            Assert.Equal(-1, stockTest.Check(testProduct));
        }

        [Fact]
        public void CheckWhenProductExistShouldReturnQuantity()
        {
            Stock stockTest = new Stock();

            Product testProduct = new Product("apricot", 8);

            stockTest.Add(testProduct);

            Assert.Equal(8, stockTest.Check(testProduct));
        }

        [Fact]
        public void CheckWhenNullProductShouldThrowException()
        {
            Stock stockTest = new Stock();

            Product testProduct = null;

            Assert.Throws<ArgumentNullException>(() => stockTest.Check(testProduct));
        }
    }
}

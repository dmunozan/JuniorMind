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

            Assert.True(stockTest.Remove(productToRemove));
            Assert.Equal(10, stockTest.Check(testProduct));
        }

        [Fact]
        public void RemoveWhenProductExistAndThereIsBetween5And9ProductsLeftShouldReturnTrueRemoveQuantityAndSendNotification()
        {
            Stock stockTest = new Stock();

            stockTest.Add(new Product("apricot", 16));
            stockTest.Add(new Product("orange", 16));

            Assert.True(stockTest.Remove(new Product("apricot", 7)));
            Assert.True(stockTest.Remove(new Product("orange", 11)));

            Assert.Equal(9, stockTest.Check(new Product("apricot", 0)));
            Assert.Equal(5, stockTest.Check(new Product("orange", 0)));
        }

        [Fact]
        public void RemoveWhenProductExistAndThereIsBetween2And4ProductsLeftShouldReturnTrueRemoveQuantityAndSendNotification()
        {
            Stock stockTest = new Stock();

            stockTest.Add(new Product("apricot", 16));
            stockTest.Add(new Product("orange", 16));

            Assert.True(stockTest.Remove(new Product("apricot", 12)));
            Assert.True(stockTest.Remove(new Product("orange", 14)));

            Assert.Equal(4, stockTest.Check(new Product("apricot", 0)));
            Assert.Equal(2, stockTest.Check(new Product("orange", 0)));
        }

        [Fact]
        public void RemoveWhenProductExistAndThereIsLessThan2ProductsLeftShouldReturnTrueRemoveQuantityAndSendNotification()
        {
            Stock stockTest = new Stock();

            stockTest.Add(new Product("apricot", 16));
            stockTest.Add(new Product("orange", 16));

            Assert.True(stockTest.Remove(new Product("apricot", 15)));
            Assert.True(stockTest.Remove(new Product("orange", 16)));

            Assert.Equal(1, stockTest.Check(new Product("apricot", 0)));
            Assert.Equal(0, stockTest.Check(new Product("orange", 0)));
        }

        [Fact]
        public void RemoveWhenProductExistAndThereIsNotEnoughProductsAnd10OrMoreLeftShouldReturnFalse()
        {
            Stock stockTest = new Stock();

            stockTest.Add(new Product("apricot", 16));

            Assert.False(stockTest.Remove(new Product("apricot", 20)));

            Assert.Equal(16, stockTest.Check(new Product("apricot", 0)));
        }

        [Fact]
        public void RemoveWhenProductNoExistShouldReturnFalse()
        {
            Stock stockTest = new Stock();

            Product productToRemove = new Product("apricot", 6);

            Assert.False(stockTest.Remove(productToRemove));
        }

        [Fact]
        public void RemoveWhenNullProductShouldThrowException()
        {
            Stock stockTest = new Stock();

            Product testProduct = null;

            Assert.Throws<ArgumentNullException>(() => stockTest.Remove(testProduct));
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

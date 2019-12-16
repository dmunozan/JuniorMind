﻿using System;
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
        public void CheckWhenNullProductShouldReturnMinus1()
        {
            Stock stockTest = new Stock();

            Product testProduct = null;

            Assert.Equal(-1, stockTest.Check(testProduct));
        }
    }
}
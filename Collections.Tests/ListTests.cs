using System;
using System.Collections.Generic;
using Xunit;

namespace Collections.Tests
{
    public class ListTests
    {
        [Fact]
        public void CountWhenEmptyShouldReturn0()
        {
            List<int> listTest = new List<int>();

            Assert.Equal(0, listTest.Count);
        }

        [Fact]
        public void AddWhenEmptyShouldReturnCount1()
        {
            List<int> listTest = new List<int>();
            listTest.Add(4);

            Assert.Equal(1, listTest.Count);
        }

        [Fact]
        public void IndexOfTextShouldReturn0()
        {
            List<string> listTest = new List<string>();
            listTest.Add("test");

            Assert.Equal(0, listTest.IndexOf("test"));
        }

        [Fact]
        public void IndexOfWhenNoExistsShouldReturnMinus1()
        {
            List<string> listTest = new List<string>();
            listTest.Add("test");

            Assert.Equal(-1, listTest.IndexOf("noTest"));
        }

        [Fact]
        public void ContainsWhenExistShouldReturnTrue()
        {
            List<string> listTest = new List<string>();
            listTest.Add("test");

            Assert.True(listTest.Contains("test"));
        }

        [Fact]
        public void ClearWhenAnyShouldReturnCount0()
        {
            List<string> listTest = new List<string>();
            listTest.Add("test");

            listTest.Clear();

            Assert.Equal(0, listTest.Count);
        }

        [Fact]
        public void IndexOfWhenNoExistAfterClearShouldReturnMinus1()
        {
            List<string> listTest = new List<string>();
            listTest.Add("test");

            listTest.Clear();

            Assert.Equal(-1, listTest.IndexOf("test"));
        }

        [Fact]
        public void ContainsWhenNoExistAfterClearShouldReturnFalse()
        {
            List<string> listTest = new List<string>();
            listTest.Add("test");

            listTest.Clear();

            Assert.False(listTest.Contains("test"));
        }

        [Fact]
        public void InsertWhenPosition0ShouldReturnElementOnIndex0()
        {
            List<int> listTest = new List<int>();
            listTest.Add(1);
            listTest.Add(2);
            listTest.Add(3);

            listTest.Insert(0, 4);

            Assert.Equal(4, listTest.Count);
            Assert.Equal(4, listTest[0]);
            Assert.Equal(1, listTest[1]);
            Assert.Equal(2, listTest[2]);
            Assert.Equal(3, listTest[3]);
        }

        [Fact]
        public void InsertWhenPoistionOutOfBoundsShouldDoNothing()
        {
            List<int> listTest = new List<int>();
            listTest.Add(1);
            listTest.Add(2);
            listTest.Add(3);

            listTest.Insert(3, 4);

            Assert.Equal(3, listTest.Count);
            Assert.False(listTest.Contains(4));
            Assert.Equal(1, listTest[0]);
            Assert.Equal(2, listTest[1]);
            Assert.Equal(3, listTest[2]);
        }
    }
}

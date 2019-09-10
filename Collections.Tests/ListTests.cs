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
    }
}

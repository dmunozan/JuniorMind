using System;
using Xunit;

namespace Collections.Tests
{
    public class SortedListTests
    {
        [Fact]
        public void AddWhenEmptyShouldReturnCount1()
        {
            SortedList<int> listTest = new SortedList<int>();
            listTest.Add(5);

            Assert.Equal(1, listTest.Count);
        }

        [Fact]
        public void AddWhenOneNumberShouldReturnCount2AndBeSorted()
        {
            SortedList<int> listTest = new SortedList<int>();
            listTest.Add(5);
            listTest.Add(2);

            Assert.Equal(2, listTest.Count);
            Assert.Equal(2, listTest[0]);
            Assert.Equal(5, listTest[1]);
        }
    }
}

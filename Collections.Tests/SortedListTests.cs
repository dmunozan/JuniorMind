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
    }
}

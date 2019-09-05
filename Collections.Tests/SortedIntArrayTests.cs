using System;
using Xunit;

namespace Collections.Tests
{
    public class SortedIntArrayTests
    {
        [Fact]
        public void AddWhenEmptyShouldReturnCount1()
        {
            SortedIntArray arrayTest = new SortedIntArray();
            arrayTest.Add(5);

            Assert.Equal(1, arrayTest.Count);
        }

        [Fact]
        public void AddWhenOneNumberShouldReturnCount2AndBeSorted()
        {
            SortedIntArray arrayTest = new SortedIntArray();
            arrayTest.Add(5);
            arrayTest.Add(2);

            Assert.Equal(2, arrayTest.Count);
            Assert.Equal(2, arrayTest[0]);
            Assert.Equal(5, arrayTest[1]);
        }
    }
}

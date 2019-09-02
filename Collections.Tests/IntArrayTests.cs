using System;
using Xunit;

namespace Collections.Tests
{
    public class IntArrayTests
    {
        [Fact]
        public void ContainsWhenNumberAndArrayIsEmptyShouldReturnFalse()
        {
            IntArray arrayTest = new IntArray();

            Assert.False(arrayTest.Contains(5));
        }

        [Fact]
        public void AddWhenNumberAndArrayIsEmptyShouldContainNumber()
        {
            IntArray arrayTest = new IntArray();
            arrayTest.Add(5);

            Assert.True(arrayTest.Contains(5));
        }
    }
}

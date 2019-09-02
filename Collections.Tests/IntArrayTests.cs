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

        [Fact]
        public void CountWhenEmptyStringShouldReturn0()
        {
            IntArray arrayTest = new IntArray();

            Assert.Equal(0, arrayTest.Count());
        }

        [Fact]
        public void CountWhenEmptyStringAndAddElementShouldReturnNumberOfElements()
        {
            IntArray arrayTest = new IntArray();
            arrayTest.Add(4);
            arrayTest.Add(5);
            arrayTest.Add(1);

            Assert.Equal(3, arrayTest.Count());
        }
    }
}

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
    }
}

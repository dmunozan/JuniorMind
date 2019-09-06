using System;
using Xunit;

namespace Collections.Tests
{
    public class ObjectArrayTests
    {
        [Fact]
        public void CountWhenEmptyArrayShouldReturn0()
        {
            ObjectArray arrayTest = new ObjectArray();

            Assert.Equal(0, arrayTest.Count);
        }

        [Fact]
        public void AddWhenEmptyArrayShouldReturnCount1()
        {
            ObjectArray arrayTest = new ObjectArray();
            arrayTest.Add(4);

            Assert.Equal(1, arrayTest.Count);
        }
    }
}

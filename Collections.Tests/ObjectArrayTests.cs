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

        [Fact]
        public void IndexOfWhenTextShouldReturn0()
        {
            ObjectArray arrayTest = new ObjectArray();
            arrayTest.Add("test");

            Assert.Equal(0, arrayTest.IndexOf("test"));
        }

        [Fact]
        public void IndexOfWhenNoExistsShouldReturnMinus1()
        {
            ObjectArray arrayTest = new ObjectArray();
            arrayTest.Add("test");

            Assert.Equal(-1, arrayTest.IndexOf("noTest"));
        }

        [Fact]
        public void ContainsWhenExistShouldReturnTrue()
        {
            ObjectArray arrayTest = new ObjectArray();
            arrayTest.Add("test");

            Assert.True(arrayTest.Contains("test"));
        }
    }
}

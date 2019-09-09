using System;
using Xunit;

namespace Collections.Tests
{
    public class ObjectArrayEnumeratorTests
    {
        [Fact]
        public void CurrentWhenInitialPositionShouldReturnNull()
        {
            ObjectArrayCollection arrayTest = new ObjectArrayCollection();
            arrayTest.Add(1);
            ObjectArrayEnumerator arrayEnumerator = new ObjectArrayEnumerator(arrayTest);

            Assert.Null(arrayEnumerator.Current);
        }

        [Fact]
        public void MoveNextWhenInitialPositionShouldReturnTrue()
        {
            ObjectArrayCollection arrayTest = new ObjectArrayCollection();
            arrayTest.Add(1);
            ObjectArrayEnumerator arrayEnumerator = new ObjectArrayEnumerator(arrayTest);

            Assert.True(arrayEnumerator.MoveNext());
        }

        [Fact]
        public void CurrentWhenNotInitialPositionShouldReturnEelmentOnThatPosition()
        {
            ObjectArrayCollection arrayTest = new ObjectArrayCollection();
            arrayTest.Add(1);
            ObjectArrayEnumerator arrayEnumerator = new ObjectArrayEnumerator(arrayTest);

            Assert.True(arrayEnumerator.MoveNext());
            Assert.Equal(1, arrayEnumerator.Current);
        }
    }
}

using System;
using Xunit;

namespace Collections.Tests
{
    public class ObjectArrayEnumeratorTests
    {
        [Fact]
        public void CurrentWhenInitialPositionShouldReturnNull()
        {
            ObjectArrayEnumerator arrayEnumerator = new ObjectArrayEnumerator();

            Assert.Null(arrayEnumerator.Current);
        }

        [Fact]
        public void MoveNextWhenInitialPositionShouldReturnTrue()
        {
            ObjectArrayEnumerator arrayEnumerator = new ObjectArrayEnumerator();

            Assert.True(arrayEnumerator.MoveNext());
        }
    }
}

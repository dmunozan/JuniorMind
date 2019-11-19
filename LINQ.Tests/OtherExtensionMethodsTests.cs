using System.Collections.Generic;
using Xunit;

namespace LINQ.Tests
{
    public class OtherExtensionMethodsTests
    {
        [Fact]
        public void RangeWhenValidNumbersShouldReturnIntSequence()
        {
            IEnumerable<int> numbers = OtherExtensionMethods.Range(1, 5);

            Assert.Collection(numbers,
                item => Assert.Equal(1, item),
                item => Assert.Equal(2, item),
                item => Assert.Equal(3, item),
                item => Assert.Equal(4, item),
                item => Assert.Equal(5, item));
        }
    }
}

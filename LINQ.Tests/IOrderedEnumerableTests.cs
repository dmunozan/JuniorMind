using System.Collections.Generic;
using Xunit;

namespace LINQ.Tests
{
    public class IOrderedEnumerableTests
    {
        [Fact]
        public void CreateOrderedEnumerableWhenNoElementsShouldReturnEmptySequence()
        {
            string[] testList = {  };

            IOrderedEnumerable<string> orderedList = new IOrderedEnumerable<string>(testList);

            orderedList = orderedList.CreateOrderedEnumerable(x => 1, Comparer<int>.Default);

            Assert.Empty(orderedList);
        }
    }
}

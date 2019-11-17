using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LINQ.Tests
{
    public class OrderedEnumerableTests
    {
        [Fact]
        public void CreateOrderedEnumerableWhenNoElementsShouldReturnEmptySequence()
        {
            string[] testArray = {  };

            OrderedEnumerable<string> initialList = new OrderedEnumerable<string>(testArray);

            IOrderedEnumerable<string> orderedList = initialList.CreateOrderedEnumerable(x => 1, Comparer<int>.Default, false);

            Assert.Empty(orderedList);
        }
    }
}

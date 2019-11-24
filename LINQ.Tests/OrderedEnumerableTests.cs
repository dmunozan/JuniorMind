using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LINQ.Tests
{
    public class OrderedEnumerableTests
    {
        [Fact]
        public void ConstructorWhenNoElementsShouldCreateEmptyOrderedEnumerable()
        {
            string[] testArray = { };

            OrderedEnumerable<string> orderedList =
                (OrderedEnumerable<string>)new OrderedEnumerable<string>(testArray);

            Assert.Empty(orderedList);
        }

        [Fact]
        public void CreateOrderedEnumerableWhenNoElementsShouldReturnEmptySequence()
        {
            string[] testArray = {  };

            OrderedEnumerable<string> orderedList =
                (OrderedEnumerable<string>)new OrderedEnumerable<string>(testArray)
                        .CreateOrderedEnumerable(x => 1, Comparer<int>.Default, false);

            Assert.Empty(orderedList);
        }
    }
}

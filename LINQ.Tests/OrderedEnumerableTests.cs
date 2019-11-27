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

            OrderedEnumerable<string, int> orderedList =
                (OrderedEnumerable<string, int>)new OrderedEnumerable<string, int>(
                    testArray,
                    fruit => fruit.Length,
                    Comparer<int>.Default);

            Assert.Empty(orderedList);
        }

        [Fact]
        public void ConstructorWhenElementsShouldCreateOrderedEnumerable()
        {
            string[] testArray = { "apricot", "orange", "banana", "mango" };

            OrderedEnumerable<string, int> orderedList =
                (OrderedEnumerable<string, int>)new OrderedEnumerable<string, int>(
                    testArray,
                    fruit => fruit.Length,
                    Comparer<int>.Default);

            Assert.Collection(orderedList,
                item => Assert.Equal("mango", item),
                item => Assert.Equal("orange", item),
                item => Assert.Equal("banana", item),
                item => Assert.Equal("apricot", item));
        }

        [Fact]
        public void CreateOrderedEnumerableWhenNoElementsShouldReturnEmptySequence()
        {
            string[] testArray = {  };

            OrderedEnumerable<string, int> orderedList =
                (OrderedEnumerable<string, int>)new OrderedEnumerable<string, int>(
                    testArray,
                    fruit => fruit.Length,
                    Comparer<int>.Default)
                        .CreateOrderedEnumerable(
                            x => 1,
                            Comparer<int>.Default,
                            false);

            Assert.Empty(orderedList);
        }
    }
}

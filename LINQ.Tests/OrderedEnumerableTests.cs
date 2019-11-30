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
        public void ConstructorWhenRepeatedElementsShouldCreateStableOrderedEnumerable()
        {
            ListCollection<string[]> testList = new ListCollection<string[]>();

            testList.Add(new string[] { "apricot", "1" });
            testList.Add(new string[] { "orange", "1" });
            testList.Add(new string[] { "apricot", "2" });
            testList.Add(new string[] { "banana", "1" });
            testList.Add(new string[] { "mango", "1" });

            OrderedEnumerable<string[], int> orderedList =
                (OrderedEnumerable<string[], int>)new OrderedEnumerable<string[], int>(
                    testList,
                    fruit => fruit[0].Length,
                    Comparer<int>.Default);

            Assert.Collection(orderedList,
                item => Assert.Equal(new string[] { "mango", "1" }, item),
                item => Assert.Equal(new string[] { "orange", "1" }, item),
                item => Assert.Equal(new string[] { "banana", "1" }, item),
                item => Assert.Equal(new string[] { "apricot", "1" }, item),
                item => Assert.Equal(new string[] { "apricot", "2" }, item));
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

        [Fact]
        public void CreateOrderedEnumerableWhenElementsShouldReturnSubordinateOrderedSequence()
        {
            string[] testArray = { "apricot", "orange", "banana", "mango", "apple", "grape", "strawberry" };

            OrderedEnumerable<string, int> orderedList =
                (OrderedEnumerable<string, int>)new OrderedEnumerable<string, int>(
                    testArray,
                    fruit => fruit.Length,
                    Comparer<int>.Default)
                        .CreateOrderedEnumerable(
                            fruit => fruit,
                            Comparer<string>.Default,
                            false);

            Assert.Collection(orderedList,
                item => Assert.Equal("apple", item),
                item => Assert.Equal("grape", item),
                item => Assert.Equal("mango", item),
                item => Assert.Equal("banana", item),
                item => Assert.Equal("orange", item),
                item => Assert.Equal("apricot", item),
                item => Assert.Equal("strawberry", item));
        }

        [Fact]
        public void CreateOrderedEnumerableWhenMultipleCallsShouldReturnSubordinateOrderedSequence()
        {
            ListCollection<string[]> testList = new ListCollection<string[]>();

            testList.Add(new[] { "E", "3", "C1", "2E" });
            testList.Add(new[] { "D", "2", "A2", "1C" });
            testList.Add(new[] { "C", "1", "D2", "1D" });
            testList.Add(new[] { "A", "1", "C1", "2A" });
            testList.Add(new[] { "B", "3", "D1", "4C" });
            testList.Add(new[] { "A", "3", "D4", "3B" });
            testList.Add(new[] { "C", "4", "A0", "0A" });
            testList.Add(new[] { "C", "3", "D4", "3B" });
            testList.Add(new[] { "B", "3", "C0", "4C" });
            testList.Add(new[] { "E", "3", "C1", "2B" });

            OrderedEnumerable<string[], string> orderedList =
                (OrderedEnumerable<string[], string>)new OrderedEnumerable<string[], string>(
                    testList,
                    x => x[0],
                    Comparer<string>.Default).
                        CreateOrderedEnumerable(
                            x => x[1],
                            Comparer<string>.Default,
                            false).
                                CreateOrderedEnumerable(
                                    x => x[2],
                                    Comparer<string>.Default,
                                    false).
                                        CreateOrderedEnumerable(
                                            x => x[3],
                                            Comparer<string>.Default,
                                            false);

            Assert.Collection(orderedList,
                item => Assert.Equal(new[] { "A", "1", "C1", "2A" }, item),
                item => Assert.Equal(new[] { "A", "3", "D4", "3B" }, item),
                item => Assert.Equal(new[] { "B", "3", "C0", "4C" }, item),
                item => Assert.Equal(new[] { "B", "3", "D1", "4C" }, item),
                item => Assert.Equal(new[] { "C", "1", "D2", "1D" }, item),
                item => Assert.Equal(new[] { "C", "3", "D4", "3B" }, item),
                item => Assert.Equal(new[] { "C", "4", "A0", "0A" }, item),
                item => Assert.Equal(new[] { "D", "2", "A2", "1C" }, item),
                item => Assert.Equal(new[] { "E", "3", "C1", "2B" }, item),
                item => Assert.Equal(new[] { "E", "3", "C1", "2E" }, item));
        }
    }
}

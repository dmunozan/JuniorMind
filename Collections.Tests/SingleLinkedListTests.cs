using Xunit;

namespace Collections.Tests
{
    public class SingleLinkedListTests
    {
        [Fact]
        public void CountWhenEmptyListShouldReturn0()
        {
            SingleLinkedList<int> testSLList = new SingleLinkedList<int>();

            Assert.Equal(0, testSLList.Count);
        }

        [Fact]
        public void FirstWhenEmptyListShouldReturnNull()
        {
            SingleLinkedList<int> testSLList = new SingleLinkedList<int>();

            Assert.Null(testSLList.First);
        }

        [Fact]
        public void AddFirstWhenAnyShouldAddNodeToFirstAndIncreaseCount()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();
            Node<string> node = new Node<string>("test");

            testSLList.AddFirst(node);

            Assert.Equal(1, testSLList.Count);
            Assert.Equal("test", testSLList.First.Value);
        }
    }
}

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
        public void LastWhenEmptyListShouldReturnNull()
        {
            SingleLinkedList<int> testSLList = new SingleLinkedList<int>();

            Assert.Null(testSLList.Last);
        }
    }
}

using Xunit;

namespace Collections.Tests
{
    public class NodeTests
    {
        [Fact]
        public void ValueWhenAnyShouldReturnValueSavedOnNode()
        {
            Node<int> testNode = new Node<int>(0);

            Assert.Equal(0, testNode.Value);
        }

        [Fact]
        public void NextNodeWhenNoNodeShouldReturnNull()
        {
            Node<int> testNode = new Node<int>(0);

            Assert.Null(testNode.NextNode);
        }

        [Fact]
        public void NextNodeWhenNodeShouldReturnAssignedNode()
        {
            Node<int> testNode = new Node<int>(0);
            Node<int> testNextNode = new Node<int>(1);

            testNode.NextNode = testNextNode;

            Assert.Equal(testNextNode, testNode.NextNode);
        }

        [Fact]
        public void ListWhenNoAssignedShouldReturnNull()
        {
            Node<int> testNode = new Node<int>(0);

            Assert.Null(testNode.List);
        }

        [Fact]
        public void ListWhenAssignedShouldReturnSingleLinkedList()
        {
            SingleLinkedList<int> testSLList = new SingleLinkedList<int>();
            Node<int> testNode = new Node<int>(0);

            testNode.List = testSLList;

            Assert.Equal(testSLList, testNode.List);
        }

        [Fact]
        public void EqualsWhenSameValueListNextNodeAndNotNullShouldReturnTrue()
        {
            SingleLinkedList<int> testSLList = new SingleLinkedList<int>();
            Node<int> testNode = new Node<int>(0);
            Node<int> sameNode = new Node<int>(0);
            Node<int> nextNode = new Node<int>(1);

            testNode.List = testSLList;
            sameNode.List = testSLList;

            testNode.NextNode = nextNode;
            sameNode.NextNode = nextNode;

            Assert.True(testNode.Equals(sameNode));
        }

        [Fact]
        public void EqualsWhenNullShouldReturnFalse()
        {
            Node<int> testNode = new Node<int>(0);

            Assert.False(testNode.Equals(null));
        }

        [Fact]
        public void EqualsWhenNullListShouldReturnFalse()
        {
            SingleLinkedList<int> testSLList = new SingleLinkedList<int>();
            Node<int> testNode = new Node<int>(0);
            Node<int> notSameNode = new Node<int>(0);
            Node<int> nextNode = new Node<int>(1);

            testNode.List = testSLList;

            testNode.NextNode = nextNode;
            notSameNode.NextNode = nextNode;

            Assert.False(testNode.Equals(notSameNode));
        }

        [Fact]
        public void EqualsWhenTestNodeNullListShouldReturnFalse()
        {
            SingleLinkedList<int> testSLList = new SingleLinkedList<int>();
            Node<int> testNode = new Node<int>(0);
            Node<int> notSameNode = new Node<int>(0);
            Node<int> nextNode = new Node<int>(1);

            notSameNode.List = testSLList;

            testNode.NextNode = nextNode;
            notSameNode.NextNode = nextNode;

            Assert.False(testNode.Equals(notSameNode));
        }

        [Fact]
        public void EqualsWhenDifferentValueShouldReturnFalse()
        {
            Node<int> testNode = new Node<int>(0);
            Node<int> notSameNode = new Node<int>(1);

            Assert.False(testNode.Equals(notSameNode));
        }
    }
}

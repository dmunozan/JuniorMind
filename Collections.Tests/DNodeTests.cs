using Xunit;

namespace Collections.Tests
{
    public class DNodeTests
    {
        [Fact]
        public void ValueWhenAnyShouldReturnValueSavedOnNode()
        {
            DNode<int> testNode = new DNode<int>(0);

            Assert.Equal(0, testNode.Value);
        }

        [Fact]
        public void NextNodeWhenNoNodeShouldReturnNull()
        {
            DNode<int> testNode = new DNode<int>(0);

            Assert.Null(testNode.NextNode);
        }

        [Fact]
        public void NextNodeWhenNodeShouldReturnAssignedNode()
        {
            DNode<int> testNode = new DNode<int>(0);
            DNode<int> testNextNode = new DNode<int>(1);

            testNode.NextNode = testNextNode;

            Assert.Equal(testNextNode, testNode.NextNode);
        }

        [Fact]
        public void PreviousNodeWhenNoNodeShouldReturnNull()
        {
            DNode<int> testNode = new DNode<int>(0);

            Assert.Null(testNode.PreviousNode);
        }

        [Fact]
        public void ListWhenNoAssignedShouldReturnNull()
        {
            DNode<int> testNode = new DNode<int>(0);

            Assert.Null(testNode.List);
        }

        [Fact]
        public void ListWhenAssignedShouldReturnDoubleLinkedList()
        {
            DoubleLinkedList<int> testSLList = new DoubleLinkedList<int>();
            DNode<int> testNode = new DNode<int>(0);

            testNode.List = testSLList;

            Assert.Equal(testSLList, testNode.List);
        }
    }
}
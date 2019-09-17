using System;
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
    }
}

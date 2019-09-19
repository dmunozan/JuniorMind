using System;
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
        public void AddFirstWhenAnyShouldAddNode()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();
            Node<string> node = new Node<string>("test");

            testSLList.AddFirst(node);

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal("test", testSLList.First.Value);
            Assert.Null(testSLList.First.NextNode);
            Assert.Equal(testSLList, testSLList.First.List);
        }

        [Fact]
        public void AddFirstWhenAlreadyExistingFirstShouldAddNodeToFirstExistingToNodeNextAndIncreaseCount()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();
            Node<string> currentFirstNode = new Node<string>("currentFirst");
            Node<string> newFirstNode = new Node<string>("newFirst");

            testSLList.AddFirst(currentFirstNode);
            
            Assert.Equal(1, testSLList.Count);
            Assert.Equal("currentFirst", testSLList.First.Value);
            Assert.Null(testSLList.First.NextNode);

            testSLList.AddFirst(newFirstNode);

            Assert.Equal(2, testSLList.Count);
            Assert.Equal("newFirst", testSLList.First.Value);
            Assert.Equal(currentFirstNode, testSLList.First.NextNode);
        }

        [Fact]
        public void AddFirstWhenNodeIsNullShouldThrowExceptionAndDoNothing()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();

            Assert.Throws<ArgumentNullException>(() => testSLList.AddFirst(null));

            Assert.Equal(0, testSLList.Count);
            Assert.Null(testSLList.First);
        }
    }
}

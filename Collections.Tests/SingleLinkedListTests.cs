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
        public void CountWhenNoEmptyListShouldReturnTheNumberOfNodes()
        {
            SingleLinkedList<int> testSLList = new SingleLinkedList<int>();
            Node<int> node1 = new Node<int>(1);
            Node<int> node2 = new Node<int>(2);
            Node<int> node3 = new Node<int>(3);

            testSLList.AddFirst(node1);
            testSLList.AddFirst(node2);
            testSLList.AddFirst(node3);

            Assert.Equal(3, testSLList.Count);
        }

        [Fact]
        public void FirstWhenEmptyListShouldReturnNull()
        {
            SingleLinkedList<int> testSLList = new SingleLinkedList<int>();

            Assert.Null(testSLList.First);
        }

        [Fact]
        public void FirstWhenNoEmptyListShouldReturnFirstNode()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();
            Node<string> node = new Node<string>("test");

            testSLList.AddFirst(node);

            Assert.Equal(node, testSLList.First);
        }

        [Fact]
        public void LastWhenEmptyListShouldReturnNull()
        {
            SingleLinkedList<int> testSLList = new SingleLinkedList<int>();

            Assert.Null(testSLList.Last);
        }

        [Fact]
        public void LastWhenNoEmptyListShouldReturnLastNode()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();
            Node<string> node = new Node<string>("test");

            testSLList.AddFirst(node);

            Assert.Equal(node, testSLList.Last);
        }

        [Fact]
        public void AddFirstWhenAnyShouldAddNode()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();
            Node<string> node = new Node<string>("test");

            testSLList.AddFirst(node);

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);
            Assert.Equal("test", testSLList.First.Value);
            Assert.Null(testSLList.First.NextNode);
            Assert.Equal(testSLList, testSLList.First.List);
        }

        [Fact]
        public void AddFirstWhenAlreadyExistingFirstShouldAddNode()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();
            Node<string> currentFirstNode = new Node<string>("currentFirst");
            Node<string> newFirstNode = new Node<string>("newFirst");

            testSLList.AddFirst(currentFirstNode);
            
            Assert.Equal(1, testSLList.Count);
            Assert.Equal(currentFirstNode, testSLList.First);
            Assert.Equal(currentFirstNode, testSLList.Last);
            Assert.Equal("currentFirst", testSLList.First.Value);
            Assert.Null(testSLList.First.NextNode);
            Assert.Equal(testSLList, testSLList.First.List);

            testSLList.AddFirst(newFirstNode);

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(newFirstNode, testSLList.First);
            Assert.Equal(currentFirstNode, testSLList.Last);
            Assert.Equal("newFirst", testSLList.First.Value);
            Assert.Equal(currentFirstNode, testSLList.First.NextNode);
            Assert.Equal(testSLList, testSLList.First.List);
        }

        [Fact]
        public void AddFirstWhenNodeIsNullShouldThrowExceptionAndDoNothing()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();

            Assert.Throws<ArgumentNullException>(() => testSLList.AddFirst(null as Node<string>));

            Assert.Equal(0, testSLList.Count);
            Assert.Null(testSLList.First);
            Assert.Null(testSLList.Last);
        }

        [Fact]
        public void AddFirstWhenNodeListIsNotNullShouldThrowExceptionAndDoNothing()
        {
            SingleLinkedList<string> ourTestSLList = new SingleLinkedList<string>();
            SingleLinkedList<string> anotherTestSLList = new SingleLinkedList<string>();

            Node<string> node = new Node<string>("test");

            anotherTestSLList.AddFirst(node);

            Assert.Equal(1, anotherTestSLList.Count);
            Assert.Equal(node, anotherTestSLList.First);
            Assert.Equal(node, anotherTestSLList.Last);
            Assert.Equal(anotherTestSLList, node.List);

            Assert.Throws<InvalidOperationException>(() => ourTestSLList.AddFirst(node));

            Assert.Equal(0, ourTestSLList.Count);
            Assert.Null(ourTestSLList.First);
            Assert.Null(ourTestSLList.Last);
        }

        [Fact]
        public void AddFirstWhenTAndAnySLLShouldAddNode()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();

            Node<string> node = testSLList.AddFirst("test");

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);
            Assert.Equal("test", testSLList.First.Value);
            Assert.Null(testSLList.First.NextNode);
            Assert.Equal(testSLList, testSLList.First.List);
        }

        [Fact]
        public void AddFirstWhenTAndAlreadyExistingFirstShouldAddNode()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();

            Node<string> currentFirstNode = testSLList.AddFirst("currentFirst");

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(currentFirstNode, testSLList.First);
            Assert.Equal(currentFirstNode, testSLList.Last);
            Assert.Equal("currentFirst", testSLList.First.Value);
            Assert.Null(testSLList.First.NextNode);
            Assert.Equal(testSLList, testSLList.First.List);

            Node<string> newFirstNode = testSLList.AddFirst("newFirst");

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(newFirstNode, testSLList.First);
            Assert.Equal(currentFirstNode, testSLList.Last);
            Assert.Equal("newFirst", testSLList.First.Value);
            Assert.Equal(currentFirstNode, testSLList.First.NextNode);
            Assert.Equal(testSLList, testSLList.First.List);
        }

        [Fact]
        public void AddFirstWhenTIsNullShouldAddNode()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();

            Node<string> node = testSLList.AddFirst(null as string);

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);
            Assert.Null(testSLList.First.Value);
            Assert.Null(testSLList.First.NextNode);
            Assert.Equal(testSLList, testSLList.First.List);
        }

        [Fact]
        public void AddAfterWhenNodeExistShouldAddNewNodeAfterNode()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();
            Node<string> node1 = new Node<string>("node1");
            Node<string> node2 = new Node<string>("node2");
            Node<string> newNode = new Node<string>("newNode");

            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(testSLList, testSLList.First.List);

            testSLList.AddAfter(node1, newNode);

            Assert.Equal(3, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal(newNode, testSLList.First.NextNode);
            Assert.Equal("newNode", testSLList.First.NextNode.Value);
            Assert.Equal(testSLList, newNode.List);
            Assert.Equal(node2, newNode.NextNode);
        }

        [Fact]
        public void AddAfterWhenNodeIsLastNodeShouldAddNewNodeAsLastNode()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();
            Node<string> node1 = new Node<string>("node1");
            Node<string> node2 = new Node<string>("node2");
            Node<string> newNode = new Node<string>("newNode");

            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(testSLList, testSLList.First.List);

            testSLList.AddAfter(node2, newNode);

            Assert.Equal(3, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(newNode, testSLList.Last);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal("newNode", testSLList.Last.Value);
            Assert.Equal(testSLList, newNode.List);
            Assert.Null(newNode.NextNode);
        }

        [Fact]
        public void AddAfterWhenNodeIsNullShouldThrowExceptionAndDoNothing()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();
            Node<string> node = new Node<string>("node");
            Node<string> newNode = new Node<string>("newNode");

            testSLList.AddFirst(node);

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);

            Assert.Throws<ArgumentNullException>(() => testSLList.AddAfter(null as Node<string>, newNode));

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);
        }

        [Fact]
        public void AddAfterWhenNewNodeIsNullShouldThrowExceptionAndDoNothing()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();
            Node<string> node = new Node<string>("node");

            testSLList.AddFirst(node);

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);

            Assert.Throws<ArgumentNullException>(() => testSLList.AddAfter(node, null as Node<string>));

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);
        }

        [Fact]
        public void AddAfterWhenNodeNoExistShouldThrowExceptionAndDoNothing()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();
            Node<string> node1 = new Node<string>("node1");
            Node<string> node2 = new Node<string>("node2");
            Node<string> newNode = new Node<string>("newNode");

            testSLList.AddFirst(node1);

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node1, testSLList.Last);
            Assert.Equal(testSLList, node1.List);

            Assert.Throws<InvalidOperationException>(() => testSLList.AddAfter(node2, newNode));

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node1, testSLList.Last);
        }

        [Fact]
        public void AddAfterWhenNewNodeBelongsToAnotherListShouldThrowExceptionAndDoNothing()
        {
            SingleLinkedList<string> ourTestSLList = new SingleLinkedList<string>();
            SingleLinkedList<string> anotherTestSLList = new SingleLinkedList<string>();
            Node<string> node = new Node<string>("node");
            Node<string> newNode = new Node<string>("newNode");

            ourTestSLList.AddFirst(node);
            anotherTestSLList.AddFirst(newNode);

            Assert.Equal(1, ourTestSLList.Count);
            Assert.Equal(node, ourTestSLList.First);
            Assert.Equal(node, ourTestSLList.Last);
            Assert.Equal(ourTestSLList, node.List);
            Assert.Equal(1, anotherTestSLList.Count);
            Assert.Equal(newNode, anotherTestSLList.First);
            Assert.Equal(newNode, anotherTestSLList.Last);
            Assert.Equal(anotherTestSLList, newNode.List);

            Assert.Throws<InvalidOperationException>(() => ourTestSLList.AddAfter(node, newNode));

            Assert.Equal(1, ourTestSLList.Count);
            Assert.Equal(node, ourTestSLList.First);
            Assert.Equal(node, ourTestSLList.Last);
            Assert.Equal(ourTestSLList, node.List);
            Assert.Equal(1, anotherTestSLList.Count);
            Assert.Equal(newNode, anotherTestSLList.First);
            Assert.Equal(newNode, anotherTestSLList.Last);
            Assert.Equal(anotherTestSLList, newNode.List);
        }

        [Fact]
        public void AddAfterWhenNodeExistShouldAddTAfterNode()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();
            Node<string> node1 = new Node<string>("node1");
            Node<string> node2 = new Node<string>("node2");

            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(testSLList, testSLList.First.List);

            Node<string> newNode = testSLList.AddAfter(node1, "newNode");

            Assert.Equal(3, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal(newNode, testSLList.First.NextNode);
            Assert.Equal("newNode", testSLList.First.NextNode.Value);
            Assert.Equal(testSLList, newNode.List);
            Assert.Equal(node2, newNode.NextNode);
        }

        [Fact]
        public void AddAfterWhenNodeIsLastNodeShouldAddTAsLastNode()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();
            Node<string> node1 = new Node<string>("node1");
            Node<string> node2 = new Node<string>("node2");

            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(testSLList, testSLList.First.List);

            Node<string> newNode = testSLList.AddAfter(node2, "newNode");

            Assert.Equal(3, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(newNode, testSLList.Last);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal("newNode", testSLList.Last.Value);
            Assert.Equal(testSLList, newNode.List);
            Assert.Null(newNode.NextNode);
        }

        [Fact]
        public void AddAfterWhenNodeIsNullAndTShouldThrowExceptionAndDoNothing()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();
            Node<string> node = new Node<string>("node");
            Node<string> newNode;

            testSLList.AddFirst(node);

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);

            Assert.Throws<ArgumentNullException>(() => newNode = testSLList.AddAfter(null as Node<string>, "newNode"));

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);
        }

        [Fact]
        public void AddAfterWhenNodeNoExistAndTShouldThrowExceptionAndDoNothing()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();
            Node<string> node1 = new Node<string>("node1");
            Node<string> node2 = new Node<string>("node2");
            Node<string> newNode;

            testSLList.AddFirst(node1);

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node1, testSLList.Last);
            Assert.Equal(testSLList, node1.List);

            Assert.Throws<InvalidOperationException>(() => newNode = testSLList.AddAfter(node2, "newNode"));

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node1, testSLList.Last);
        }
    }
}

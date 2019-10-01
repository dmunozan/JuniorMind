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

        [Fact]
        public void AddBeforeWhenNodeExistShouldAddNewNodeBeforeNode()
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

            testSLList.AddBefore(node2, newNode);

            Assert.Equal(3, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal(newNode, testSLList.First.NextNode);
            Assert.Equal("newNode", testSLList.First.NextNode.Value);
            Assert.Equal(testSLList, newNode.List);
            Assert.Equal(node2, newNode.NextNode);
        }

        [Fact]
        public void AddBeforeWhenNodeIsFirstNodeShouldAddNewNodeAsFirstNode()
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

            testSLList.AddBefore(node1, newNode);

            Assert.Equal(3, testSLList.Count);
            Assert.Equal(newNode, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal(node1, testSLList.First.NextNode);
            Assert.Equal("newNode", testSLList.First.Value);
            Assert.Equal(testSLList, newNode.List);
        }

        [Fact]
        public void AddBeforeWhenMoreThanOneNodeWithTheSameValueExistShouldAddNewNodeBeforeNode()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();
            Node<string> node1 = new Node<string>("node1");
            Node<string> node2 = new Node<string>("node2");
            Node<string> node3 = new Node<string>("node1");
            Node<string> newNode = new Node<string>("newNode");

            testSLList.AddFirst(node3);
            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(3, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node3, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal("node1", testSLList.Last.Value);
            Assert.Equal(node2, testSLList.First.NextNode);

            testSLList.AddBefore(node3, newNode);

            Assert.Equal(4, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node3, testSLList.Last);
            Assert.Equal(newNode, node2.NextNode);
            Assert.Equal(node3, newNode.NextNode);
            Assert.Equal(testSLList, newNode.List);
        }

        [Fact]
        public void AddBeforeWhenNodeIsNullShouldThrowExceptionAndDoNothing()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();
            Node<string> node = new Node<string>("node");
            Node<string> newNode = new Node<string>("newNode");

            testSLList.AddFirst(node);

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);

            Assert.Throws<ArgumentNullException>(() => testSLList.AddBefore(null as Node<string>, newNode));

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);
        }

        [Fact]
        public void AddBeforeWhenNewNodeIsNullShouldThrowExceptionAndDoNothing()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();
            Node<string> node = new Node<string>("node");

            testSLList.AddFirst(node);

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);

            Assert.Throws<ArgumentNullException>(() => testSLList.AddBefore(node, null as Node<string>));

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);
        }

        [Fact]
        public void AddBeforeWhenNodeNoExistShouldThrowExceptionAndDoNothing()
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

            Assert.Throws<InvalidOperationException>(() => testSLList.AddBefore(node2, newNode));

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node1, testSLList.Last);
        }

        [Fact]
        public void AddBeforeWhenNewNodeBelongsToAnotherListShouldThrowExceptionAndDoNothing()
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

            Assert.Throws<InvalidOperationException>(() => ourTestSLList.AddBefore(node, newNode));

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
        public void AddBeforeWhenNodeExistShouldAddTBeforeNode()
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

            Node<string> newNode = testSLList.AddBefore(node2, "newNode");

            Assert.Equal(3, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal(newNode, testSLList.First.NextNode);
            Assert.Equal("newNode", testSLList.First.NextNode.Value);
            Assert.Equal(testSLList, newNode.List);
            Assert.Equal(node2, newNode.NextNode);
        }

        [Fact]
        public void AddBeforeWhenNodeIsFirstNodeShouldAddTAsFirstNode()
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

            Node<string> newNode = testSLList.AddBefore(node1, "newNode");

            Assert.Equal(3, testSLList.Count);
            Assert.Equal(newNode, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal(node1, testSLList.First.NextNode);
            Assert.Equal("newNode", testSLList.First.Value);
            Assert.Equal(testSLList, newNode.List);
        }

        [Fact]
        public void AddBeforeWhenMoreThanOneNodeWithTheSameValueExistShouldAddTBeforeNode()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();
            Node<string> node1 = new Node<string>("node1");
            Node<string> node2 = new Node<string>("node2");
            Node<string> node3 = new Node<string>("node1");

            testSLList.AddFirst(node3);
            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(3, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node3, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal("node1", testSLList.Last.Value);
            Assert.Equal(node2, testSLList.First.NextNode);

            Node<string> newNode = testSLList.AddBefore(node3, "newNode");

            Assert.Equal(4, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node3, testSLList.Last);
            Assert.Equal(newNode, node2.NextNode);
            Assert.Equal(node3, newNode.NextNode);
            Assert.Equal(testSLList, newNode.List);
        }

        [Fact]
        public void AddBeforeWhenNodeIsNullAndTShouldThrowExceptionAndDoNothing()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();
            Node<string> node = new Node<string>("node");
            Node<string> newNode;

            testSLList.AddFirst(node);

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);

            Assert.Throws<ArgumentNullException>(() => newNode = testSLList.AddBefore(null as Node<string>, "newNode"));

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);
        }

        [Fact]
        public void AddBeforeWhenNodeNoExistAndTShouldThrowExceptionAndDoNothing()
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

            Assert.Throws<InvalidOperationException>(() => newNode = testSLList.AddBefore(node2, "newNode"));

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node1, testSLList.Last);
        }

        [Fact]
        public void AddLastWhenEmptySLLShouldAddNode()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();
            Node<string> node = new Node<string>("test");

            testSLList.AddLast(node);

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);
            Assert.Equal("test", testSLList.Last.Value);
            Assert.Null(testSLList.Last.NextNode);
            Assert.Equal(testSLList, testSLList.Last.List);
        }

        [Fact]
        public void AddLastWhenAlreadyExistingLastShouldAddNode()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();
            Node<string> currentLastNode = new Node<string>("currentLast");
            Node<string> newLastNode = new Node<string>("newLast");

            testSLList.AddLast(currentLastNode);

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(currentLastNode, testSLList.First);
            Assert.Equal(currentLastNode, testSLList.Last);
            Assert.Equal("currentLast", testSLList.Last.Value);
            Assert.Null(testSLList.Last.NextNode);
            Assert.Equal(testSLList, testSLList.Last.List);

            testSLList.AddLast(newLastNode);

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(newLastNode, testSLList.Last);
            Assert.Equal(currentLastNode, testSLList.First);
            Assert.Equal("newLast", testSLList.Last.Value);
            Assert.Equal(newLastNode, testSLList.First.NextNode);
            Assert.Null(testSLList.Last.NextNode);
            Assert.Equal(testSLList, testSLList.Last.List);
        }

        [Fact]
        public void AddLastWhenNodeIsNullShouldThrowExceptionAndDoNothing()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();

            Assert.Throws<ArgumentNullException>(() => testSLList.AddLast(null as Node<string>));

            Assert.Equal(0, testSLList.Count);
            Assert.Null(testSLList.First);
            Assert.Null(testSLList.Last);
        }

        [Fact]
        public void AddLastWhenNodeListIsNotNullShouldThrowExceptionAndDoNothing()
        {
            SingleLinkedList<string> ourTestSLList = new SingleLinkedList<string>();
            SingleLinkedList<string> anotherTestSLList = new SingleLinkedList<string>();

            Node<string> node = new Node<string>("test");

            anotherTestSLList.AddLast(node);

            Assert.Equal(1, anotherTestSLList.Count);
            Assert.Equal(node, anotherTestSLList.First);
            Assert.Equal(node, anotherTestSLList.Last);
            Assert.Equal(anotherTestSLList, node.List);

            Assert.Throws<InvalidOperationException>(() => ourTestSLList.AddLast(node));

            Assert.Equal(0, ourTestSLList.Count);
            Assert.Null(ourTestSLList.First);
            Assert.Null(ourTestSLList.Last);
        }

        [Fact]
        public void AddLastWhenTAndAnySLLShouldAddNode()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();

            Node<string> node = testSLList.AddLast("test");

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);
            Assert.Equal("test", testSLList.Last.Value);
            Assert.Null(testSLList.Last.NextNode);
            Assert.Equal(testSLList, testSLList.Last.List);
        }

        [Fact]
        public void AddLastWhenTAndAlreadyExistingLastShouldAddNode()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();

            Node<string> currentLastNode = testSLList.AddLast("currentLast");

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(currentLastNode, testSLList.First);
            Assert.Equal(currentLastNode, testSLList.Last);
            Assert.Equal("currentLast", testSLList.Last.Value);
            Assert.Null(testSLList.Last.NextNode);
            Assert.Equal(testSLList, testSLList.Last.List);

            Node<string> newLastNode = testSLList.AddLast("newLast");

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(newLastNode, testSLList.Last);
            Assert.Equal(currentLastNode, testSLList.First);
            Assert.Equal("newLast", testSLList.Last.Value);
            Assert.Equal(newLastNode, testSLList.First.NextNode);
            Assert.Equal(testSLList, testSLList.Last.List);
        }

        [Fact]
        public void AddLastWhenTIsNullShouldAddNode()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();

            Node<string> node = testSLList.AddLast(null as string);

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);
            Assert.Null(testSLList.Last.Value);
            Assert.Null(testSLList.Last.NextNode);
            Assert.Equal(testSLList, testSLList.Last.List);
        }

        [Fact]
        public void FindWhenTExistAndFirstShouldReturnFirstNode()
        {
            SingleLinkedList<int> testSLList = new SingleLinkedList<int>();

            Node<int> node1 = new Node<int>(1);
            Node<int> node2 = new Node<int>(2);
            Node<int> node3 = new Node<int>(3);
            Node<int> node4 = new Node<int>(4);
            Node<int> node5 = new Node<int>(5);

            testSLList.AddLast(node1);
            testSLList.AddLast(node2);
            testSLList.AddLast(node3);
            testSLList.AddLast(node4);
            testSLList.AddLast(node5);

            Node<int> foundNode = testSLList.Find(1);

            Assert.Equal(foundNode, node1);
            Assert.Equal(node2, foundNode.NextNode);
        }

        [Fact]
        public void FindWhenTExistAndNotFirstShouldReturnFirstNodeContainingT()
        {
            SingleLinkedList<int> testSLList = new SingleLinkedList<int>();

            Node<int> node1 = new Node<int>(1);
            Node<int> node2 = new Node<int>(2);
            Node<int> node3 = new Node<int>(3);
            Node<int> node4 = new Node<int>(4);
            Node<int> node5 = new Node<int>(5);

            testSLList.AddLast(node1);
            testSLList.AddLast(node2);
            testSLList.AddLast(node3);
            testSLList.AddLast(node4);
            testSLList.AddLast(node5);

            Node<int> foundNode = testSLList.Find(3);

            Assert.Equal(foundNode, node3);
            Assert.Equal(node4, foundNode.NextNode);
        }

        [Fact]
        public void FindWhenMoreThanOneTExistShouldReturnFirstNodeContainingT()
        {
            SingleLinkedList<int> testSLList = new SingleLinkedList<int>();

            Node<int> node1 = new Node<int>(1);
            Node<int> node2 = new Node<int>(2);
            Node<int> node3 = new Node<int>(3);
            Node<int> node4 = new Node<int>(2);
            Node<int> node5 = new Node<int>(1);

            testSLList.AddLast(node1);
            testSLList.AddLast(node2);
            testSLList.AddLast(node3);
            testSLList.AddLast(node4);
            testSLList.AddLast(node5);

            Node<int> foundNode = testSLList.Find(2);

            Assert.Equal(foundNode, node2);
            Assert.Equal(node3, foundNode.NextNode);
        }

        [Fact]
        public void FindWhenTNoExistShouldReturnNull()
        {
            SingleLinkedList<int> testSLList = new SingleLinkedList<int>();

            Node<int> node1 = new Node<int>(1);
            Node<int> node2 = new Node<int>(2);
            Node<int> node3 = new Node<int>(3);
            Node<int> node4 = new Node<int>(2);
            Node<int> node5 = new Node<int>(1);

            testSLList.AddLast(node1);
            testSLList.AddLast(node2);
            testSLList.AddLast(node3);
            testSLList.AddLast(node4);
            testSLList.AddLast(node5);

            Node<int> foundNode = testSLList.Find(6);

            Assert.Null(foundNode);
        }

        [Fact]
        public void FindLastWhenTExistAndLastShouldReturnLastNode()
        {
            SingleLinkedList<int> testSLList = new SingleLinkedList<int>();

            Node<int> node1 = new Node<int>(1);
            Node<int> node2 = new Node<int>(2);
            Node<int> node3 = new Node<int>(3);
            Node<int> node4 = new Node<int>(4);
            Node<int> node5 = new Node<int>(5);

            testSLList.AddLast(node1);
            testSLList.AddLast(node2);
            testSLList.AddLast(node3);
            testSLList.AddLast(node4);
            testSLList.AddLast(node5);

            Node<int> foundNode = testSLList.FindLast(5);

            Assert.Equal(foundNode, node5);
            Assert.Null(foundNode.NextNode);
        }

        [Fact]
        public void FindLastWhenTExistAndNotLastShouldReturnLastNodeContainingT()
        {
            SingleLinkedList<int> testSLList = new SingleLinkedList<int>();

            Node<int> node1 = new Node<int>(1);
            Node<int> node2 = new Node<int>(2);
            Node<int> node3 = new Node<int>(3);
            Node<int> node4 = new Node<int>(4);
            Node<int> node5 = new Node<int>(5);

            testSLList.AddLast(node1);
            testSLList.AddLast(node2);
            testSLList.AddLast(node3);
            testSLList.AddLast(node4);
            testSLList.AddLast(node5);

            Node<int> foundNode = testSLList.FindLast(3);

            Assert.Equal(foundNode, node3);
            Assert.Equal(node4, foundNode.NextNode);
        }

        [Fact]
        public void FindLastWhenMoreThanOneTExistShouldReturnLastNodeContainingT()
        {
            SingleLinkedList<int> testSLList = new SingleLinkedList<int>();

            Node<int> node1 = new Node<int>(1);
            Node<int> node2 = new Node<int>(2);
            Node<int> node3 = new Node<int>(3);
            Node<int> node4 = new Node<int>(2);
            Node<int> node5 = new Node<int>(1);

            testSLList.AddLast(node1);
            testSLList.AddLast(node2);
            testSLList.AddLast(node3);
            testSLList.AddLast(node4);
            testSLList.AddLast(node5);

            Node<int> foundNode = testSLList.FindLast(2);

            Assert.Equal(foundNode, node4);
            Assert.Equal(node5, foundNode.NextNode);
        }

        [Fact]
        public void FindLastWhenTNoExistShouldReturnNull()
        {
            SingleLinkedList<int> testSLList = new SingleLinkedList<int>();

            Node<int> node1 = new Node<int>(1);
            Node<int> node2 = new Node<int>(2);
            Node<int> node3 = new Node<int>(3);
            Node<int> node4 = new Node<int>(2);
            Node<int> node5 = new Node<int>(1);

            testSLList.AddLast(node1);
            testSLList.AddLast(node2);
            testSLList.AddLast(node3);
            testSLList.AddLast(node4);
            testSLList.AddLast(node5);

            Node<int> foundNode = testSLList.FindLast(6);

            Assert.Null(foundNode);
        }

        [Fact]
        public void RemoveWhenNodeExistShouldRemoveNode()
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

            testSLList.Remove(node1);

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node2, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
        }

        [Fact]
        public void RemoveWhenNodeExistAndLastShouldRemoveNode()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();
            Node<string> node1 = new Node<string>("node1");
            Node<string> node2 = new Node<string>("node2");
            Node<string> node3 = new Node<string>("node3");

            testSLList.AddFirst(node3);
            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(3, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node3, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal("node3", testSLList.Last.Value);
            Assert.Equal(node2, testSLList.First.NextNode);

            testSLList.Remove(node3);

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Null(node2.NextNode);
        }

        [Fact]
        public void RemoveWhenMoreThanOneNodeWithTheSameValueExistShouldRemoveNode()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();
            Node<string> node1 = new Node<string>("node1");
            Node<string> node2 = new Node<string>("node2");
            Node<string> node3 = new Node<string>("node1");
            Node<string> node4 = new Node<string>("node4");

            testSLList.AddFirst(node4);
            testSLList.AddFirst(node3);
            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(4, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node4, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal("node4", testSLList.Last.Value);
            Assert.Equal(node3, node2.NextNode);

            testSLList.Remove(node3);

            Assert.Equal(3, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node4, testSLList.Last);
            Assert.Equal(node4, node2.NextNode);
        }

        [Fact]
        public void RemoveWhenNullShouldThrowExceptionAndDoNothing()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();
            Node<string> node1 = new Node<string>("node1");
            Node<string> node2 = new Node<string>("node2");
            Node<string> node3 = new Node<string>("node3");
            Node<string> node4 = new Node<string>("node4");

            testSLList.AddFirst(node4);
            testSLList.AddFirst(node3);
            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(4, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node4, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal("node4", testSLList.Last.Value);
            Assert.Equal(node3, node2.NextNode);

            Assert.Throws<ArgumentNullException>(() => testSLList.Remove(null as Node<string>));

            Assert.Equal(4, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node4, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal("node4", testSLList.Last.Value);
            Assert.Equal(node3, node2.NextNode);
        }

        [Fact]
        public void RemoveWhenNodeBelongsToAnotherListShouldThrowExceptionAndDoNothing()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();
            SingleLinkedList<string> anotherSLList = new SingleLinkedList<string>();
            Node<string> node1 = new Node<string>("node1");
            Node<string> node2 = new Node<string>("node2");
            Node<string> node3 = new Node<string>("node3");
            Node<string> node4 = new Node<string>("node4");

            anotherSLList.AddFirst(node4);

            testSLList.AddFirst(node3);
            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(3, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node3, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal("node3", testSLList.Last.Value);
            Assert.Equal(node3, node2.NextNode);

            Assert.Throws<InvalidOperationException>(() => testSLList.Remove(node4));

            Assert.Equal(3, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node3, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal("node3", testSLList.Last.Value);
            Assert.Equal(node3, node2.NextNode);
        }

        [Fact]
        public void RemoveWhenTExistShouldRemoveTAndReturnTrue()
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

            Assert.True(testSLList.Remove("node1"));

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node2, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
        }

        [Fact]
        public void RemoveWhenTExistAndLastShouldRemoveTAndReturnTrue()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();
            Node<string> node1 = new Node<string>("node1");
            Node<string> node2 = new Node<string>("node2");
            Node<string> node3 = new Node<string>("node3");

            testSLList.AddFirst(node3);
            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(3, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node3, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal("node3", testSLList.Last.Value);
            Assert.Equal(node2, testSLList.First.NextNode);

            Assert.True(testSLList.Remove("node3"));

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Null(node2.NextNode);
        }

        [Fact]
        public void RemoveWhenMoreThanOneNodeContainingTExistShouldRemoveFirstTAndReturnTrue()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();
            Node<string> node1 = new Node<string>("node1");
            Node<string> node2 = new Node<string>("node2");
            Node<string> node3 = new Node<string>("node2");
            Node<string> node4 = new Node<string>("node4");

            testSLList.AddFirst(node4);
            testSLList.AddFirst(node3);
            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(4, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node4, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal("node4", testSLList.Last.Value);
            Assert.Equal(node3, node2.NextNode);

            Assert.True(testSLList.Remove("node2"));

            Assert.Equal(3, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node4, testSLList.Last);
            Assert.Equal(node3, node1.NextNode);
        }

        [Fact]
        public void RemoveWhenTNoExistShouldReturnFalse()
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

            Assert.False(testSLList.Remove("node3"));

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(testSLList, testSLList.First.List);
        }

        [Fact]
        public void RemoveFirstWhenNoEmptyListShouldRemoveFirstNode()
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

            testSLList.RemoveFirst();

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node2, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
        }

        [Fact]
        public void RemoveFirstWhenOnlyOneNodeShouldRemoveFirstNode()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();
            Node<string> node1 = new Node<string>("node1");

            testSLList.AddFirst(node1);

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node1, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal(testSLList, testSLList.First.List);

            testSLList.RemoveFirst();

            Assert.Equal(0, testSLList.Count);
            Assert.Null(testSLList.First);
            Assert.Null(testSLList.Last);
        }

        [Fact]
        public void RemoveFirstWhenEmptyListShouldThrowExceptionAndDoNothing()
        {
            SingleLinkedList<string> testSLList = new SingleLinkedList<string>();

            Assert.Equal(0, testSLList.Count);
            Assert.Null(testSLList.First);
            Assert.Null(testSLList.Last);

            Assert.Throws<InvalidOperationException>(() => testSLList.RemoveFirst());

            Assert.Equal(0, testSLList.Count);
            Assert.Null(testSLList.First);
            Assert.Null(testSLList.Last);
        }

        [Fact]
        public void RemoveLastWhenNoEmptyListShouldRemoveLastNode()
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

            testSLList.RemoveLast();

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node1, testSLList.Last);
        }
    }
}

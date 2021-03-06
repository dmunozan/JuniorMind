﻿using System;
using Xunit;

namespace Collections.Tests
{
    public class DoubleLinkedListTests
    {
        [Fact]
        public void CountWhenEmptyListShouldReturn0()
        {
            DoubleLinkedList<int> testSLList = new DoubleLinkedList<int>();

            Assert.Equal(0, testSLList.Count);
        }

        [Fact]
        public void CountWhenNoEmptyListShouldReturnTheNumberOfNodes()
        {
            DoubleLinkedList<int> testSLList = new DoubleLinkedList<int>();
            DNode<int> node1 = new DNode<int>(1);
            DNode<int> node2 = new DNode<int>(2);
            DNode<int> node3 = new DNode<int>(3);

            testSLList.AddFirst(node1);
            testSLList.AddFirst(node2);
            testSLList.AddFirst(node3);

            Assert.Equal(3, testSLList.Count);
        }

        [Fact]
        public void FirstWhenEmptyListShouldReturnNull()
        {
            DoubleLinkedList<int> testSLList = new DoubleLinkedList<int>();

            Assert.Null(testSLList.First);
        }

        [Fact]
        public void FirstWhenNoEmptyListShouldReturnFirstNode()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node = new DNode<string>("test");

            testSLList.AddFirst(node);

            Assert.Equal(node, testSLList.First);
        }

        [Fact]
        public void LastWhenEmptyListShouldReturnNull()
        {
            DoubleLinkedList<int> testSLList = new DoubleLinkedList<int>();

            Assert.Null(testSLList.Last);
        }

        [Fact]
        public void LastWhenNoEmptyListShouldReturnLastNode()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node = new DNode<string>("test");

            testSLList.AddFirst(node);

            Assert.Equal(node, testSLList.Last);
        }

        [Fact]
        public void AddFirstWhenAnyShouldAddNode()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node = new DNode<string>("test");

            testSLList.AddFirst(node);

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);
            Assert.Equal("test", testSLList.First.Value);
            Assert.Equal(testSLList.First.NextNode, testSLList.First.PreviousNode);
            Assert.Equal(testSLList, testSLList.First.List);
        }

        [Fact]
        public void AddFirstWhenAlreadyExistingFirstShouldAddNode()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> currentFirstNode = new DNode<string>("currentFirst");
            DNode<string> newFirstNode = new DNode<string>("newFirst");

            testSLList.AddFirst(currentFirstNode);

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(currentFirstNode, testSLList.First);
            Assert.Equal(currentFirstNode, testSLList.Last);
            Assert.Equal("currentFirst", testSLList.First.Value);
            Assert.Equal(testSLList.First.NextNode, testSLList.First.PreviousNode);
            Assert.Equal(testSLList, testSLList.First.List);

            testSLList.AddFirst(newFirstNode);

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(newFirstNode, testSLList.First);
            Assert.Equal(currentFirstNode, testSLList.Last);
            Assert.Equal("newFirst", testSLList.First.Value);
            Assert.Equal(currentFirstNode, testSLList.First.NextNode);
            Assert.Equal(newFirstNode, testSLList.Last.PreviousNode);
            Assert.Equal(testSLList, testSLList.First.List);
        }

        [Fact]
        public void AddFirstWhenNodeIsNullShouldThrowExceptionAndDoNothing()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();

            Assert.Throws<ArgumentNullException>(() => testSLList.AddFirst(null as DNode<string>));

            Assert.Equal(0, testSLList.Count);
            Assert.Null(testSLList.First);
            Assert.Null(testSLList.Last);
        }

        [Fact]
        public void AddFirstWhenNodeListIsNotNullShouldThrowExceptionAndDoNothing()
        {
            DoubleLinkedList<string> ourTestSLList = new DoubleLinkedList<string>();
            DoubleLinkedList<string> anotherTestSLList = new DoubleLinkedList<string>();

            DNode<string> node = new DNode<string>("test");

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
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();

            DNode<string> node = testSLList.AddFirst("test");

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);
            Assert.Equal("test", testSLList.First.Value);
            Assert.Equal(testSLList.First.NextNode, testSLList.First.PreviousNode);
            Assert.Equal(testSLList, testSLList.First.List);
        }

        [Fact]
        public void AddFirstWhenTAndAlreadyExistingFirstShouldAddNode()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();

            DNode<string> currentFirstNode = testSLList.AddFirst("currentFirst");

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(currentFirstNode, testSLList.First);
            Assert.Equal(currentFirstNode, testSLList.Last);
            Assert.Equal("currentFirst", testSLList.First.Value);
            Assert.Equal(testSLList.First.NextNode, testSLList.First.PreviousNode);
            Assert.Equal(testSLList, testSLList.First.List);

            DNode<string> newFirstNode = testSLList.AddFirst("newFirst");

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(newFirstNode, testSLList.First);
            Assert.Equal(currentFirstNode, testSLList.Last);
            Assert.Equal("newFirst", testSLList.First.Value);
            Assert.Equal(currentFirstNode, testSLList.First.NextNode);
            Assert.Equal(newFirstNode, testSLList.Last.PreviousNode);
            Assert.Equal(testSLList, testSLList.First.List);
        }

        [Fact]
        public void AddFirstWhenTIsNullShouldAddNode()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();

            DNode<string> node = testSLList.AddFirst(null as string);

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);
            Assert.Null(testSLList.First.Value);
            Assert.Equal(testSLList.First.NextNode, testSLList.First.PreviousNode);
            Assert.Equal(testSLList, testSLList.First.List);
        }

        [Fact]
        public void AddFirstWhenSLLIsReadOnlyShouldThrowExceptionAndDoNothing()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node = new DNode<string>("test");

            testSLList.ToReadOnly();

            Assert.Throws<NotSupportedException>(() => testSLList.AddFirst(node));

            Assert.Equal(0, testSLList.Count);
            Assert.Null(testSLList.First);
            Assert.Null(testSLList.Last);
        }

        [Fact]
        public void AddFirstWhenTAndSLLIsReadOnlyShouldThrowExceptionAndDoNothing()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();

            testSLList.ToReadOnly();

            DNode<string> node = null;

            Assert.Throws<NotSupportedException>(() => node = testSLList.AddFirst("test"));

            Assert.Equal(0, testSLList.Count);
            Assert.Null(testSLList.First);
            Assert.Null(testSLList.Last);
            Assert.Null(node);
        }

        [Fact]
        public void AddAfterWhenNodeExistShouldAddNewNodeAfterNode()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");
            DNode<string> newNode = new DNode<string>("newNode");

            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node1, testSLList.Last.PreviousNode);
            Assert.Equal(testSLList, testSLList.First.List);

            testSLList.AddAfter(node1, newNode);

            Assert.Equal(3, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal(newNode, testSLList.First.NextNode);
            Assert.Equal("newNode", testSLList.First.NextNode.Value);
            Assert.Equal(newNode, testSLList.Last.PreviousNode);
            Assert.Equal(testSLList, newNode.List);
            Assert.Equal(node2, newNode.NextNode);
            Assert.Equal(node1, newNode.PreviousNode);
        }

        [Fact]
        public void AddAfterWhenNodeIsLastNodeShouldAddNewNodeAsLastNode()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");
            DNode<string> newNode = new DNode<string>("newNode");

            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node1, testSLList.Last.PreviousNode);
            Assert.Equal(testSLList, testSLList.First.List);

            testSLList.AddAfter(node2, newNode);

            Assert.Equal(3, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(newNode, testSLList.Last);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node2, testSLList.Last.PreviousNode);
            Assert.Equal("newNode", testSLList.Last.Value);
            Assert.Equal(testSLList, newNode.List);
            Assert.Equal(node2, newNode.PreviousNode);
            Assert.Equal(node1.PreviousNode, newNode.NextNode);
        }

        [Fact]
        public void AddAfterWhenNodeIsNullShouldThrowExceptionAndDoNothing()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node = new DNode<string>("node");
            DNode<string> newNode = new DNode<string>("newNode");

            testSLList.AddFirst(node);

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);

            Assert.Throws<ArgumentNullException>(() => testSLList.AddAfter(null as DNode<string>, newNode));

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);
        }

        [Fact]
        public void AddAfterWhenNewNodeIsNullShouldThrowExceptionAndDoNothing()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node = new DNode<string>("node");

            testSLList.AddFirst(node);

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);

            Assert.Throws<ArgumentNullException>(() => testSLList.AddAfter(node, null as DNode<string>));

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);
        }

        [Fact]
        public void AddAfterWhenNodeNoExistShouldThrowExceptionAndDoNothing()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");
            DNode<string> newNode = new DNode<string>("newNode");

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
            DoubleLinkedList<string> ourTestSLList = new DoubleLinkedList<string>();
            DoubleLinkedList<string> anotherTestSLList = new DoubleLinkedList<string>();
            DNode<string> node = new DNode<string>("node");
            DNode<string> newNode = new DNode<string>("newNode");

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
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");

            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node1, testSLList.Last.PreviousNode);
            Assert.Equal(testSLList, testSLList.First.List);

            DNode<string> newNode = testSLList.AddAfter(node1, "newNode");

            Assert.Equal(3, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal(newNode, testSLList.First.NextNode);
            Assert.Equal(newNode, testSLList.Last.PreviousNode);
            Assert.Equal("newNode", testSLList.First.NextNode.Value);
            Assert.Equal(testSLList, newNode.List);
            Assert.Equal(node2, newNode.NextNode);
            Assert.Equal(node1, newNode.PreviousNode);
        }

        [Fact]
        public void AddAfterWhenNodeIsLastNodeShouldAddTAsLastNode()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");

            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node1, testSLList.Last.PreviousNode);
            Assert.Equal(testSLList, testSLList.First.List);

            DNode<string> newNode = testSLList.AddAfter(node2, "newNode");

            Assert.Equal(3, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(newNode, testSLList.Last);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node2, testSLList.Last.PreviousNode);
            Assert.Equal("newNode", testSLList.Last.Value);
            Assert.Equal(testSLList, newNode.List);
            Assert.Equal(node1.PreviousNode, newNode.NextNode);
            Assert.Equal(node2, newNode.PreviousNode);
        }

        [Fact]
        public void AddAfterWhenNodeIsNullAndTShouldThrowExceptionAndDoNothing()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node = new DNode<string>("node");
            DNode<string> newNode;

            testSLList.AddFirst(node);

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);

            Assert.Throws<ArgumentNullException>(() => newNode = testSLList.AddAfter(null as DNode<string>, "newNode"));

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);
        }

        [Fact]
        public void AddAfterWhenNodeNoExistAndTShouldThrowExceptionAndDoNothing()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");
            DNode<string> newNode;

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
        public void AddAfterWhenIsReadOnlyShouldThrowException()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");
            DNode<string> newNode = new DNode<string>("newNode");

            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node1, testSLList.Last.PreviousNode);
            Assert.Equal(testSLList, testSLList.First.List);

            testSLList.ToReadOnly();

            Assert.Throws<NotSupportedException>(() => testSLList.AddAfter(node1, newNode));
        }

        [Fact]
        public void AddAfterWhenTAndIsReadOnlyShouldThrowException()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");
            DNode<string> newNode;

            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node1, testSLList.Last.PreviousNode);
            Assert.Equal(testSLList, testSLList.First.List);

            testSLList.ToReadOnly();

            Assert.Throws<NotSupportedException>(() => newNode = testSLList.AddAfter(node1, "newNode"));
        }

        [Fact]
        public void AddBeforeWhenNodeExistShouldAddNewNodeBeforeNode()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");
            DNode<string> newNode = new DNode<string>("newNode");

            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node1, testSLList.Last.PreviousNode);
            Assert.Equal(testSLList, testSLList.First.List);

            testSLList.AddBefore(node2, newNode);

            Assert.Equal(3, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal(newNode, testSLList.First.NextNode);
            Assert.Equal(newNode, testSLList.Last.PreviousNode);
            Assert.Equal("newNode", testSLList.First.NextNode.Value);
            Assert.Equal(testSLList, newNode.List);
            Assert.Equal(node2, newNode.NextNode);
            Assert.Equal(node1, newNode.PreviousNode);
        }

        [Fact]
        public void AddBeforeWhenNodeIsFirstNodeShouldAddNewNodeAsFirstNode()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");
            DNode<string> newNode = new DNode<string>("newNode");

            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node1, testSLList.Last.PreviousNode);
            Assert.Equal(testSLList, testSLList.First.List);

            testSLList.AddBefore(node1, newNode);

            Assert.Equal(3, testSLList.Count);
            Assert.Equal(newNode, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal(node1, testSLList.First.NextNode);
            Assert.Equal("newNode", testSLList.First.Value);
            Assert.Equal(newNode, node1.PreviousNode);
            Assert.Equal(testSLList, newNode.List);
        }

        [Fact]
        public void AddBeforeWhenMoreThanOneNodeWithTheSameValueExistShouldAddNewNodeBeforeNode()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");
            DNode<string> node3 = new DNode<string>("node1");
            DNode<string> newNode = new DNode<string>("newNode");

            testSLList.AddFirst(node3);
            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(3, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node3, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal("node1", testSLList.Last.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node2, testSLList.Last.PreviousNode);

            testSLList.AddBefore(node3, newNode);

            Assert.Equal(4, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node3, testSLList.Last);
            Assert.Equal(newNode, node2.NextNode);
            Assert.Equal(node2, newNode.PreviousNode);
            Assert.Equal(node3, newNode.NextNode);
            Assert.Equal(newNode, node3.PreviousNode);
            Assert.Equal(testSLList, newNode.List);
        }

        [Fact]
        public void AddBeforeWhenNodeIsNullShouldThrowExceptionAndDoNothing()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node = new DNode<string>("node");
            DNode<string> newNode = new DNode<string>("newNode");

            testSLList.AddFirst(node);

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);

            Assert.Throws<ArgumentNullException>(() => testSLList.AddBefore(null as DNode<string>, newNode));

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);
        }

        [Fact]
        public void AddBeforeWhenNewNodeIsNullShouldThrowExceptionAndDoNothing()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node = new DNode<string>("node");

            testSLList.AddFirst(node);

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);

            Assert.Throws<ArgumentNullException>(() => testSLList.AddBefore(node, null as DNode<string>));

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);
        }

        [Fact]
        public void AddBeforeWhenNodeNoExistShouldThrowExceptionAndDoNothing()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");
            DNode<string> newNode = new DNode<string>("newNode");

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
            DoubleLinkedList<string> ourTestSLList = new DoubleLinkedList<string>();
            DoubleLinkedList<string> anotherTestSLList = new DoubleLinkedList<string>();
            DNode<string> node = new DNode<string>("node");
            DNode<string> newNode = new DNode<string>("newNode");

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
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");

            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node1, testSLList.Last.PreviousNode);
            Assert.Equal(testSLList, testSLList.First.List);

            DNode<string> newNode = testSLList.AddBefore(node2, "newNode");

            Assert.Equal(3, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal(newNode, testSLList.First.NextNode);
            Assert.Equal(newNode, testSLList.Last.PreviousNode);
            Assert.Equal("newNode", testSLList.First.NextNode.Value);
            Assert.Equal(testSLList, newNode.List);
            Assert.Equal(node2, newNode.NextNode);
            Assert.Equal(node1, newNode.PreviousNode);
        }

        [Fact]
        public void AddBeforeWhenNodeIsFirstNodeShouldAddTAsFirstNode()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");

            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node1, testSLList.Last.PreviousNode);
            Assert.Equal(testSLList, testSLList.First.List);

            DNode<string> newNode = testSLList.AddBefore(node1, "newNode");

            Assert.Equal(3, testSLList.Count);
            Assert.Equal(newNode, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal(node1, testSLList.First.NextNode);
            Assert.Equal(newNode, node1.PreviousNode);
            Assert.Equal("newNode", testSLList.First.Value);
            Assert.Equal(testSLList, newNode.List);
        }

        [Fact]
        public void AddBeforeWhenMoreThanOneNodeWithTheSameValueExistShouldAddTBeforeNode()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");
            DNode<string> node3 = new DNode<string>("node1");

            testSLList.AddFirst(node3);
            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(3, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node3, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal("node1", testSLList.Last.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node2, testSLList.Last.PreviousNode);

            DNode<string> newNode = testSLList.AddBefore(node3, "newNode");

            Assert.Equal(4, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node3, testSLList.Last);
            Assert.Equal(newNode, node2.NextNode);
            Assert.Equal(node2, newNode.PreviousNode);
            Assert.Equal(node3, newNode.NextNode);
            Assert.Equal(newNode, node3.PreviousNode);
            Assert.Equal(testSLList, newNode.List);
        }

        [Fact]
        public void AddBeforeWhenNodeIsNullAndTShouldThrowExceptionAndDoNothing()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node = new DNode<string>("node");
            DNode<string> newNode;

            testSLList.AddFirst(node);

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);

            Assert.Throws<ArgumentNullException>(() => newNode = testSLList.AddBefore(null as DNode<string>, "newNode"));

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);
        }

        [Fact]
        public void AddBeforeWhenNodeNoExistAndTShouldThrowExceptionAndDoNothing()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");
            DNode<string> newNode;

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
        public void AddBeforeWhenIsReadOnlyShouldThrowException()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");
            DNode<string> newNode = new DNode<string>("newNode");

            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal(testSLList, node1.List);

            testSLList.ToReadOnly();

            Assert.Throws<NotSupportedException>(() => testSLList.AddBefore(node2, newNode));
        }

        [Fact]
        public void AddBeforeWhenIsReadOnlyAndTShouldThrowException()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");
            DNode<string> newNode;

            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal(testSLList, node1.List);

            testSLList.ToReadOnly();

            Assert.Throws<NotSupportedException>(() => newNode = testSLList.AddBefore(node2, "newNode"));
        }

        [Fact]
        public void AddLastWhenEmptySLLShouldAddNode()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node = new DNode<string>("test");

            testSLList.AddLast(node);

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);
            Assert.Equal("test", testSLList.Last.Value);
            Assert.Equal(testSLList.Last.NextNode, testSLList.Last.PreviousNode);
            Assert.Equal(testSLList, testSLList.Last.List);
        }

        [Fact]
        public void AddLastWhenAlreadyExistingLastShouldAddNode()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> currentLastNode = new DNode<string>("currentLast");
            DNode<string> newLastNode = new DNode<string>("newLast");

            testSLList.AddLast(currentLastNode);

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(currentLastNode, testSLList.First);
            Assert.Equal(currentLastNode, testSLList.Last);
            Assert.Equal("currentLast", testSLList.Last.Value);
            Assert.Equal(testSLList.First.NextNode, testSLList.First.PreviousNode);
            Assert.Equal(testSLList, testSLList.Last.List);

            testSLList.AddLast(newLastNode);

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(newLastNode, testSLList.Last);
            Assert.Equal(currentLastNode, testSLList.First);
            Assert.Equal("newLast", testSLList.Last.Value);
            Assert.Equal(newLastNode, testSLList.First.NextNode);
            Assert.Equal(currentLastNode, testSLList.Last.PreviousNode);
            Assert.Equal(testSLList.Last.NextNode, testSLList.First.PreviousNode);
            Assert.Equal(testSLList, testSLList.Last.List);
        }

        [Fact]
        public void AddLastWhenNodeIsNullShouldThrowExceptionAndDoNothing()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();

            Assert.Throws<ArgumentNullException>(() => testSLList.AddLast(null as DNode<string>));

            Assert.Equal(0, testSLList.Count);
            Assert.Null(testSLList.First);
            Assert.Null(testSLList.Last);
        }

        [Fact]
        public void AddLastWhenNodeListIsNotNullShouldThrowExceptionAndDoNothing()
        {
            DoubleLinkedList<string> ourTestSLList = new DoubleLinkedList<string>();
            DoubleLinkedList<string> anotherTestSLList = new DoubleLinkedList<string>();

            DNode<string> node = new DNode<string>("test");

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
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();

            DNode<string> node = testSLList.AddLast("test");

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);
            Assert.Equal("test", testSLList.Last.Value);
            Assert.Equal(testSLList.Last.NextNode, testSLList.Last.PreviousNode);
            Assert.Equal(testSLList, testSLList.Last.List);
        }

        [Fact]
        public void AddLastWhenTAndAlreadyExistingLastShouldAddNode()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();

            DNode<string> currentLastNode = testSLList.AddLast("currentLast");

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(currentLastNode, testSLList.First);
            Assert.Equal(currentLastNode, testSLList.Last);
            Assert.Equal("currentLast", testSLList.Last.Value);
            Assert.Equal(testSLList.Last.NextNode, testSLList.Last.PreviousNode);
            Assert.Equal(testSLList, testSLList.Last.List);

            DNode<string> newLastNode = testSLList.AddLast("newLast");

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(newLastNode, testSLList.Last);
            Assert.Equal(currentLastNode, testSLList.First);
            Assert.Equal("newLast", testSLList.Last.Value);
            Assert.Equal(newLastNode, testSLList.First.NextNode);
            Assert.Equal(currentLastNode, testSLList.Last.PreviousNode);
            Assert.Equal(testSLList, testSLList.Last.List);
        }

        [Fact]
        public void AddLastWhenTIsNullShouldAddNode()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();

            DNode<string> node = testSLList.AddLast(null as string);

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node, testSLList.First);
            Assert.Equal(node, testSLList.Last);
            Assert.Null(testSLList.Last.Value);
            Assert.Equal(testSLList.Last.NextNode, testSLList.Last.PreviousNode);
            Assert.Equal(testSLList, testSLList.Last.List);
        }

        [Fact]
        public void AddLastWhenSLLIsReadOnlyShouldThrowException()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node = new DNode<string>("test");

            testSLList.ToReadOnly();

            Assert.Throws<NotSupportedException>(() => testSLList.AddLast(node));

            Assert.Equal(0, testSLList.Count);
            Assert.Null(testSLList.First);
            Assert.Null(testSLList.Last);
        }

        [Fact]
        public void AddLastWhenTAndSLLIsReadOnlyShouldThrowException()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node = null;

            testSLList.ToReadOnly();

            Assert.Throws<NotSupportedException>(() => node = testSLList.AddLast("test"));

            Assert.Equal(0, testSLList.Count);
            Assert.Null(testSLList.First);
            Assert.Null(testSLList.Last);
            Assert.Null(node);
        }

        [Fact]
        public void FindWhenTExistAndFirstShouldReturnFirstNode()
        {
            DoubleLinkedList<int> testSLList = new DoubleLinkedList<int>();

            DNode<int> node1 = new DNode<int>(1);
            DNode<int> node2 = new DNode<int>(2);
            DNode<int> node3 = new DNode<int>(3);
            DNode<int> node4 = new DNode<int>(4);
            DNode<int> node5 = new DNode<int>(5);

            testSLList.AddLast(node1);
            testSLList.AddLast(node2);
            testSLList.AddLast(node3);
            testSLList.AddLast(node4);
            testSLList.AddLast(node5);

            DNode<int> foundNode = testSLList.Find(1);

            Assert.Equal(foundNode, node1);
            Assert.Equal(node2, foundNode.NextNode);
            Assert.Equal(foundNode.PreviousNode, testSLList.Last.NextNode);
        }

        [Fact]
        public void FindWhenTExistAndNotFirstShouldReturnFirstNodeContainingT()
        {
            DoubleLinkedList<int> testSLList = new DoubleLinkedList<int>();

            DNode<int> node1 = new DNode<int>(1);
            DNode<int> node2 = new DNode<int>(2);
            DNode<int> node3 = new DNode<int>(3);
            DNode<int> node4 = new DNode<int>(4);
            DNode<int> node5 = new DNode<int>(5);

            testSLList.AddLast(node1);
            testSLList.AddLast(node2);
            testSLList.AddLast(node3);
            testSLList.AddLast(node4);
            testSLList.AddLast(node5);

            DNode<int> foundNode = testSLList.Find(3);

            Assert.Equal(foundNode, node3);
            Assert.Equal(node4, foundNode.NextNode);
            Assert.Equal(node2, foundNode.PreviousNode);
        }

        [Fact]
        public void FindWhenMoreThanOneTExistShouldReturnFirstNodeContainingT()
        {
            DoubleLinkedList<int> testSLList = new DoubleLinkedList<int>();

            DNode<int> node1 = new DNode<int>(1);
            DNode<int> node2 = new DNode<int>(2);
            DNode<int> node3 = new DNode<int>(3);
            DNode<int> node4 = new DNode<int>(2);
            DNode<int> node5 = new DNode<int>(1);

            testSLList.AddLast(node1);
            testSLList.AddLast(node2);
            testSLList.AddLast(node3);
            testSLList.AddLast(node4);
            testSLList.AddLast(node5);

            DNode<int> foundNode = testSLList.Find(2);

            Assert.Equal(foundNode, node2);
            Assert.Equal(node3, foundNode.NextNode);
            Assert.Equal(node1, foundNode.PreviousNode);
        }

        [Fact]
        public void FindWhenTNoExistShouldReturnNull()
        {
            DoubleLinkedList<int> testSLList = new DoubleLinkedList<int>();

            DNode<int> node1 = new DNode<int>(1);
            DNode<int> node2 = new DNode<int>(2);
            DNode<int> node3 = new DNode<int>(3);
            DNode<int> node4 = new DNode<int>(2);
            DNode<int> node5 = new DNode<int>(1);

            testSLList.AddLast(node1);
            testSLList.AddLast(node2);
            testSLList.AddLast(node3);
            testSLList.AddLast(node4);
            testSLList.AddLast(node5);

            DNode<int> foundNode = testSLList.Find(6);

            Assert.Null(foundNode);
        }

        [Fact]
        public void FindLastWhenTExistAndLastShouldReturnLastNode()
        {
            DoubleLinkedList<int> testSLList = new DoubleLinkedList<int>();

            DNode<int> node1 = new DNode<int>(1);
            DNode<int> node2 = new DNode<int>(2);
            DNode<int> node3 = new DNode<int>(3);
            DNode<int> node4 = new DNode<int>(4);
            DNode<int> node5 = new DNode<int>(5);

            testSLList.AddLast(node1);
            testSLList.AddLast(node2);
            testSLList.AddLast(node3);
            testSLList.AddLast(node4);
            testSLList.AddLast(node5);

            DNode<int> foundNode = testSLList.FindLast(5);

            Assert.Equal(foundNode, node5);
            Assert.Equal(foundNode.NextNode, testSLList.First.PreviousNode);
            Assert.Equal(node4, foundNode.PreviousNode);
        }

        [Fact]
        public void FindLastWhenTExistAndNotLastShouldReturnLastNodeContainingT()
        {
            DoubleLinkedList<int> testSLList = new DoubleLinkedList<int>();

            DNode<int> node1 = new DNode<int>(1);
            DNode<int> node2 = new DNode<int>(2);
            DNode<int> node3 = new DNode<int>(3);
            DNode<int> node4 = new DNode<int>(4);
            DNode<int> node5 = new DNode<int>(5);

            testSLList.AddLast(node1);
            testSLList.AddLast(node2);
            testSLList.AddLast(node3);
            testSLList.AddLast(node4);
            testSLList.AddLast(node5);

            DNode<int> foundNode = testSLList.FindLast(3);

            Assert.Equal(foundNode, node3);
            Assert.Equal(node4, foundNode.NextNode);
            Assert.Equal(node2, foundNode.PreviousNode);
        }

        [Fact]
        public void FindLastWhenMoreThanOneTExistShouldReturnLastNodeContainingT()
        {
            DoubleLinkedList<int> testSLList = new DoubleLinkedList<int>();

            DNode<int> node1 = new DNode<int>(1);
            DNode<int> node2 = new DNode<int>(2);
            DNode<int> node3 = new DNode<int>(3);
            DNode<int> node4 = new DNode<int>(2);
            DNode<int> node5 = new DNode<int>(1);

            testSLList.AddLast(node1);
            testSLList.AddLast(node2);
            testSLList.AddLast(node3);
            testSLList.AddLast(node4);
            testSLList.AddLast(node5);

            DNode<int> foundNode = testSLList.FindLast(2);

            Assert.Equal(foundNode, node4);
            Assert.Equal(node5, foundNode.NextNode);
            Assert.Equal(node3, foundNode.PreviousNode);
        }

        [Fact]
        public void FindLastWhenTNoExistShouldReturnNull()
        {
            DoubleLinkedList<int> testSLList = new DoubleLinkedList<int>();

            DNode<int> node1 = new DNode<int>(1);
            DNode<int> node2 = new DNode<int>(2);
            DNode<int> node3 = new DNode<int>(3);
            DNode<int> node4 = new DNode<int>(2);
            DNode<int> node5 = new DNode<int>(1);

            testSLList.AddLast(node1);
            testSLList.AddLast(node2);
            testSLList.AddLast(node3);
            testSLList.AddLast(node4);
            testSLList.AddLast(node5);

            DNode<int> foundNode = testSLList.FindLast(6);

            Assert.Null(foundNode);
        }

        [Fact]
        public void RemoveWhenNodeExistShouldRemoveNode()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");

            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node1, testSLList.Last.PreviousNode);
            Assert.Equal(testSLList, testSLList.First.List);

            testSLList.Remove(node1);

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node2, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal(testSLList.Last.NextNode, testSLList.Last.PreviousNode);
        }

        [Fact]
        public void RemoveWhenNodeExistAndLastShouldRemoveNode()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");
            DNode<string> node3 = new DNode<string>("node3");

            testSLList.AddFirst(node3);
            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(3, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node3, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal("node3", testSLList.Last.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node2, testSLList.Last.PreviousNode);

            testSLList.Remove(node3);

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal(node2.NextNode, testSLList.First.PreviousNode);
        }

        [Fact]
        public void RemoveWhenMoreThanOneNodeWithTheSameValueExistShouldRemoveNode()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");
            DNode<string> node3 = new DNode<string>("node1");
            DNode<string> node4 = new DNode<string>("node4");

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
            Assert.Equal(node3, node4.PreviousNode);

            testSLList.Remove(node3);

            Assert.Equal(3, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node4, testSLList.Last);
            Assert.Equal(node4, node2.NextNode);
            Assert.Equal(node2, node4.PreviousNode);
        }

        [Fact]
        public void RemoveWhenNullShouldThrowExceptionAndDoNothing()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");
            DNode<string> node3 = new DNode<string>("node3");
            DNode<string> node4 = new DNode<string>("node4");

            testSLList.AddFirst(node4);
            testSLList.AddFirst(node3);
            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(4, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node4, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal("node4", testSLList.Last.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node3, testSLList.Last.PreviousNode);

            Assert.Throws<ArgumentNullException>(() => testSLList.Remove(null as DNode<string>));

            Assert.Equal(4, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node4, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal("node4", testSLList.Last.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node3, testSLList.Last.PreviousNode);
        }

        [Fact]
        public void RemoveWhenNodeDoNotBelongToListShouldThrowExceptionAndDoNothing()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DoubleLinkedList<string> anotherSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");
            DNode<string> node3 = new DNode<string>("node3");
            DNode<string> node4 = new DNode<string>("node4");

            anotherSLList.AddFirst(node4);

            testSLList.AddFirst(node3);
            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(3, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node3, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal("node3", testSLList.Last.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node2, testSLList.Last.PreviousNode);

            Assert.Throws<InvalidOperationException>(() => testSLList.Remove(node4));

            Assert.Equal(3, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node3, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal("node3", testSLList.Last.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node2, testSLList.Last.PreviousNode);
        }

        [Fact]
        public void RemoveWhenTExistShouldRemoveTAndReturnTrue()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");

            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node1, testSLList.Last.PreviousNode);
            Assert.Equal(testSLList, testSLList.First.List);

            Assert.True(testSLList.Remove("node1"));

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node2, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal(node2.NextNode, node2.PreviousNode);
        }

        [Fact]
        public void RemoveWhenTExistAndLastShouldRemoveTAndReturnTrue()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");
            DNode<string> node3 = new DNode<string>("node3");

            testSLList.AddFirst(node3);
            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(3, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node3, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal("node3", testSLList.Last.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node2, testSLList.Last.PreviousNode);

            Assert.True(testSLList.Remove("node3"));

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal(node2.NextNode, testSLList.First.PreviousNode);
            Assert.Null(node3.NextNode);
            Assert.Null(node3.PreviousNode);
        }

        [Fact]
        public void RemoveWhenMoreThanOneNodeContainingTExistShouldRemoveFirstTAndReturnTrue()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");
            DNode<string> node3 = new DNode<string>("node2");
            DNode<string> node4 = new DNode<string>("node4");

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
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node3, testSLList.Last.PreviousNode);

            Assert.True(testSLList.Remove("node2"));

            Assert.Equal(3, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node4, testSLList.Last);
            Assert.Equal(node3, node1.NextNode);
            Assert.Equal(node3, node4.PreviousNode);
            Assert.Null(node2.NextNode);
            Assert.Null(node2.PreviousNode);
        }

        [Fact]
        public void RemoveWhenTNoExistShouldReturnFalse()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");

            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node1, testSLList.Last.PreviousNode);
            Assert.Equal(testSLList, testSLList.First.List);

            Assert.False(testSLList.Remove("node3"));

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node1, testSLList.Last.PreviousNode);
            Assert.Equal(testSLList, testSLList.First.List);
        }

        [Fact]
        public void RemoveWhenSLLIsReadOnlyShouldThrowException()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");

            testSLList.AddFirst(node1);

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node1, testSLList.Last);
            Assert.Equal(node1.NextNode, node1.PreviousNode);

            testSLList.ToReadOnly();

            Assert.Throws<NotSupportedException>(() => testSLList.Remove(node1));

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node1, testSLList.Last);
            Assert.Equal(node1.NextNode, node1.PreviousNode);
        }

        [Fact]
        public void RemoveWhenTAndSLLIsReadOnlyShouldReturnFalse()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");

            testSLList.AddFirst(node1);

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node1, testSLList.Last);
            Assert.Equal(node1.NextNode, node1.PreviousNode);

            testSLList.ToReadOnly();

            Assert.False(testSLList.Remove("node1"));
            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node1, testSLList.Last);
            Assert.Equal(node1.NextNode, node1.PreviousNode);
        }

        [Fact]
        public void RemoveFirstWhenNoEmptyListShouldRemoveFirstNode()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");

            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node1, testSLList.Last.PreviousNode);
            Assert.Equal(testSLList, testSLList.First.List);

            testSLList.RemoveFirst();

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node2, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal(node2.NextNode, node2.PreviousNode);
            Assert.Null(node1.NextNode);
            Assert.Null(node1.PreviousNode);
        }

        [Fact]
        public void RemoveFirstWhenOnlyOneNodeShouldRemoveFirstNode()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");

            testSLList.AddFirst(node1);

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node1, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal(node1.NextNode, node1.PreviousNode);
            Assert.Equal(testSLList, testSLList.First.List);

            testSLList.RemoveFirst();

            Assert.Equal(0, testSLList.Count);
            Assert.Equal(testSLList.First, testSLList.Last);
            Assert.Null(node1.NextNode);
            Assert.Null(node1.PreviousNode);
            Assert.Null(node1.List);
        }

        [Fact]
        public void RemoveFirstWhenEmptyListShouldThrowExceptionAndDoNothing()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();

            Assert.Equal(0, testSLList.Count);
            Assert.Null(testSLList.First);
            Assert.Null(testSLList.Last);

            Assert.Throws<InvalidOperationException>(() => testSLList.RemoveFirst());

            Assert.Equal(0, testSLList.Count);
            Assert.Null(testSLList.First);
            Assert.Null(testSLList.Last);
        }

        [Fact]
        public void RemoveFirstWhenSLLIsReadOnlyShouldThrowException()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");

            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node1, testSLList.Last.PreviousNode);
            Assert.Equal(testSLList, testSLList.First.List);

            testSLList.ToReadOnly();

            Assert.Throws<NotSupportedException>(() => testSLList.RemoveFirst());

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node1, testSLList.Last.PreviousNode);
            Assert.Equal(testSLList, testSLList.First.List);
        }

        [Fact]
        public void RemoveLastWhenNoEmptyListShouldRemoveLastNode()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");

            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node1, testSLList.Last.PreviousNode);
            Assert.Equal(testSLList, testSLList.First.List);

            testSLList.RemoveLast();

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node1, testSLList.Last);
            Assert.Equal(node1.NextNode, node1.PreviousNode);
            Assert.Null(node2.NextNode);
            Assert.Null(node2.PreviousNode);
            Assert.Null(node2.List);
        }

        [Fact]
        public void RemoveLastWhenOnlyOneNodeShouldRemoveLastNode()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");

            testSLList.AddFirst(node1);

            Assert.Equal(1, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node1, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal(testSLList.First.NextNode, testSLList.First.PreviousNode);
            Assert.Equal(testSLList, testSLList.First.List);

            testSLList.RemoveLast();

            Assert.Equal(0, testSLList.Count);
            Assert.Equal(testSLList.First, testSLList.Last);
            Assert.Null(node1.NextNode);
            Assert.Null(node1.PreviousNode);
            Assert.Null(node1.List);
        }

        [Fact]
        public void RemoveLastWhenEmptyListShouldThrowExceptionAndDoNothing()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();

            Assert.Equal(0, testSLList.Count);
            Assert.Null(testSLList.First);
            Assert.Null(testSLList.Last);

            Assert.Throws<InvalidOperationException>(() => testSLList.RemoveLast());

            Assert.Equal(0, testSLList.Count);
            Assert.Null(testSLList.First);
            Assert.Null(testSLList.Last);
        }

        [Fact]
        public void RemoveLastWhenSLLIsReadOnlyShouldThrowException()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");

            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node1, testSLList.Last.PreviousNode);
            Assert.Equal(testSLList, testSLList.First.List);

            testSLList.ToReadOnly();

            Assert.Throws<NotSupportedException>(() => testSLList.RemoveLast());

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node1, testSLList.Last.PreviousNode);
            Assert.Equal(testSLList, testSLList.First.List);
        }

        [Fact]
        public void ClearWhenEmptyListShouldDoNothing()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();

            Assert.Equal(0, testSLList.Count);
            Assert.Null(testSLList.First);
            Assert.Null(testSLList.Last);

            testSLList.Clear();

            Assert.Equal(0, testSLList.Count);
            Assert.Null(testSLList.First);
            Assert.Null(testSLList.Last);
        }

        [Fact]
        public void ClearWhenNotEmptyListShouldRemoveAllNodes()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");
            DNode<string> node3 = new DNode<string>("node3");
            DNode<string> node4 = new DNode<string>("node4");

            testSLList.AddFirst(node4);
            testSLList.AddFirst(node3);
            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(4, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node4, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal("node4", testSLList.Last.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node3, testSLList.Last.PreviousNode);

            testSLList.Clear();

            Assert.Equal(0, testSLList.Count);
            Assert.Null(testSLList.First);
            Assert.Null(testSLList.Last);
            Assert.Null(node1.NextNode);
            Assert.Null(node1.PreviousNode);
            Assert.Null(node1.List);
            Assert.Null(node2.NextNode);
            Assert.Null(node2.PreviousNode);
            Assert.Null(node2.List);
            Assert.Null(node3.NextNode);
            Assert.Null(node3.PreviousNode);
            Assert.Null(node3.List);
            Assert.Null(node4.NextNode);
            Assert.Null(node4.PreviousNode);
            Assert.Null(node4.List);
        }

        [Fact]
        public void ClearWhenSLLIsReadOnlyShouldThrowException()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");

            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node1, testSLList.Last.PreviousNode);
            Assert.Equal(testSLList, testSLList.First.List);

            testSLList.ToReadOnly();

            Assert.Throws<NotSupportedException>(() => testSLList.Clear());

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node1, testSLList.Last.PreviousNode);
            Assert.Equal(testSLList, testSLList.First.List);
        }

        [Fact]
        public void ContainsWhenExistShouldReturnTrue()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");

            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node1, testSLList.Last.PreviousNode);
            Assert.Equal(testSLList, testSLList.First.List);

            Assert.True(testSLList.Contains("node2"));
        }

        [Fact]
        public void ContainsWhenExistAndNullValueShouldReturnTrue()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>(null);
            DNode<string> node2 = new DNode<string>("node2");

            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Null(testSLList.First.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node1, testSLList.Last.PreviousNode);
            Assert.Equal(testSLList, testSLList.First.List);

            Assert.True(testSLList.Contains(null));
        }

        [Fact]
        public void ContainsWhenNoExistShouldReturnFalse()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");

            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            Assert.Equal(2, testSLList.Count);
            Assert.Equal(node1, testSLList.First);
            Assert.Equal(node2, testSLList.Last);
            Assert.Equal("node1", testSLList.First.Value);
            Assert.Equal(node2, testSLList.First.NextNode);
            Assert.Equal(node1, testSLList.Last.PreviousNode);
            Assert.Equal(testSLList, testSLList.First.List);

            Assert.False(testSLList.Contains("node3"));
        }

        [Fact]
        public void CopyToWhenSLListFitsShouldCopyValues()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");
            DNode<string> node3 = new DNode<string>("node3");

            testSLList.AddFirst(node3);
            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            string[] destinationArray = new string[4];

            testSLList.CopyTo(destinationArray, 0);

            Assert.Equal(node1.Value, destinationArray[0]);
            Assert.Equal(node2.Value, destinationArray[1]);
            Assert.Equal(node3.Value, destinationArray[2]);
        }

        [Fact]
        public void CopyToWhenNullArrayShouldThrowExceptionAndDoNothing()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");
            DNode<string> node3 = new DNode<string>("node3");

            testSLList.AddFirst(node3);
            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            string[] destinationArray = null;

            Assert.Throws<ArgumentNullException>(() => testSLList.CopyTo(destinationArray, 0));

            Assert.Null(destinationArray);
        }

        [Fact]
        public void CopyToWhenIndexIsNegativeShouldThrowExceptionAndDoNothing()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");
            DNode<string> node3 = new DNode<string>("node3");

            testSLList.AddFirst(node3);
            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            string[] destinationArray = new string[4];

            Assert.Throws<ArgumentOutOfRangeException>(() => testSLList.CopyTo(destinationArray, -1));

            Assert.Null(destinationArray[0]);
            Assert.Null(destinationArray[1]);
            Assert.Null(destinationArray[2]);
        }

        [Fact]
        public void CopyToWhenIndexIsGreaterThanDestinationArrayLengthShouldThrowExceptionAndDoNothing()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");
            DNode<string> node3 = new DNode<string>("node3");

            testSLList.AddFirst(node3);
            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            string[] destinationArray = new string[4];

            Assert.Throws<ArgumentOutOfRangeException>(() => testSLList.CopyTo(destinationArray, 5));

            Assert.Null(destinationArray[0]);
            Assert.Null(destinationArray[1]);
            Assert.Null(destinationArray[2]);
        }

        [Fact]
        public void CopyToWhenDestinationArrayLengthIsSmallerThanCountShouldThrowExceptionAndDoNothing()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");
            DNode<string> node3 = new DNode<string>("node3");

            testSLList.AddFirst(node3);
            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            string[] destinationArray = new string[2];

            Assert.Throws<ArgumentException>(() => testSLList.CopyTo(destinationArray, 0));

            Assert.Null(destinationArray[0]);
            Assert.Null(destinationArray[1]);
        }

        [Fact]
        public void CopyToWhenDestinationArrayAvailableSpaceIsSmallerThanCountShouldThrowExceptionAndDoNothing()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");
            DNode<string> node3 = new DNode<string>("node3");

            testSLList.AddFirst(node3);
            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            string[] destinationArray = new string[5];

            Assert.Throws<ArgumentException>(() => testSLList.CopyTo(destinationArray, 4));

            Assert.Null(destinationArray[4]);
        }

        [Fact]
        public void CopyToWhenDestinationArrayIsOfTheSameSizeShouldCopyTheElements()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");
            DNode<string> node3 = new DNode<string>("node3");

            testSLList.AddFirst(node3);
            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            string[] destinationArray = new string[3];

            testSLList.CopyTo(destinationArray, 0);

            Assert.Equal(node1.Value, destinationArray[0]);
            Assert.Equal(node2.Value, destinationArray[1]);
            Assert.Equal(node3.Value, destinationArray[2]);
        }

        [Fact]
        public void ToReadOnlyWhenAnyShouldSetIsReadOnlyAsTrue()
        {
            DoubleLinkedList<string> testSLList = new DoubleLinkedList<string>();
            DNode<string> node1 = new DNode<string>("node1");
            DNode<string> node2 = new DNode<string>("node2");
            DNode<string> node3 = new DNode<string>("node3");

            testSLList.AddFirst(node3);
            testSLList.AddFirst(node2);
            testSLList.AddFirst(node1);

            testSLList.ToReadOnly();

            Assert.True(testSLList.IsReadOnly);
        }
    }
}

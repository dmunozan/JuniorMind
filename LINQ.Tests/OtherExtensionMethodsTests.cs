﻿using System;
using System.Collections.Generic;
using Xunit;

namespace LINQ.Tests
{
    public class OtherExtensionMethodsTests
    {
        [Fact]
        public void RangeWhenValidNumbersShouldReturnIntSequence()
        {
            IEnumerable<int> numbers = OtherExtensionMethods.Range(1, 5);

            Assert.Collection(numbers,
                item => Assert.Equal(1, item),
                item => Assert.Equal(2, item),
                item => Assert.Equal(3, item),
                item => Assert.Equal(4, item),
                item => Assert.Equal(5, item));
        }

        [Fact]
        public void RangeWhenCountIs0ShouldReturnEmptySequence()
        {
            IEnumerable<int> numbers = OtherExtensionMethods.Range(1, 0);

            Assert.Empty(numbers);
        }

        [Fact]
        public void RangeWhenCountIsLessThan0ShouldThrowException()
        {
            IEnumerable<int> numbers;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                numbers = OtherExtensionMethods.Range(1, -1));
        }

        [Fact]
        public void RangeWhenLastValueIsMoreThanMaxValueShouldThrowException()
        {
            IEnumerable<int> numbers;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                numbers = OtherExtensionMethods.Range(int.MaxValue, 2));
        }

        [Fact]
        public void RangeWhenStartIsMaxValueAndCount1ShouldReturnMaxValueAsOnlyValue()
        {
            IEnumerable<int> numbers = OtherExtensionMethods.Range(int.MaxValue, 1);

            Assert.Collection(numbers,
                item => Assert.Equal(int.MaxValue, item));
        }

        [Fact]
        public void RangeWhenStartIsMinValueAndCount0ShouldReturnEmptySequence()
        {
            IEnumerable<int> numbers = OtherExtensionMethods.Range(int.MinValue, 0);

            Assert.Empty(numbers);
        }

        [Fact]
        public void EmptyWhenAnyShouldReturnEmptySequence()
        {
            IEnumerable<int> emptySequence = OtherExtensionMethods.Empty<int>();

            Assert.Empty(emptySequence);
        }

        [Fact]
        public void RepeatWhenCountIs0ShouldReturnEmptySequence()
        {
            IEnumerable<string> strings = OtherExtensionMethods.Repeat("test", 0);

            Assert.Empty(strings);
        }

        [Fact]
        public void RepeatWhenCountIsMoreThan0ShouldReturnSequenceWithCountElements()
        {
            IEnumerable<string> strings = OtherExtensionMethods.Repeat("test", 2);

            Assert.Collection(strings,
                item => Assert.Equal("test", item),
                item => Assert.Equal("test", item));
        }

        [Fact]
        public void RepeatWhenCountIsLessThan0ShouldThrowException()
        {
            IEnumerable<string> strings;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                strings = OtherExtensionMethods.Repeat("test", -1));
        }

        [Fact]
        public void CountWhenEmptySequenceShouldReturn0()
        {
            ListCollection<int> testList = new ListCollection<int>();

            Assert.Equal(0, testList.Count(x => x % 2 == 0));
        }

        [Fact]
        public void CountWhenAnyElementShouldReturnNumberOfElementsThatMatchesPredicate()
        {
            ListCollection<int> testList = new ListCollection<int>();

            testList.Add(1);
            testList.Add(2);
            testList.Add(3);
            testList.Add(4);

            Assert.Equal(2, testList.Count(x => x % 2 == 0));
        }

        [Fact]
        public void CountWhenSourceIsNullShouldThrowException()
        {
            ListCollection<int> testList = null;

            Assert.Throws<ArgumentNullException>(() => testList.Count(x => x % 2 == 0));
        }

        [Fact]
        public void CountWhenPredicateIsNullShouldThrowException()
        {
            ListCollection<int> testList = new ListCollection<int>();

            testList.Add(1);
            testList.Add(2);
            testList.Add(3);
            testList.Add(4);

            Func<int, bool> predicate = null;

            Assert.Throws<ArgumentNullException>(() => testList.Count(predicate));
        }

        [Fact]
        public void ConcatWhenTwoEmptySequencesShouldReturnEmptySequence()
        {
            ListCollection<string> firstTestList = new ListCollection<string>();

            ListCollection<string> secondTestList = new ListCollection<string>();

            IEnumerable<string> resultList = firstTestList.Concat(secondTestList);

            Assert.Empty(resultList);
        }

        [Fact]
        public void ConcatWhenFirstEmptySequenceShouldReturnSecondSequence()
        {
            ListCollection<string> firstTestList = new ListCollection<string>();

            ListCollection<string> secondTestList = new ListCollection<string>();

            secondTestList.Add("green");
            secondTestList.Add("blue");

            IEnumerable<string> resultList = firstTestList.Concat(secondTestList);

            Assert.Collection(resultList,
                item => Assert.Equal("green", item),
                item => Assert.Equal("blue", item));
        }

        [Fact]
        public void ConcatWhenSecondEmptySequenceShouldReturnFirstSequence()
        {
            ListCollection<string> firstTestList = new ListCollection<string>();

            firstTestList.Add("red");
            firstTestList.Add("green");

            ListCollection<string> secondTestList = new ListCollection<string>();

            IEnumerable<string> resultList = firstTestList.Concat(secondTestList);

            Assert.Collection(resultList,
                item => Assert.Equal("red", item),
                item => Assert.Equal("green", item));
        }

        [Fact]
        public void ConcatWhenNoEmptySequenceShouldReturnConcatenatedSequences()
        {
            ListCollection<string> firstTestList = new ListCollection<string>();

            firstTestList.Add("red");
            firstTestList.Add("green");

            ListCollection<string> secondTestList = new ListCollection<string>();

            secondTestList.Add("green");
            secondTestList.Add("blue");

            IEnumerable<string> resultList = firstTestList.Concat(secondTestList);

            Assert.Collection(resultList,
                item => Assert.Equal("red", item),
                item => Assert.Equal("green", item),
                item => Assert.Equal("green", item),
                item => Assert.Equal("blue", item));
        }

        [Fact]
        public void ConcatWhenNullFirstShouldThrowException()
        {
            ListCollection<string> firstTestList = null;

            ListCollection<string> secondTestList = new ListCollection<string>();

            secondTestList.Add("green");
            secondTestList.Add("blue");

            IEnumerable<string> resultList;

            Assert.Throws<ArgumentNullException>(() => resultList = firstTestList.Concat(secondTestList));
        }

        [Fact]
        public void ConcatWhenNullSecondShouldThrowException()
        {
            ListCollection<string> firstTestList = new ListCollection<string>();

            firstTestList.Add("red");
            firstTestList.Add("green");

            ListCollection<string> secondTestList = null;

            IEnumerable<string> resultList;

            Assert.Throws<ArgumentNullException>(() => resultList = firstTestList.Concat(secondTestList));
        }

        [Fact]
        public void LinqSingleWhenEmptySequenceShouldThrowException()
        {
            ListCollection<string> testList = new ListCollection<string>();

            string resultString;

            Assert.Throws<InvalidOperationException>(() => resultString = testList.LinqSingle(x => x.Length == 5));
        }

        [Fact]
        public void LinqSingleWhenOnlyOneMatchingElementShouldReturnElement()
        {
            ListCollection<string> testList = new ListCollection<string>();

            testList.Add("red");
            testList.Add("green");
            testList.Add("blue");

            string resultString = testList.LinqSingle(x => x.Length == 5);

            Assert.Equal("green", resultString);
        }

        [Fact]
        public void LinqSingleWhenNoElementMatchShouldThrowException()
        {
            ListCollection<string> testList = new ListCollection<string>();

            testList.Add("red");
            testList.Add("blue");

            string resultString;

            Assert.Throws<InvalidOperationException>(() => resultString = testList.LinqSingle(x => x.Length == 5));
        }

        [Fact]
        public void LinqSingleWhenMoreThanOneElementMatchShouldThrowException()
        {
            ListCollection<string> testList = new ListCollection<string>();

            testList.Add("red");
            testList.Add("green");
            testList.Add("blue");
            testList.Add("black");

            string resultString;

            Assert.Throws<InvalidOperationException>(() => resultString = testList.LinqSingle(x => x.Length == 5));
        }

        [Fact]
        public void LinqSingleWhenSourceIsNullShouldThrowException()
        {
            ListCollection<string> testList = null;

            string resultString;

            Assert.Throws<ArgumentNullException>(() => resultString = testList.LinqSingle(x => x.Length == 5));
        }

        [Fact]
        public void LinqSingleWhenPredicateIsNullShouldThrowException()
        {
            ListCollection<string> testList = new ListCollection<string>();

            testList.Add("red");
            testList.Add("green");
            testList.Add("blue");

            Func<string, bool> predicate = null;

            string resultString;

            Assert.Throws<ArgumentNullException>(() => resultString = testList.LinqSingle(predicate));
        }

        [Fact]
        public void LastWhenEmptySequenceShouldThrowException()
        {
            ListCollection<string> testList = new ListCollection<string>();

            string resultString;

            Assert.Throws<InvalidOperationException>(() => resultString = testList.Last(x => x.Length == 5));
        }

        [Fact]
        public void LastWhenMatchingElementsShouldReturnLastMatchingElement()
        {
            ListCollection<string> testList = new ListCollection<string>();

            testList.Add("red");
            testList.Add("green");
            testList.Add("blue");
            testList.Add("black");

            string resultString = testList.Last(x => x.Length == 5);

            Assert.Equal("black", resultString);
        }

        [Fact]
        public void LastWhenNoElementMatchesShouldThrowException()
        {
            ListCollection<string> testList = new ListCollection<string>();

            testList.Add("red");
            testList.Add("blue");

            string resultString;

            Assert.Throws<InvalidOperationException>(() => resultString = testList.Last(x => x.Length == 5));
        }

        [Fact]
        public void LastWhenSourceIsNullShouldThrowException()
        {
            ListCollection<string> testList = null;

            string resultString;

            Assert.Throws<ArgumentNullException>(() => resultString = testList.Last(x => x.Length == 5));
        }

        [Fact]
        public void LastWhenPredicateIsNullShouldThrowException()
        {
            ListCollection<string> testList = new ListCollection<string>();

            testList.Add("red");
            testList.Add("green");
            testList.Add("blue");

            Func<string, bool> predicate = null;

            string resultString;

            Assert.Throws<ArgumentNullException>(() => resultString = testList.Last(predicate));
        }

        [Fact]
        public void TakeWhileWhenEmptySequenceShouldReturnEmptySequence()
        {
            ListCollection<string> testList = new ListCollection<string>();

            IEnumerable<string> resultList =
                testList.TakeWhile(fruit => String.Compare("mango", fruit, true) != 0);

            Assert.Empty(resultList);
        }

        [Fact]
        public void TakeWhileWhenNoEmptyShouldReturnElementsWhileTruePredicate()
        {
            ListCollection<string> testList = new ListCollection<string>();

            testList.Add("apple");
            testList.Add("banana");
            testList.Add("mango");
            testList.Add("orange");

            IEnumerable<string> resultList =
                testList.TakeWhile(fruit => String.Compare("mango", fruit, true) != 0);

            Assert.Collection(resultList,
                item => Assert.Equal("apple", item),
                item => Assert.Equal("banana", item));
        }

        [Fact]
        public void TakeWhileWhenSourceIsNullShouldThrowException()
        {
            ListCollection<string> testList = null;

            IEnumerable<string> resultList;
            
            Assert.Throws<ArgumentNullException>(() => resultList =
                testList.TakeWhile(fruit => String.Compare("mango", fruit, true) != 0));
        }

        [Fact]
        public void TakeWhileWhenPredicateIsNullShouldThrowException()
        {
            ListCollection<string> testList = new ListCollection<string>();

            testList.Add("apple");
            testList.Add("banana");
            testList.Add("mango");
            testList.Add("orange");

            IEnumerable<string> resultList;

            Func<string, bool> predicate = null;

            Assert.Throws<ArgumentNullException>(() => resultList =
                testList.TakeWhile(predicate));
        }

        [Fact]
        public void SkipWhileWhenEmptySequenceShouldReturnEmptySequence()
        {
            ListCollection<int> testList = new ListCollection<int>();

            IEnumerable<int> resultList =
                testList.SkipWhile(grade => grade >= 80);

            Assert.Empty(resultList);
        }

        [Fact]
        public void SkipWhileWhenNoEmptyShouldReturnElementsFromFalsePredicateToTheEnd()
        {
            ListCollection<int> testList = new ListCollection<int>();

            testList.Add(95);
            testList.Add(82);
            testList.Add(70);
            testList.Add(89);

            IEnumerable<int> resultList =
                testList.SkipWhile(grade => grade >= 80);

            Assert.Collection(resultList,
                item => Assert.Equal(70, item),
                item => Assert.Equal(89, item));
        }

        [Fact]
        public void SkipWhileWhenNullSourceShouldThrowException()
        {
            ListCollection<int> testList = null;

            IEnumerable<int> resultList;

            Assert.Throws<ArgumentNullException>(() => resultList =
                testList.SkipWhile(grade => grade >= 80));
        }

        [Fact]
        public void SkipWhileWhenNullPredicateShouldThrowException()
        {
            ListCollection<int> testList = new ListCollection<int>();

            testList.Add(95);
            testList.Add(82);
            testList.Add(70);
            testList.Add(89);

            IEnumerable<int> resultList;

            Func<int, bool> predicate = null;

            Assert.Throws<ArgumentNullException>(() => resultList =
                testList.SkipWhile(predicate));
        }
    }
}

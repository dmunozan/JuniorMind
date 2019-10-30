using System;
using System.Collections.Generic;
using Xunit;

namespace LINQ.Tests
{
    public class ExtensionMethodsTests
    {
        [Fact]
        public void AllWhenEmptyShouldReturnTrue()
        {
            ListCollection<int> testList = new ListCollection<int>();

            Assert.True(testList.All(e => e % 2 == 0));
        }

        [Fact]
        public void AllWhenAllTheElementsMeetTheConditionShouldReturnTrue()
        {
            ListCollection<int> testList = new ListCollection<int>();

            testList.Add(2);
            testList.Add(4);
            testList.Add(6);
            testList.Add(8);

            Assert.True(testList.All(e => e % 2 == 0));
        }

        [Fact]
        public void AllWhenNotAllTheElementsMeetTheConditionShouldReturnFalse()
        {
            ListCollection<int> testList = new ListCollection<int>();

            testList.Add(2);
            testList.Add(4);
            testList.Add(6);
            testList.Add(9);

            Assert.False(testList.All(e => e % 2 == 0));
        }

        [Fact]
        public void AllWhenSourceIsNullShouldThrowException()
        {
            ListCollection<int> testList = null;

            Assert.Throws<ArgumentNullException>(() => testList.All(e => e % 2 == 0));
        }

        [Fact]
        public void AllWhenPredicateIsNullShouldThrowException()
        {
            ListCollection<int> testList = new ListCollection<int>();

            testList.Add(2);
            testList.Add(4);
            testList.Add(6);
            testList.Add(8);

            Assert.Throws<ArgumentNullException>(() => testList.All(null));
        }

        [Fact]
        public void AnyWhenEmptyShouldReturnFalse()
        {
            ListCollection<int> testList = new ListCollection<int>();

            Assert.False(testList.Any(e => e % 2 == 0));
        }

        [Fact]
        public void AnyWhenAtLeastOneElementMeetTheConditionShouldReturnTrue()
        {
            ListCollection<int> testList = new ListCollection<int>();

            testList.Add(1);
            testList.Add(3);
            testList.Add(6);
            testList.Add(9);

            Assert.True(testList.Any(e => e % 2 == 0));
        }

        [Fact]
        public void AnyWhenNoneOfTheElementsMeetTheConditionShouldReturnFalse()
        {
            ListCollection<int> testList = new ListCollection<int>();

            testList.Add(1);
            testList.Add(3);
            testList.Add(5);
            testList.Add(9);

            Assert.False(testList.Any(e => e % 2 == 0));
        }

        [Fact]
        public void AnyWhenSourceIsNullShouldThrowException()
        {
            ListCollection<int> testList = null;

            Assert.Throws<ArgumentNullException>(() => testList.Any(e => e % 2 == 0));
        }

        [Fact]
        public void AnyWhenPredicateIsNullShouldThrowException()
        {
            ListCollection<int> testList = new ListCollection<int>();

            testList.Add(2);
            testList.Add(4);
            testList.Add(6);
            testList.Add(8);

            Assert.Throws<ArgumentNullException>(() => testList.Any(null));
        }

        [Fact]
        public void FirstWhenAtLeastOneElementMeetTheConditionShouldReturnFirstElementMatchingTheCondition()
        {
            ListCollection<int> testList = new ListCollection<int>();

            testList.Add(1);
            testList.Add(2);
            testList.Add(6);
            testList.Add(9);

            Assert.Equal(2, testList.First(e => e % 2 == 0));
        }

        [Fact]
        public void FirstWhenNoneOfTheElementsMeetTheConditionShouldThrowException()
        {
            ListCollection<int> testList = new ListCollection<int>();

            testList.Add(1);
            testList.Add(3);
            testList.Add(7);
            testList.Add(9);

            Assert.Throws<InvalidOperationException>(() => testList.First(e => e % 2 == 0));
        }

        [Fact]
        public void FirstWhenEmptyShouldThrowException()
        {
            ListCollection<int> testList = new ListCollection<int>();

            Assert.Throws<InvalidOperationException>(() => testList.First(e => e % 2 == 0));
        }

        [Fact]
        public void FirstWhenSourceIsNullShouldThrowException()
        {
            ListCollection<int> testList = null;

            Assert.Throws<ArgumentNullException>(() => testList.First(e => e % 2 == 0));
        }

        [Fact]
        public void FirstWhenPredicateIsNullShouldThrowException()
        {
            ListCollection<int> testList = new ListCollection<int>();

            testList.Add(2);
            testList.Add(4);
            testList.Add(6);
            testList.Add(8);

            Assert.Throws<ArgumentNullException>(() => testList.First(null));
        }

        [Fact]
        public void SelectWhenEmptyShouldReturnEmptySequence()
        {
            ListCollection<int> testList = new ListCollection<int>();

            IEnumerable<int> resultList = testList.Select(e => e * e);

            Assert.Empty(resultList);
        }

        [Fact]
        public void SelectWhenAnyElementShouldReturnSequenceWithProcessedElements()
        {
            ListCollection<int> testList = new ListCollection<int>();

            testList.Add(1);
            testList.Add(2);
            testList.Add(3);
            testList.Add(4);

            IEnumerable<int> resultList = testList.Select(e => e * e);

            Assert.Contains(1, resultList);
            Assert.DoesNotContain(2, resultList);
            Assert.DoesNotContain(3, resultList);
            Assert.Contains(4, resultList);
            Assert.Contains(9, resultList);
            Assert.Contains(16, resultList);
        }

        [Fact]
        public void SelectWhenSourceIsNullShouldThrowException()
        {
            ListCollection<int> testList = null;

            Assert.Throws<ArgumentNullException>(() => testList.Select(e => e * e));
        }

        [Fact]
        public void SelectWhenSelectorIsNullShouldThrowException()
        {
            ListCollection<int> testList = new ListCollection<int>();

            testList.Add(1);
            testList.Add(2);
            testList.Add(3);
            testList.Add(4);

            Func<int, int> selector = null;

            Assert.Throws<ArgumentNullException>(() => testList.Select(selector));
        }

        [Fact]
        public void SelectManyWhenEmptyShouldReturnEmptySequence()
        {
            ListCollection<string[]> testList = new ListCollection<string[]>();

            IEnumerable<string> resultList = testList.SelectMany(e => e);

            Assert.Empty(resultList);
        }

        [Fact]
        public void SelectManyWhenAnyElementShouldReturnSequenceWithProcessedElements()
        {
            ListCollection<string[]> testList = new ListCollection<string[]>();

            testList.Add(new[] { "a", "b" });
            testList.Add(new[] { "c", "d" });

            IEnumerable<string> resultList = testList.SelectMany(e => e);

            Assert.Contains("a", resultList);
            Assert.Contains("b", resultList);
            Assert.Contains("c", resultList);
            Assert.Contains("d", resultList);
        }

        [Fact]
        public void SelectManyWhenSourceIsNullShouldThrowException()
        {
            ListCollection<string[]> testList = null;

            Assert.Throws<ArgumentNullException>(() => testList.SelectMany(e => e));
        }

        [Fact]
        public void SelectManyWhenSelectorIsNullShouldThrowException()
        {
            ListCollection<string[]> testList = new ListCollection<string[]>();

            testList.Add(new[] { "a", "b" });
            testList.Add(new[] { "c", "d" });

            Func<string[], string> selector = null;

            Assert.Throws<ArgumentNullException>(() => testList.SelectMany(selector));
        }

        [Fact]
        public void WhereWhenEmptyShouldReturnEmptySequence()
        {
            ListCollection<int> testList = new ListCollection<int>();

            IEnumerable<int> resultList = testList.Where(e => e % 2 == 0);

            Assert.Empty(resultList);
        }

        [Fact]
        public void WhereWhenAnyElementShouldReturnSequenceWithElementsThatMeetTheCondition()
        {
            ListCollection<int> testList = new ListCollection<int>();

            testList.Add(1);
            testList.Add(2);
            testList.Add(3);
            testList.Add(4);

            IEnumerable<int> resultList = testList.Where(e => e % 2 == 0);

            Assert.DoesNotContain(1, resultList);
            Assert.Contains(2, resultList);
            Assert.DoesNotContain(3, resultList);
            Assert.Contains(4, resultList);
        }
    }
}

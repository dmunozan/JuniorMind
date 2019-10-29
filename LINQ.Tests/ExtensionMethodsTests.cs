using System;
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
    }
}

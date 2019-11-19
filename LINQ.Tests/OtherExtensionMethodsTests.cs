using System;
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
    }
}

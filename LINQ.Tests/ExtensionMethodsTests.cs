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

        [Fact]
        public void WhereWhenSourceIsNullShouldThrowException()
        {
            ListCollection<int> testList = null;

            Assert.Throws<ArgumentNullException>(() => testList.Where(e => e % 2 == 0));
        }

        [Fact]
        public void WhereWhenPredicateIsNullShouldThrowException()
        {
            ListCollection<int> testList = new ListCollection<int>();

            testList.Add(1);
            testList.Add(2);
            testList.Add(3);
            testList.Add(4);

            Assert.Throws<ArgumentNullException>(() => testList.Where(null));
        }

        [Fact]
        public void ToDictionaryWhenEmptyShouldReturnEmptyDictionary()
        {
            ListCollection<string> testList = new ListCollection<string>();

            Dictionary<int, string> dictionary = testList.ToDictionary(e => Math.Abs(e.GetHashCode()), e => e);

            Assert.Empty(dictionary);
        }

        [Fact]
        public void ToDictionaryWhenAnyElementAndNoKeyIsRepeatedShouldReturnDictionary()
        {
            ListCollection<string> testList = new ListCollection<string>();

            testList.Add("cat");
            testList.Add("dog");
            testList.Add("mouse");
            testList.Add("bird");

            Dictionary<int, string> dictionary = testList.ToDictionary(e => Math.Abs(e.GetHashCode()), e => e);

            Assert.Contains(new KeyValuePair<int, string>(Math.Abs("cat".GetHashCode()), "cat"), dictionary);
            Assert.Contains(new KeyValuePair<int, string>(Math.Abs("dog".GetHashCode()), "dog"), dictionary);
            Assert.Contains(new KeyValuePair<int, string>(Math.Abs("mouse".GetHashCode()), "mouse"), dictionary);
            Assert.Contains(new KeyValuePair<int, string>(Math.Abs("bird".GetHashCode()), "bird"), dictionary);
        }

        [Fact]
        public void ToDictionaryWhenAnyElementAndKeyIsRepeatedShouldThrowException()
        {
            ListCollection<string> testList = new ListCollection<string>();

            testList.Add("cat");
            testList.Add("cat");

            Assert.Throws<ArgumentException>(() => testList.ToDictionary(e => Math.Abs(e.GetHashCode()), e => e));
        }

        [Fact]
        public void ToDictionaryWhenSourceIsNullShouldThrowException()
        {
            ListCollection<int> testList = null;

            Assert.Throws<ArgumentNullException>(() => testList.ToDictionary(e => Math.Abs(e.GetHashCode()), e => e));
        }

        [Fact]
        public void ToDictionaryWhenKeySelectorIsNullShouldThrowException()
        {
            ListCollection<string> testList = new ListCollection<string>();

            testList.Add("cat");
            testList.Add("dog");
            testList.Add("mouse");
            testList.Add("bird");

            Func<string, int> keySelector = null;

            Assert.Throws<ArgumentNullException>(() => testList.ToDictionary(keySelector, e => e));
        }

        [Fact]
        public void ToDictionaryWhenElementSelectorIsNullShouldThrowException()
        {
            ListCollection<string> testList = new ListCollection<string>();

            testList.Add("cat");
            testList.Add("dog");
            testList.Add("mouse");
            testList.Add("bird");

            Func<string, string> elementSelector = null;

            Assert.Throws<ArgumentNullException>(() => testList.ToDictionary(e => Math.Abs(e.GetHashCode()), elementSelector));
        }

        [Fact]
        public void ToDictionaryWhenKeySelectorProducesNullKeyShouldThrowException()
        {
            ListCollection<string> testList = new ListCollection<string>();

            testList.Add("cat");
            testList.Add("dog");
            testList.Add("mouse");
            testList.Add("bird");

            Func<string, string> keySelector = e => null;

            Assert.Throws<ArgumentNullException>(() => testList.ToDictionary(keySelector, e => e)); ;
        }

        [Fact]
        public void ZipWhenAtLeastOneEmptySequenceShouldReturnEmptySequence()
        {
            ListCollection<int> firstTestList = new ListCollection<int>();
            ListCollection<int> secondTestList = new ListCollection<int>();

            IEnumerable<int> resultList = firstTestList.Zip(secondTestList, (first, second) => first + second);

            Assert.Empty(resultList);
        }

        [Fact]
        public void ZipWhenNoneEmptySequenceShouldReturnSequenceWithMergedElementsAsLongAsShortestSequence()
        {
            ListCollection<int> firstTestList = new ListCollection<int>();

            firstTestList.Add(1);
            firstTestList.Add(2);
            firstTestList.Add(3);
            firstTestList.Add(4);

            ListCollection<int> secondTestList = new ListCollection<int>();

            secondTestList.Add(1);
            secondTestList.Add(2);
            secondTestList.Add(3);
            secondTestList.Add(4);
            secondTestList.Add(5);

            IEnumerable<int> resultList = firstTestList.Zip(secondTestList, (first, second) => first + second);

            Assert.DoesNotContain(1, resultList);
            Assert.Contains(2, resultList);
            Assert.DoesNotContain(3, resultList);
            Assert.Contains(4, resultList);
            Assert.DoesNotContain(5, resultList);
            Assert.Contains(6, resultList);
            Assert.Contains(8, resultList);
        }

        [Fact]
        public void ZipWhenFirstIsNullShouldThrowException()
        {
            ListCollection<int> firstTestList = null;

            ListCollection<int> secondTestList = new ListCollection<int>();

            secondTestList.Add(1);
            secondTestList.Add(2);
            secondTestList.Add(3);
            secondTestList.Add(4);
            secondTestList.Add(5);

            Assert.Throws<ArgumentNullException>(() => firstTestList.Zip(secondTestList, (first, second) => first + second));
        }

        [Fact]
        public void ZipWhenSecondIsNullShouldThrowException()
        {
            ListCollection<int> firstTestList = new ListCollection<int>();

            ListCollection<int> secondTestList = null;

            Assert.Throws<ArgumentNullException>(() => firstTestList.Zip(secondTestList, (first, second) => first + second));
        }

        [Fact]
        public void ZipWhenResultSelectorIsNullShouldThrowException()
        {
            ListCollection<int> firstTestList = new ListCollection<int>();

            firstTestList.Add(1);
            firstTestList.Add(2);
            firstTestList.Add(3);
            firstTestList.Add(4);

            ListCollection<int> secondTestList = new ListCollection<int>();

            secondTestList.Add(1);
            secondTestList.Add(2);
            secondTestList.Add(3);
            secondTestList.Add(4);
            secondTestList.Add(5);

            Func<int, int, int> resultSelector = null;

            Assert.Throws<ArgumentNullException>(() => firstTestList.Zip(secondTestList, resultSelector));
        }

        [Fact]
        public void AggregateWhenEmptyShouldReturnSeed()
        {
            ListCollection<int> testList = new ListCollection<int>();

            int seed = 0;

            int aggregatedResult = testList.Aggregate(seed, (total, next) => next % 2 == 0 ? total++ : total);

            Assert.Equal(aggregatedResult, seed);
        }

        [Fact]
        public void AggregateWhenNoEmptyShouldReturnProcessedValues()
        {
            ListCollection<int> testList = new ListCollection<int>();

            testList.Add(1);
            testList.Add(2);
            testList.Add(3);
            testList.Add(4);
            testList.Add(5);
            testList.Add(6);
            testList.Add(7);
            testList.Add(8);

            int numOfevenNumbers = 4;

            int aggregatedResult = testList.Aggregate(0, (total, next) => next % 2 == 0 ? total + 1 : total);

            Assert.Equal(aggregatedResult, numOfevenNumbers);
        }

        [Fact]
        public void AggregateWhenSourceIsNullShouldThrowException()
        {
            ListCollection<int> testList = null;

            Assert.Throws<ArgumentNullException>(() => testList.Aggregate(0, (total, next) => next % 2 == 0 ? total + 1 : total));
        }

        [Fact]
        public void AggregateWhenFuncIsNullShouldThrowException()
        {
            ListCollection<int> testList = new ListCollection<int>();

            testList.Add(1);
            testList.Add(2);
            testList.Add(3);
            testList.Add(4);
            testList.Add(5);
            testList.Add(6);
            testList.Add(7);
            testList.Add(8);

            Func<int, int, int> func = null;

            Assert.Throws<ArgumentNullException>(() => testList.Aggregate(0, func));
        }

        [Fact]
        public void JoinWhenAtLeastOneEmptySequenceShouldReturnEmptySequence()
        {
            ListCollection<string> outerTestList = new ListCollection<string>();

            ListCollection<string[]> innerTestList = new ListCollection<string[]>();

            IEnumerable<string> resultList =
                outerTestList.Join(innerTestList,
                    person => person,
                    pet => pet[1],
                    (person, pet) =>
                        person + " - " + pet[0]);

            Assert.Empty(resultList);
        }

        [Fact]
        public void JoinWhenNoEmptySequenceShouldReturnJoinedSequence()
        {
            ListCollection<string> outerTestList = new ListCollection<string>();

            outerTestList.Add("Hedlund, Magnus");
            outerTestList.Add("Adams, Terry");
            outerTestList.Add("Weiss, Charlotte");

            ListCollection<string[]> innerTestList = new ListCollection<string[]>();

            innerTestList.Add(new string[] { "Barley", "Adams, Terry" });
            innerTestList.Add(new string[] { "Boots", "Adams, Terry" });
            innerTestList.Add(new string[] { "Whiskers", "Weiss, Charlotte" });
            innerTestList.Add(new string[] { "Daisy", "Hedlund, Magnus" });

            IEnumerable<string> resultList =
                outerTestList.Join(innerTestList,
                    person => person,
                    pet => pet[1],
                    (person, pet) =>
                        person + " - " + pet[0]);

            Assert.Contains("Hedlund, Magnus - Daisy", resultList);
            Assert.Contains("Adams, Terry - Barley", resultList);
            Assert.Contains("Adams, Terry - Boots", resultList);
            Assert.Contains("Weiss, Charlotte - Whiskers", resultList);
            Assert.DoesNotContain("Weiss, Charlotte - Barley", resultList);
            Assert.DoesNotContain("Adams, Terry - Whiskers", resultList);
            Assert.DoesNotContain("Adams, Terry - Daisy", resultList);
            Assert.DoesNotContain("Hedlund, Magnus - Boots", resultList);
        }

        [Fact]
        public void JoinWhenNullOuterShouldThrowException()
        {
            ListCollection<string> outerTestList = null;

            ListCollection<string[]> innerTestList = new ListCollection<string[]>();

            innerTestList.Add(new string[] { "Barley", "Adams, Terry" });
            innerTestList.Add(new string[] { "Boots", "Adams, Terry" });
            innerTestList.Add(new string[] { "Whiskers", "Weiss, Charlotte" });
            innerTestList.Add(new string[] { "Daisy", "Hedlund, Magnus" });

            Assert.Throws<ArgumentNullException>(() =>
                outerTestList.Join(innerTestList,
                    person => person,
                    pet => pet[1],
                    (person, pet) =>
                        person + " - " + pet[0]));
        }

        [Fact]
        public void JoinWhenNullInnerShouldThrowException()
        {
            ListCollection<string> outerTestList = new ListCollection<string>();

            outerTestList.Add("Hedlund, Magnus");
            outerTestList.Add("Adams, Terry");
            outerTestList.Add("Weiss, Charlotte");

            ListCollection<string[]> innerTestList = null;

            Assert.Throws<ArgumentNullException>(() =>
                outerTestList.Join(innerTestList,
                    person => person,
                    pet => pet[1],
                    (person, pet) =>
                        person + " - " + pet[0]));
        }

        [Fact]
        public void JoinWhenNullOuterKeySelectorShouldThrowException()
        {
            ListCollection<string> outerTestList = new ListCollection<string>();

            outerTestList.Add("Hedlund, Magnus");
            outerTestList.Add("Adams, Terry");
            outerTestList.Add("Weiss, Charlotte");

            ListCollection<string[]> innerTestList = new ListCollection<string[]>();

            innerTestList.Add(new string[] { "Barley", "Adams, Terry" });
            innerTestList.Add(new string[] { "Boots", "Adams, Terry" });
            innerTestList.Add(new string[] { "Whiskers", "Weiss, Charlotte" });
            innerTestList.Add(new string[] { "Daisy", "Hedlund, Magnus" });

            Func<string, string> outerKeySelector = null;

            Assert.Throws<ArgumentNullException>(() =>
                outerTestList.Join(innerTestList,
                    outerKeySelector,
                    pet => pet[1],
                    (person, pet) =>
                        person + " - " + pet[0]));
        }

        [Fact]
        public void JoinWhenNullInnerKeySelectorShouldThrowException()
        {
            ListCollection<string> outerTestList = new ListCollection<string>();

            outerTestList.Add("Hedlund, Magnus");
            outerTestList.Add("Adams, Terry");
            outerTestList.Add("Weiss, Charlotte");

            ListCollection<string[]> innerTestList = new ListCollection<string[]>();

            innerTestList.Add(new string[] { "Barley", "Adams, Terry" });
            innerTestList.Add(new string[] { "Boots", "Adams, Terry" });
            innerTestList.Add(new string[] { "Whiskers", "Weiss, Charlotte" });
            innerTestList.Add(new string[] { "Daisy", "Hedlund, Magnus" });

            Func<string[], string> innerKeySelector = null;

            Assert.Throws<ArgumentNullException>(() =>
                outerTestList.Join(innerTestList,
                    person => person,
                    innerKeySelector,
                    (person, pet) =>
                        person + " - " + pet[0]));
        }

        [Fact]
        public void JoinWhenNullResultSelectorShouldThrowException()
        {
            ListCollection<string> outerTestList = new ListCollection<string>();

            outerTestList.Add("Hedlund, Magnus");
            outerTestList.Add("Adams, Terry");
            outerTestList.Add("Weiss, Charlotte");

            ListCollection<string[]> innerTestList = new ListCollection<string[]>();

            innerTestList.Add(new string[] { "Barley", "Adams, Terry" });
            innerTestList.Add(new string[] { "Boots", "Adams, Terry" });
            innerTestList.Add(new string[] { "Whiskers", "Weiss, Charlotte" });
            innerTestList.Add(new string[] { "Daisy", "Hedlund, Magnus" });

            Func<string, string[], string> resultSelector = null;

            Assert.Throws<ArgumentNullException>(() =>
                outerTestList.Join(innerTestList,
                    person => person,
                    pet => pet[1],
                    resultSelector));
        }

        [Fact]
        public void DistinctWhenEmptyShouldReturnEmptySequence()
        {
            ListCollection<int> testList = new ListCollection<int>();

            IEnumerable<int> resultList = testList.Distinct(EqualityComparer<int>.Default);

            Assert.Empty(resultList);
        }

        [Fact]
        public void DistinctWhenNoRepeatedElementsShouldReturnSameSequence()
        {
            ListCollection<int> testList = new ListCollection<int>();

            testList.Add(1);
            testList.Add(2);
            testList.Add(3);
            testList.Add(4);

            IEnumerable<int> resultList = testList.Distinct(EqualityComparer<int>.Default);

            Assert.Contains(1, resultList);
            Assert.Contains(2, resultList);
            Assert.Contains(3, resultList);
            Assert.Contains(4, resultList);
        }

        [Fact]
        public void DistinctWhenRepeatedElementsShouldReturnSequenceWithDistinctElements()
        {
            ListCollection<int> testList = new ListCollection<int>();

            testList.Add(1);
            testList.Add(2);
            testList.Add(3);
            testList.Add(2);

            IEnumerable<int> resultList = testList.Distinct(EqualityComparer<int>.Default);

            Assert.Collection(resultList, item => Assert.Equal(1, item),
                                            item => Assert.Equal(2, item),
                                            item => Assert.Equal(3, item));
        }

        [Fact]
        public void DistinctWhenComparerIsNullShouldUseDefaultComparer()
        {
            ListCollection<int> testList = new ListCollection<int>();

            testList.Add(1);
            testList.Add(2);
            testList.Add(3);
            testList.Add(2);

            IEnumerable<int> resultList = testList.Distinct(null);

            Assert.Collection(resultList, item => Assert.Equal(1, item),
                                            item => Assert.Equal(2, item),
                                            item => Assert.Equal(3, item));
        }

        [Fact]
        public void DistinctWhenSourceIsNullShouldThrowException()
        {
            ListCollection<int> testList = null;

            Assert.Throws<ArgumentNullException>(() =>
                testList.Distinct(EqualityComparer<int>.Default));
        }

        [Fact]
        public void UnionWhenTwoEmptySequencesShouldReturnEmptySequence()
        {
            ListCollection<int> firstTestList = new ListCollection<int>();

            ListCollection<int> secondTestList = new ListCollection<int>();

            IEnumerable<int> resultList = firstTestList.Union(
                secondTestList,
                EqualityComparer<int>.Default);

            Assert.Empty(resultList);
        }

        [Fact]
        public void UnionWhenOneEmptySequenceShouldReturnDistinctElementsOfNonEmptySequence()
        {
            ListCollection<int> firstTestList = new ListCollection<int>();

            firstTestList.Add(1);
            firstTestList.Add(2);
            firstTestList.Add(3);
            firstTestList.Add(4);

            ListCollection<int> secondTestList = new ListCollection<int>();

            IEnumerable<int> resultList = firstTestList.Union(
                secondTestList,
                EqualityComparer<int>.Default);

            Assert.Contains(1, resultList);
            Assert.Contains(2, resultList);
            Assert.Contains(3, resultList);
            Assert.Contains(4, resultList);
        }

        [Fact]
        public void UnionWhenNoEmptySequenceShouldReturnDistinctElementsOfBothSequences()
        {
            ListCollection<int> firstTestList = new ListCollection<int>();

            firstTestList.Add(1);
            firstTestList.Add(2);
            firstTestList.Add(3);
            firstTestList.Add(2);

            ListCollection<int> secondTestList = new ListCollection<int>();

            secondTestList.Add(5);
            secondTestList.Add(4);
            secondTestList.Add(5);
            secondTestList.Add(6);

            IEnumerable<int> resultList = firstTestList.Union(
                secondTestList,
                EqualityComparer<int>.Default);

            Assert.Collection(resultList, item => Assert.Equal(1, item),
                                            item => Assert.Equal(2, item),
                                            item => Assert.Equal(3, item),
                                            item => Assert.Equal(5, item),
                                            item => Assert.Equal(4, item),
                                            item => Assert.Equal(6, item));
        }

        [Fact]
        public void UnionWhenComparerIsNullShouldUseDefaultComparer()
        {
            ListCollection<int> firstTestList = new ListCollection<int>();

            firstTestList.Add(1);
            firstTestList.Add(2);
            firstTestList.Add(3);
            firstTestList.Add(2);

            ListCollection<int> secondTestList = new ListCollection<int>();

            secondTestList.Add(5);
            secondTestList.Add(4);
            secondTestList.Add(5);
            secondTestList.Add(6);

            IEnumerable<int> resultList = firstTestList.Union(
                secondTestList,
                null);

            Assert.Collection(resultList, item => Assert.Equal(1, item),
                                            item => Assert.Equal(2, item),
                                            item => Assert.Equal(3, item),
                                            item => Assert.Equal(5, item),
                                            item => Assert.Equal(4, item),
                                            item => Assert.Equal(6, item));
        }

        [Fact]
        public void UnionWhenFirstIsNullShouldThrowException()
        {
            ListCollection<int> firstTestList = null;

            ListCollection<int> secondTestList = new ListCollection<int>();

            secondTestList.Add(5);
            secondTestList.Add(4);
            secondTestList.Add(5);
            secondTestList.Add(6);

            Assert.Throws<ArgumentNullException>(() =>
                firstTestList.Union(
                secondTestList,
                EqualityComparer<int>.Default));
        }

        [Fact]
        public void UnionWhenSecondIsNullShouldThrowException()
        {
            ListCollection<int> firstTestList = new ListCollection<int>();

            firstTestList.Add(1);
            firstTestList.Add(2);
            firstTestList.Add(3);
            firstTestList.Add(2);

            ListCollection<int> secondTestList = null;

            Assert.Throws<ArgumentNullException>(() =>
                firstTestList.Union(
                secondTestList,
                EqualityComparer<int>.Default));
        }

        [Fact]
        public void IntersectWhenTwoEmptySequencesShouldReturnEmptySequence()
        {
            ListCollection<int> firstTestList = new ListCollection<int>();

            ListCollection<int> secondTestList = new ListCollection<int>();

            IEnumerable<int> resultList = firstTestList.Intersect(
                secondTestList,
                EqualityComparer<int>.Default);

            Assert.Empty(resultList);
        }

        [Fact]
        public void IntersectWhenNoMatchingElementsShouldReturnEmptySequence()
        {
            ListCollection<int> firstTestList = new ListCollection<int>();

            firstTestList.Add(1);
            firstTestList.Add(2);
            firstTestList.Add(3);

            ListCollection<int> secondTestList = new ListCollection<int>();

            secondTestList.Add(4);
            secondTestList.Add(5);
            secondTestList.Add(6);

            IEnumerable<int> resultList = firstTestList.Intersect(
                secondTestList,
                EqualityComparer<int>.Default);

            Assert.Empty(resultList);
        }

        [Fact]
        public void IntersectWhenMatchingElementsShouldReturnSequenceWithMatchingElements()
        {
            ListCollection<int> firstTestList = new ListCollection<int>();

            firstTestList.Add(3);
            firstTestList.Add(4);
            firstTestList.Add(5);

            ListCollection<int> secondTestList = new ListCollection<int>();

            secondTestList.Add(4);
            secondTestList.Add(5);
            secondTestList.Add(6);

            IEnumerable<int> resultList = firstTestList.Intersect(
                secondTestList,
                EqualityComparer<int>.Default);

            Assert.Collection(resultList, item => Assert.Equal(4, item),
                                            item => Assert.Equal(5, item));
        }

        [Fact]
        public void IntersectWhenNullComparerShouldUseDefaultComparer()
        {
            ListCollection<int> firstTestList = new ListCollection<int>();

            firstTestList.Add(3);
            firstTestList.Add(4);
            firstTestList.Add(5);

            ListCollection<int> secondTestList = new ListCollection<int>();

            secondTestList.Add(4);
            secondTestList.Add(5);
            secondTestList.Add(6);

            IEnumerable<int> resultList = firstTestList.Intersect(
                secondTestList,
                null);

            Assert.Collection(resultList, item => Assert.Equal(4, item),
                                            item => Assert.Equal(5, item));
        }

        [Fact]
        public void IntersectWhenNullFirstShouldThrowException()
        {
            ListCollection<int> firstTestList = null;

            ListCollection<int> secondTestList = new ListCollection<int>();

            secondTestList.Add(4);
            secondTestList.Add(5);
            secondTestList.Add(6);

            Assert.Throws<ArgumentNullException>(() =>
                firstTestList.Intersect(
                secondTestList,
                EqualityComparer<int>.Default));
        }

        [Fact]
        public void IntersectWhenNullSecondShouldThrowException()
        {
            ListCollection<int> firstTestList = new ListCollection<int>();

            firstTestList.Add(3);
            firstTestList.Add(4);
            firstTestList.Add(5);

            ListCollection<int> secondTestList = null;

            Assert.Throws<ArgumentNullException>(() =>
                firstTestList.Intersect(
                secondTestList,
                EqualityComparer<int>.Default));
        }

        [Fact]
        public void ExceptWhenTwoEmptySequencesShouldReturnEmptySequence()
        {
            ListCollection<int> firstTestList = new ListCollection<int>();

            ListCollection<int> secondTestList = new ListCollection<int>();

            IEnumerable<int> resultList = firstTestList.Except(
                secondTestList,
                EqualityComparer<int>.Default);

            Assert.Empty(resultList);
        }

        [Fact]
        public void ExceptWhenFirstEmptySequenceShouldReturnEmptySequence()
        {
            ListCollection<int> firstTestList = new ListCollection<int>();

            ListCollection<int> secondTestList = new ListCollection<int>();

            secondTestList.Add(4);
            secondTestList.Add(5);
            secondTestList.Add(6);

            IEnumerable<int> resultList = firstTestList.Except(
                secondTestList,
                EqualityComparer<int>.Default);

            Assert.Empty(resultList);
        }

        [Fact]
        public void ExceptWhenSecondEmptySequenceShouldReturnFirstSequenceWithoutDuplicates()
        {
            ListCollection<int> firstTestList = new ListCollection<int>();

            firstTestList.Add(1);
            firstTestList.Add(2);
            firstTestList.Add(3);
            firstTestList.Add(2);

            ListCollection<int> secondTestList = new ListCollection<int>();

            IEnumerable<int> resultList = firstTestList.Except(
                secondTestList,
                EqualityComparer<int>.Default);

            Assert.Collection(resultList, item => Assert.Equal(1, item),
                                            item => Assert.Equal(2, item),
                                            item => Assert.Equal(3, item));
        }

        [Fact]
        public void ExceptWhenNoEmptyShouldReturnFirstWithoutDuplicatesOrSecondElements()
        {
            ListCollection<int> firstTestList = new ListCollection<int>();

            firstTestList.Add(1);
            firstTestList.Add(2);
            firstTestList.Add(3);
            firstTestList.Add(2);

            ListCollection<int> secondTestList = new ListCollection<int>();

            secondTestList.Add(4);
            secondTestList.Add(5);
            secondTestList.Add(3);

            IEnumerable<int> resultList = firstTestList.Except(
                secondTestList,
                EqualityComparer<int>.Default);

            Assert.Collection(resultList, item => Assert.Equal(1, item),
                                            item => Assert.Equal(2, item));
        }

        [Fact]
        public void ExceptWhenNullComparerShouldUseDefaultComparer()
        {
            ListCollection<int> firstTestList = new ListCollection<int>();

            firstTestList.Add(1);
            firstTestList.Add(2);
            firstTestList.Add(3);
            firstTestList.Add(2);

            ListCollection<int> secondTestList = new ListCollection<int>();

            secondTestList.Add(4);
            secondTestList.Add(5);
            secondTestList.Add(3);

            IEnumerable<int> resultList = firstTestList.Except(
                secondTestList,
                null);

            Assert.Collection(resultList, item => Assert.Equal(1, item),
                                            item => Assert.Equal(2, item));
        }

        [Fact]
        public void ExceptWhenNullFirstShouldThrowException()
        {
            ListCollection<int> firstTestList = null;

            ListCollection<int> secondTestList = new ListCollection<int>();

            secondTestList.Add(4);
            secondTestList.Add(5);
            secondTestList.Add(3);

            Assert.Throws<ArgumentNullException>(() =>
                firstTestList.Except(
                secondTestList,
                EqualityComparer<int>.Default));
        }

        [Fact]
        public void ExceptWhenNullSecondShouldThrowException()
        {
            ListCollection<int> firstTestList = new ListCollection<int>();

            firstTestList.Add(1);
            firstTestList.Add(2);
            firstTestList.Add(3);
            firstTestList.Add(2);

            ListCollection<int> secondTestList = null;

            Assert.Throws<ArgumentNullException>(() =>
                firstTestList.Except(
                secondTestList,
                EqualityComparer<int>.Default));
        }

        [Fact]
        public void GroupByWhenEmptySequenceShouldReturnEmptySequence()
        {
            ListCollection<double> testList = new ListCollection<double>();

            IEnumerable<object> resultList = testList.GroupBy(
                num => Math.Floor(num),
                num => num,
                (key, numCollection) => new
                {
                    Key = key,
                    First = numCollection.First(num => Math.Floor(num) == key)
                },
                EqualityComparer<double>.Default);

            Assert.Empty(resultList);
        }

        [Fact]
        public void GroupByWhenNoEmptySequenceShouldReturnProcessedElements()
        {
            ListCollection<double> testList = new ListCollection<double>();

            testList.Add(6.6);
            testList.Add(1.7);
            testList.Add(8.5);
            testList.Add(0.5);
            testList.Add(1.4);
            testList.Add(8.8);

            IEnumerable<object> resultList = testList.GroupBy(
                num => Math.Floor(num),
                num => num,
                (key, numCollection) => new
                {
                    Key = key,
                    First = numCollection.First(x => Math.Floor(x) == key)
                },
                EqualityComparer<double>.Default);

            Assert.Collection(resultList,
                item => Assert.Equal(new
                {
                    Key = 6d,
                    First = 6.6
                }, item),
                item => Assert.Equal(new
                {
                    Key = 1d,
                    First = 1.7
                }, item),
                item => Assert.Equal(new
                {
                    Key = 8d,
                    First = 8.5
                }, item),
                item => Assert.Equal(new
                {
                    Key = 0d,
                    First = 0.5
                }, item));
        }

        [Fact]
        public void GroupByWhenNullComparerShouldUseDefaultComparer()
        {
            ListCollection<double> testList = new ListCollection<double>();

            testList.Add(6.6);
            testList.Add(1.7);
            testList.Add(8.5);
            testList.Add(0.5);
            testList.Add(1.4);
            testList.Add(8.8);

            IEnumerable<object> resultList = testList.GroupBy(
                num => Math.Floor(num),
                num => num,
                (key, numCollection) => new
                {
                    Key = key,
                    First = numCollection.First(x => Math.Floor(x) == key)
                },
                null);

            Assert.Collection(resultList,
                item => Assert.Equal(new
                {
                    Key = 6d,
                    First = 6.6
                }, item),
                item => Assert.Equal(new
                {
                    Key = 1d,
                    First = 1.7
                }, item),
                item => Assert.Equal(new
                {
                    Key = 8d,
                    First = 8.5
                }, item),
                item => Assert.Equal(new
                {
                    Key = 0d,
                    First = 0.5
                }, item));
        }

        [Fact]
        public void GroupByWhenNullSourceShouldThrowException()
        {
            ListCollection<double> testList = null;

            Assert.Throws<ArgumentNullException>(() =>
                testList.GroupBy(
                num => Math.Floor(num),
                num => num,
                (key, numCollection) => new
                {
                    Key = key,
                    First = numCollection.First(x => Math.Floor(x) == key)
                },
                EqualityComparer<double>.Default));
        }

        [Fact]
        public void GroupByWhenNullKeySelectorShouldThrowException()
        {
            ListCollection<double> testList = new ListCollection<double>();

            testList.Add(6.6);
            testList.Add(1.7);
            testList.Add(8.5);
            testList.Add(0.5);
            testList.Add(1.4);
            testList.Add(8.8);

            Assert.Throws<ArgumentNullException>(() =>
                testList.GroupBy(
                null,
                num => num,
                (key, numCollection) => new
                {
                    Key = key,
                    First = numCollection.First(x => Math.Floor(x) == key)
                },
                EqualityComparer<double>.Default));
        }

        [Fact]
        public void GroupByWhenNullElementSelectorShouldThrowException()
        {
            ListCollection<double> testList = new ListCollection<double>();

            testList.Add(6.6);
            testList.Add(1.7);
            testList.Add(8.5);
            testList.Add(0.5);
            testList.Add(1.4);
            testList.Add(8.8);

            Func<double, double> elementSelector = null;

            Assert.Throws<ArgumentNullException>(() =>
                testList.GroupBy(
                num => Math.Floor(num),
                elementSelector,
                (key, numCollection) => new
                {
                    Key = key,
                    First = numCollection.First(x => Math.Floor(x) == key)
                },
                EqualityComparer<double>.Default));
        }

        [Fact]
        public void GroupByWhenNullResultSelectorShouldThrowException()
        {
            ListCollection<double> testList = new ListCollection<double>();

            testList.Add(6.6);
            testList.Add(1.7);
            testList.Add(8.5);
            testList.Add(0.5);
            testList.Add(1.4);
            testList.Add(8.8);

            Func<double, IEnumerable<double>, object> resultSelector = null;

            Assert.Throws<ArgumentNullException>(() =>
                testList.GroupBy(
                num => Math.Floor(num),
                num => num,
                resultSelector,
                EqualityComparer<double>.Default));
        }

        [Fact]
        public void OrderByWhenEmptySequenceShouldReturnEmptySequence()
        {
            ListCollection<string> testList = new ListCollection<string>();

            OrderedEnumerable<string, int> resultList = testList.OrderBy(
                item => item.Length,
                Comparer<int>.Default);

            Assert.Empty(resultList);
        }

        [Fact]
        public void OrderByWhenElementsShouldReturnOrderedSequence()
        {
            string[] testArray = { "apricot", "orange", "banana", "mango" };

            OrderedEnumerable<string, int> orderedList = testArray.OrderBy(
                item => item.Length,
                Comparer<int>.Default);

            Assert.Collection(orderedList,
                item => Assert.Equal("mango", item),
                item => Assert.Equal("orange", item),
                item => Assert.Equal("banana", item),
                item => Assert.Equal("apricot", item));
        }

        [Fact]
        public void OrderByWhenRepeatedElementsShouldCreateStableOrderedSequence()
        {
            ListCollection<string[]> testList = new ListCollection<string[]>();

            testList.Add(new string[] { "apricot", "1" });
            testList.Add(new string[] { "orange", "1" });
            testList.Add(new string[] { "apricot", "2" });
            testList.Add(new string[] { "banana", "1" });
            testList.Add(new string[] { "mango", "1" });

            OrderedEnumerable<string[], int> orderedList = testList.OrderBy(
                fruit => fruit[0].Length,
                Comparer<int>.Default);

            Assert.Collection(orderedList,
                item => Assert.Equal(new string[] { "mango", "1" }, item),
                item => Assert.Equal(new string[] { "orange", "1" }, item),
                item => Assert.Equal(new string[] { "banana", "1" }, item),
                item => Assert.Equal(new string[] { "apricot", "1" }, item),
                item => Assert.Equal(new string[] { "apricot", "2" }, item));
        }

        [Fact]
        public void OrderByWhenNullComparerShouldUseDefaultComparer()
        {
            string[] testArray = { "apricot", "orange", "banana", "mango" };

            OrderedEnumerable<string, int> orderedList = testArray.OrderBy(
                item => item.Length,
                null);

            Assert.Collection(orderedList,
                item => Assert.Equal("mango", item),
                item => Assert.Equal("orange", item),
                item => Assert.Equal("banana", item),
                item => Assert.Equal("apricot", item));
        }
    }
}

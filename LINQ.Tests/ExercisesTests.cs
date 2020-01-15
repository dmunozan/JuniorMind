using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LINQ.Tests
{
    public class ExercisesTests
    {
        [Fact]
        public void NumberOfLettersWhenEmptyStringShouldReturn0ConsonantsAnd0Vowels()
        {
            Exercises testExercise = new Exercises();

            Assert.Equal((0, 0), testExercise.NumberOfLetters(""));
        }

        [Fact]
        public void NumberOfLettersWhenNoEmptyStringShouldReturnNumberOfConsonantsAndVowels()
        {
            Exercises testExercise = new Exercises();

            Assert.Equal((12, 5), testExercise.NumberOfLetters("This is a test string"));
        }

        [Fact]
        public void NumberOfLettersWhenOnlyConsonantsShouldReturnNumberOfConsonantsAnd0Vowels()
        {
            Exercises testExercise = new Exercises();

            Assert.Equal((12, 0), testExercise.NumberOfLetters("Ths s tst strng"));
        }

        [Fact]
        public void NumberOfLettersWhenOnlyVowelsShouldReturn0ConsonantsAndNumberOfVowels()
        {
            Exercises testExercise = new Exercises();

            Assert.Equal((0, 5), testExercise.NumberOfLetters("a, e, i, o, u!!!."));
        }

        [Fact]
        public void NumberOfLettersWhenNullStringShouldReturn0ConsonantsAnd0Vowels()
        {
            Exercises testExercise = new Exercises();

            Assert.Equal((0, 0), testExercise.NumberOfLetters(null));
        }

        [Fact]
        public void FirstNotRepeatedCharWhenEmptyStringShouldThrowException()
        {
            Exercises testExercise = new Exercises();

            Assert.Throws<InvalidOperationException>(() => testExercise.FirstNotRepeatedChar(""));
        }

        [Fact]
        public void FirstNotRepeatedCharWhenNotEmptyStringShouldReturnFirstNotRepeatedChar()
        {
            Exercises testExercise = new Exercises();

            Assert.Equal('h', testExercise.FirstNotRepeatedChar("This Is A Test String!"));
        }

        [Fact]
        public void FirstNotRepeatedCharWhenNullStringShouldThrowException()
        {
            Exercises testExercise = new Exercises();

            Assert.Throws<ArgumentNullException>(() => testExercise.FirstNotRepeatedChar(null));
        }

        [Fact]
        public void ConvertToIntWhenEmptyStringShouldThrowException()
        {
            Exercises testExercise = new Exercises();

            Assert.Throws<FormatException>(() => testExercise.ConvertToInt(""));
        }

        [Fact]
        public void ConvertToIntWhenValidCharsShouldReturnEquivalentNumber()
        {
            Exercises testExercise = new Exercises();

            Assert.Equal(1, testExercise.ConvertToInt("1"));
        }

        [Fact]
        public void ConvertToIntWhenValidNegativeSymbolShouldReturnEquivalentNumber()
        {
            Exercises testExercise = new Exercises();

            Assert.Equal(-1, testExercise.ConvertToInt("-1"));
        }

        [Fact]
        public void ConvertToIntWhenInvalidCharsShouldThrowException()
        {
            Exercises testExercise = new Exercises();

            Assert.Throws<FormatException>(() => testExercise.ConvertToInt("one"));
        }

        [Fact]
        public void ConvertToIntWhenInvalidNegativeSymbolShouldThrowException()
        {
            Exercises testExercise = new Exercises();

            Assert.Throws<FormatException>(() => testExercise.ConvertToInt("1-"));
        }

        [Fact]
        public void ConvertToIntWhenHigherThanIntShouldThrowException()
        {
            Exercises testExercise = new Exercises();

            Assert.Throws<OverflowException>(() => testExercise.ConvertToInt("2147483648"));
        }

        [Fact]
        public void ConvertToIntWhenLowerThanIntShouldThrowException()
        {
            Exercises testExercise = new Exercises();

            Assert.Throws<OverflowException>(() => testExercise.ConvertToInt("-2147483649"));
        }

        [Fact]
        public void ConvertToIntWhenNullShouldThrowException()
        {
            Exercises testExercise = new Exercises();

            Assert.Throws<ArgumentNullException>(() => testExercise.ConvertToInt(null));
        }

        [Fact]
        public void MostRepeatedCharWhenEmptyStringShouldThrowException()
        {
            Exercises testExercise = new Exercises();

            Assert.Throws<InvalidOperationException>(() => testExercise.MostRepeatedChar(""));
        }

        [Fact]
        public void MostRepeatedCharWhenNotEmptyStringShouldReturnMostRepeatedChar()
        {
            Exercises testExercise = new Exercises();

            Assert.Equal(' ', testExercise.MostRepeatedChar("This Is A Test String!"));
        }

        [Fact]
        public void MostRepeatedCharWhenNullStringShouldThrowException()
        {
            Exercises testExercise = new Exercises();

            Assert.Throws<ArgumentNullException>(() => testExercise.MostRepeatedChar(null));
        }

        [Fact]
        public void PalindromeGeneratorWhenEmptyStringShouldReturnEmptySequence()
        {
            Exercises testExercise = new Exercises();

            Assert.Empty(testExercise.PalindromeGenerator(""));
        }

        [Fact]
        public void PalindromeGeneratorWhenNotEmptyStringShouldReturnSequenceOfPalindromes()
        {
            Exercises testExercise = new Exercises();

            Assert.Collection(testExercise.PalindromeGenerator("aabaac"),
                item => Assert.Equal("a", item),
                item => Assert.Equal("a", item),
                item => Assert.Equal("b", item),
                item => Assert.Equal("a", item),
                item => Assert.Equal("a", item),
                item => Assert.Equal("c", item),
                item => Assert.Equal("aa", item),
                item => Assert.Equal("aa", item),
                item => Assert.Equal("aba", item),
                item => Assert.Equal("aabaa", item));
        }

        [Fact]
        public void PalindromeGeneratorWhenNullStringShouldThrowException()
        {
            Exercises testExercise = new Exercises();

            Assert.Throws<ArgumentNullException>(() => testExercise.PalindromeGenerator(null));
        }

        [Fact]
        public void SubarraysOfKWhenArrayIsEmptyShouldReturnEmptySequence()
        {
            Exercises testExercise = new Exercises();

            Assert.Empty(testExercise.SubarraysOfK(new int[] { }, 9));
        }

        [Fact]
        public void SubarraysOfKWhenArrayIsNotEmptyShouldReturnSubarraysOfKThatAddKOrLess()
        {
            Exercises testExercise = new Exercises();

            Assert.Collection(testExercise.SubarraysOfK(new int[] { 1, 2, 3 }, 5),
                item => Assert.Equal(new int[] { 1 }, item),
                item => Assert.Equal(new int[] { 2 }, item),
                item => Assert.Equal(new int[] { 3 }, item),
                item => Assert.Equal(new int[] { 1, 2 }, item),
                item => Assert.Equal(new int[] { 2, 3 }, item));
        }

        [Fact]
        public void SubarraysOfKWhenNullArrayShouldThrowException()
        {
            Exercises testExercise = new Exercises();

            Assert.Throws<ArgumentNullException>(() => testExercise.SubarraysOfK(null, 0));
        }

        [Fact]
        public void SummationOfNWhenNIsSmallerThan1ShouldThrowException()
        {
            Exercises testExercise = new Exercises();

            Assert.Throws<InvalidOperationException>(() => testExercise.SummationOfN(0, 0));
        }

        [Fact]
        public void SummationOfNWhenNIsHigherThan0ShouldReturnCombinationsOfNWhereSumEqualsK()
        {
            Exercises testExercise = new Exercises();

            Assert.Collection(testExercise.SummationOfN(3, 0),
                item => Assert.Equal(new int[] { -1, -2, 3 }, item),
                item => Assert.Equal(new int[] { 1, 2, -3 }, item));
        }

        [Fact]
        public void SummationOfNWhenNIsIsHigherThan30ShouldThrowException()
        {
            Exercises testExercise = new Exercises();

            Assert.Throws<OverflowException>(() => testExercise.SummationOfN(31, 0));
        }

        [Fact]
        public void PythagoreanCombinationsWhenArrayHasLessThan3ShouldThrowException()
        {
            Exercises testExercise = new Exercises();

            Assert.Throws<InvalidOperationException>(() => testExercise.PythagoreanCombinations(new[] { 0 }));
        }

        [Fact]
        public void PythagoreanCombinationsWhenArrayHasMoreThan2ShouldReturnPythagoreanCombinations()
        {
            Exercises testExercise = new Exercises();

            Assert.Collection(testExercise.PythagoreanCombinations(new[] { 4, 5, 3, 1, 2 }),
                item => Assert.Equal((4, 3, 5), item),
                item => Assert.Equal((3, 4, 5), item));
        }

        [Fact]
        public void PythagoreanCombinationsWhenNullArrayShouldThrowException()
        {
            Exercises testExercise = new Exercises();

            Assert.Throws<ArgumentNullException>(() => testExercise.PythagoreanCombinations(null));
        }

        [Fact]
        public void FilterProductsByFeaturesWhenNoProductsShouldReturnEmptySequence()
        {
            const uint OneOrMore = 0;

            Exercises testExercise = new Exercises();

            List<Product> productList = new List<Product>();

            List<Feature> featureList = new List<Feature>();

            Assert.Empty(testExercise.FilterProductsByFeatures(productList, featureList, OneOrMore));
        }

        [Fact]
        public void FilterProductsByFeaturesWhenProductsAndOneOrMoreShouldReturnProductsWithOneOrMoreFeaturesFromFeatureList()
        {
            const uint OneOrMore = 0;

            Exercises testExercise = new Exercises();

            Assert.Collection(testExercise.FilterProductsByFeatures(GetProductList(), GetFeatureList(), OneOrMore),
                item => Assert.Equal("P2", item.Name),
                item => Assert.Equal("P3", item.Name),
                item => Assert.Equal("P4", item.Name),
                item => Assert.Equal("P5", item.Name),
                item => Assert.Equal("P6", item.Name),
                item => Assert.Equal("P7", item.Name),
                item => Assert.Equal("P8", item.Name),
                item => Assert.Equal("P9", item.Name));
        }

        [Fact]
        public void FilterProductsByFeaturesWhenNoFeaturesAndOneOrMoreShouldReturnEmptySequence()
        {
            const uint OneOrMore = 0;

            Exercises testExercise = new Exercises();

            Assert.Empty(testExercise.FilterProductsByFeatures(GetProductList(), new List<Feature>(), OneOrMore));
        }

        [Fact]
        public void FilterProductsByFeaturesWhenProductsAndNoneShouldReturnProductsWithNoFeaturesFromFeatureList()
        {
            const uint None = 2;

            Exercises testExercise = new Exercises();

            Assert.Collection(testExercise.FilterProductsByFeatures(GetProductList(), GetFeatureList(), None),
                item => Assert.Equal("P1", item.Name));

            Assert.Collection(testExercise.FilterProductsByFeatures(GetProductList(), new List<Feature> { new Feature(5) }, None),
                item => Assert.Equal("P1", item.Name),
                item => Assert.Equal("P2", item.Name),
                item => Assert.Equal("P3", item.Name),
                item => Assert.Equal("P4", item.Name),
                item => Assert.Equal("P5", item.Name),
                item => Assert.Equal("P7", item.Name));
        }

        [Fact]
        public void FilterProductsByFeaturesWhenNoFeaturesAndNoneShouldReturnAllProducts()
        {
            const uint None = 2;

            Exercises testExercise = new Exercises();

            Assert.Collection(testExercise.FilterProductsByFeatures(GetProductList(), new List<Feature>(), None),
                item => Assert.Equal("P1", item.Name),
                item => Assert.Equal("P2", item.Name),
                item => Assert.Equal("P3", item.Name),
                item => Assert.Equal("P4", item.Name),
                item => Assert.Equal("P5", item.Name),
                item => Assert.Equal("P6", item.Name),
                item => Assert.Equal("P7", item.Name),
                item => Assert.Equal("P8", item.Name),
                item => Assert.Equal("P9", item.Name));
        }

        [Fact]
        public void FilterProductsByFeaturesWhenProductsAndAllShouldReturnProductsWithAllFeaturesFromFeatureList()
        {
            const uint All = 1;

            Exercises testExercise = new Exercises();

            Assert.Collection(testExercise.FilterProductsByFeatures(GetProductList(), GetFeatureList(), All),
                item => Assert.Equal("P9", item.Name));

            Assert.Collection(testExercise.FilterProductsByFeatures(GetProductList(), new List<Feature> { new Feature(4) }, All),
                item => Assert.Equal("P3", item.Name),
                item => Assert.Equal("P8", item.Name),
                item => Assert.Equal("P9", item.Name));
        }

        [Fact]
        public void FilterProductsByFeaturesWhenFlagIsHiggerThan2ShouldThrowException()
        {
            const uint WrongFilter = 3;

            Exercises testExercise = new Exercises();

            Assert.Throws<ArgumentOutOfRangeException>(() => testExercise.FilterProductsByFeatures(new List<Product>(), new List<Feature>(), WrongFilter));
        }

        [Fact]
        public void FilterProductsByFeaturesWhenNullProductListShouldThrowException()
        {
            const uint All = 1;

            Exercises testExercise = new Exercises();

            Assert.Throws<ArgumentNullException>(() => testExercise.FilterProductsByFeatures(null, new List<Feature>(), All));
        }

        [Fact]
        public void FilterProductsByFeaturesWhenNullFeatureListShouldThrowException()
        {
            const uint All = 1;

            Exercises testExercise = new Exercises();

            Assert.Throws<ArgumentNullException>(() => testExercise.FilterProductsByFeatures(GetProductList(), null, All));
        }

        [Fact]
        public void MergeProductListsWhenBothSequencesEmptyShouldReturnEmptySequence()
        {
            Exercises testExercise = new Exercises();

            Assert.Empty(testExercise.MergeProductLists(new List<Product>(), new List<Product>()));
        }

        [Fact]
        public void MergeProductListsWhenOneSequenceEmptyShouldReturnOtherSequence()
        {
            Exercises testExercise = new Exercises();

            Assert.Collection(testExercise.MergeProductLists(GetProductList(), new List<Product>()),
                item => Assert.Equal("P1", item.Name),
                item => Assert.Equal("P2", item.Name),
                item => Assert.Equal("P3", item.Name),
                item => Assert.Equal("P4", item.Name),
                item => Assert.Equal("P5", item.Name),
                item => Assert.Equal("P6", item.Name),
                item => Assert.Equal("P7", item.Name),
                item => Assert.Equal("P8", item.Name),
                item => Assert.Equal("P9", item.Name));
        }

        [Fact]
        public void MergeProductListsWhenTwoNoEmptySequencesShouldReturnAllUniqueProductsWithTotalQuantity()
        {
            Exercises testExercise = new Exercises();

            List<Product> firstProductList = new List<Product>();

            firstProductList.Add(new Product("P2", 2));
            firstProductList.Add(new Product("P3", 12));
            firstProductList.Add(new Product("P4", 7));
            firstProductList.Add(new Product("P5", 10));
            firstProductList.Add(new Product("P8", 12));

            List<Product> secondProductList = new List<Product>();

            secondProductList.Add(new Product("P3", 1));
            secondProductList.Add(new Product("P4", 5));
            secondProductList.Add(new Product("P5", 6));
            secondProductList.Add(new Product("P6", 4));
            secondProductList.Add(new Product("P8", 10));

            Assert.Collection(testExercise.MergeProductLists(firstProductList, secondProductList),
                item => Assert.Equal(new Product("P2", 2), item),
                item => Assert.Equal(new Product("P3", 13), item),
                item => Assert.Equal(new Product("P4", 12), item),
                item => Assert.Equal(new Product("P5", 16), item),
                item => Assert.Equal(new Product("P8", 22), item),
                item => Assert.Equal(new Product("P6", 4), item));
        }

        [Fact]
        public void MergeProductListsWhenNullSequenceShouldThrowException()
        {
            Exercises testExercise = new Exercises();

            Assert.Throws<ArgumentNullException>(() => testExercise.MergeProductLists(GetProductList(), null));
            Assert.Throws<ArgumentNullException>(() => testExercise.MergeProductLists(null, GetProductList()));
        }

        [Fact]
        public void GetMaxScoresWhenEmptySequenceShouldReturnEmptySequence()
        {
            Exercises testExercise = new Exercises();

            Assert.Empty(testExercise.GetMaxScores(new List<TestResults>()));
        }

        [Fact]
        public void GetMaxScoresWhenNoEmptySequenceShouldReturnMaxEntriesForEachFamilyId()
        {
            Exercises testExercise = new Exercises();

            List<TestResults> testResults = new List<TestResults>();

            testResults.Add(new TestResults("A", "Anderson", 12));
            testResults.Add(new TestResults("B", "Brown", 11));
            testResults.Add(new TestResults("C", "Clark", 53));
            testResults.Add(new TestResults("D", "Davis", 88));
            testResults.Add(new TestResults("E", "Evans", 18));
            testResults.Add(new TestResults("D", "Davis", 67));
            testResults.Add(new TestResults("F", "Foster", 39));
            testResults.Add(new TestResults("B", "Brown", 30));

            Assert.Collection(testExercise.GetMaxScores(testResults),
                item => Assert.Equal(new TestResults("A", "Anderson", 12), item),
                item => Assert.Equal(new TestResults("B", "Brown", 30), item),
                item => Assert.Equal(new TestResults("C", "Clark", 53), item),
                item => Assert.Equal(new TestResults("D", "Davis", 88), item),
                item => Assert.Equal(new TestResults("E", "Evans", 18), item),
                item => Assert.Equal(new TestResults("F", "Foster", 39), item));
        }

        private List<Product> GetProductList()
        {
            /*
             *              Features
             * P1 - None | P4 - 7    | P7 - 8, 9
             * P2 - 1    | P5 - 2, 3 | P8 - 4, 5, 6, 7
             * P3 - 4    | P6 - 5, 6 | P9 - 1, 2, 3, 4, 5, 6, 7, 8, 9
             */
            List<Product> productList = new List<Product>();
            List<Feature> featureList = new List<Feature>();

            productList.Add(new Product("P1", 1, featureList));

            featureList = new List<Feature> { new Feature(1) };
            productList.Add(new Product("P2", 1, featureList));

            featureList = new List<Feature> { new Feature(4) };
            productList.Add(new Product("P3", 1, featureList));

            featureList = new List<Feature> { new Feature(7) };
            productList.Add(new Product("P4", 1, featureList));

            featureList = new List<Feature>();
            featureList.AddRange(Enumerable.Range(2, 2).
                Select(i => new Feature(i)));
            productList.Add(new Product("P5", 1, featureList));

            featureList = new List<Feature>();
            featureList.AddRange(Enumerable.Range(5, 2).
                Select(i => new Feature(i)));
            productList.Add(new Product("P6", 1, featureList));

            featureList = new List<Feature>();
            featureList.AddRange(Enumerable.Range(8, 2).
                Select(i => new Feature(i)));
            productList.Add(new Product("P7", 1, featureList));

            featureList = new List<Feature>();
            featureList.AddRange(Enumerable.Range(4, 4).
                Select(i => new Feature(i)));
            productList.Add(new Product("P8", 1, featureList));

            productList.Add(new Product("P9", 1, GetFeatureList()));

            return productList;
        }

        private List<Feature> GetFeatureList()
        {
            List<Feature> featureList = new List<Feature>();

            featureList.AddRange(Enumerable.Range(1, 9).
                Select(i => new Feature(i)));

            return featureList;
        }
    }
}

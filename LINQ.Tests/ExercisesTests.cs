﻿using System;
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
            const int OneOrMore = 0;

            Exercises testExercise = new Exercises();

            List<Product> productList = new List<Product>();

            List<Feature> featureList = new List<Feature>();

            Assert.Empty(testExercise.FilterProductsByFeatures(productList, featureList, OneOrMore));
        }

        [Fact]
        public void FilterProductsByFeaturesWhenProductsAndOneOrMoreShouldReturnProductsWithOneOrMoreFeaturesFromFeatureList()
        {
            const int OneOrMore = 0;

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
            const int OneOrMore = 0;

            Exercises testExercise = new Exercises();

            Assert.Empty(testExercise.FilterProductsByFeatures(GetProductList(), new List<Feature>(), OneOrMore));
        }

        [Fact]
        public void FilterProductsByFeaturesWhenProductsAndNoneShouldReturnProductsWithNoFeaturesFromFeatureList()
        {
            const int None = 2;

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

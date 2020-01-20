using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public class Exercises
    {
        enum FilterOptions : uint
        {
            OneOrMore,
            All,
            None
        }

        public (int consonants, int vowels) NumberOfLetters(string text)
        {
            var letterCount = (consonants: 0, vowels: 0);

            if (string.IsNullOrEmpty(text))
            {
                return letterCount;
            }

            const string vowels = "aeiou";
            const string punctuation = ".?! ;:,";

            var groupsOfLetters =
                text.ToLowerInvariant().Where(c => !punctuation.Contains(c)).
                GroupBy(c => vowels.Contains(c), (key, chars) => new { Key = key, Count = chars.Count() });

            letterCount.vowels = groupsOfLetters.FirstOrDefault(g => g.Key)?.Count ?? 0;
            letterCount.consonants = groupsOfLetters.FirstOrDefault(g => !g.Key)?.Count ?? 0;

            return letterCount;
        }

        public char FirstNotRepeatedChar(string text)
        {
            return text.GroupBy(c => c, (key, chars) => new { Key = key, Count = chars.Count() }).First(g => g.Count == 1).Key;
        }

        public int ConvertToInt(string text)
        {
            NullCheck(text);

            const int Ten = 10;
            int sign = 1;
            string digits = text;

            if (text.FirstOrDefault() == '-')
            {
                sign = -1;
                digits = text.Substring(1);
            }

            if (digits == "" || digits.Any(c => !char.IsDigit(c)))
            {
                throw new FormatException("Argument is not in the correct format");
            }

            return digits.Aggregate(0, (total, next) => total * Ten + (next - '0')) * sign;
        }

        public char MostRepeatedChar(string text)
        {
            return text.GroupBy(c => c, (key, chars) => new { Key = key, Count = chars.Count() }).
                OrderByDescending(g => g.Count).First().Key;
        }

        public IEnumerable<string> PalindromeGenerator(string text)
        {
            NullCheck(text);

            return Enumerable.Range(0, text.Length).
                SelectMany(
                    i => Enumerable.Range(0, text.Length - i + 1),
                    (i, j) => (i, j)).
                Where(p => p.j >= 1).
                Select(p => text.Substring(p.i, p.j)).
                Where(s => s.SequenceEqual(s.Reverse())).
                OrderBy(s => s.Length);
        }

        public IEnumerable<int[]> SubarraysOfK(int[] array, int k)
        {
            NullCheck(array);

            return Enumerable.Range(0, array.Length).
                SelectMany(
                    i => Enumerable.Range(0, array.Length - i + 1),
                    (i, j) => (i, j)).
                Where(p => p.j >= 1).
                Select(p => array.Skip(p.i).Take(p.j).ToArray()).
                Where(a => a.Sum() <= k).
                OrderBy(a => a.Length);
        }

        public IEnumerable<int[]> SummationOfN(int n, int k)
        {
            if (n < 1)
            {
                throw new InvalidOperationException("N must be higher than 0");
            }

            int[] baseValues = { -1, 1 };
            int numOfRows = (int)Math.Pow(2, n);
            const int Two = 2;

            return Enumerable.Range(0, numOfRows).
                 Select(
                     i => Enumerable.Range(1, n).
                            Select(
                                j => baseValues[i / (numOfRows / (Two * j)) % Two] * j)).
                 Where(s => s.Sum() == k).
                 Select(s => s.ToArray());
        }

        public IEnumerable<(int, int, int)> PythagoreanCombinations(int[] numArray)
        {
            const int minLenght = 3;

            NullCheck(numArray);

            if (numArray.Length < minLenght)
            {
                throw new InvalidOperationException("There must be at least three numbers in the array");
            }

            return Enumerable.Range(0, numArray.Length).
                SelectMany(
                    i => Enumerable.Range(0, numArray.Length),
                    (i, j) => (i, j)).
                SelectMany(
                    p => Enumerable.Range(0, numArray.Length),
                    (p, k) => (p.i, p.j, k)).
                Where(t => t.i != t.j && t.i != t.k && t.j != t.k).
                Select(t => (numArray[t.i], numArray[t.j], numArray[t.k])).
                Where(t => t.Item1 * t.Item1 + t.Item2 * t.Item2 ==
                    t.Item3 * t.Item3);
        }

        public IEnumerable<Product> FilterProductsByFeatures(
            ICollection<Product> products,
            ICollection<Feature> features,
            uint filterMode)
        {
            NullCheck(features);

            if (filterMode > (uint)FilterOptions.None)
            {
                throw new ArgumentOutOfRangeException(nameof(filterMode), "Argument out of allowed range.");
            }

            if (filterMode == (uint)FilterOptions.OneOrMore)
            {
                return products.
                Where(p => features.Select(listf => listf.Id).
                    Intersect(p.Features.Select(prodf => prodf.Id)).Any());
            }
            else if (filterMode == (uint)FilterOptions.All)
            {
                return products.
                Where(p => !features.Select(listf => listf.Id).
                    Except(p.Features.Select(prodf => prodf.Id)).Any());
            }

            return products.
                Where(p => !features.Select(listf => listf.Id).
                    Intersect(p.Features.Select(prodf => prodf.Id)).Any());
        }

        public IEnumerable<Product> MergeProductLists(
            IEnumerable<Product> firstList,
            IEnumerable<Product> secondList)
        {
            return firstList.
                Concat(secondList).
                GroupBy(
                    p => p.Name,
                    p => p.Quantity,
                    (name, quantities) =>
                        new Product(name, quantities.Sum()));
        }

        public IEnumerable<TestResults> GetMaxScores(IEnumerable<TestResults> testResults)
        {
            return testResults.
                GroupBy(
                    r => r.FamilyId,
                    r => r,
                    (familyId, results) =>
                    new TestResults(
                        results.First().Id,
                        familyId,
                        results.Select(res => res.Score).Max()));
        }

        public string MostRepeatedWord(string text)
        {
            NullCheck(text);

            string[] words = text.Split(new[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);

            return words.
                GroupBy(
                    w => w.ToLowerInvariant(),
                    (word, ocurrences) =>
                        new { Word = word, Count = ocurrences.Count() }).
                OrderByDescending(g => g.Count).
                First().Word;
        }

        public bool SudokuChecker(int[,] board)
        {
            const int Three = 3;
            const int Nine = 9;
            const int FullBoard = 81;

            NullCheck(board);

            if (board.Length == FullBoard)
            {
                return Enumerable.Range(0, Nine).
                    Select(i => Enumerable.Range(1, Nine).
                        Except(Enumerable.Range(0, Nine).
                            Select(j => board[i, j])).Count()).
                    Concat(Enumerable.Range(0, Nine).
                    Select(i => Enumerable.Range(1, Nine).
                        Except(Enumerable.Range(0, Nine).
                            Select(j => board[j, i])).Count())).
                    Concat(Enumerable.Range(0, Nine).
                    Select(i => Enumerable.Range(1, Nine).
                        Except(Enumerable.Range(0, Nine).
                            Select(j => board[(i / Three) * Three + (j / Three), (i % Three) * Three + (j % Three)])).Count())).
                            All(num => num == 0);
            }

            throw new InvalidOperationException("The array must contain 81 elements.");
        }

        private void NullCheck(object obj)
        {
            if (obj != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(obj), "Argument can not be null");
        }
    }
}

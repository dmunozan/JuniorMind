using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public class Exercises
    {
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
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text), "Argument can not be null");
            }

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
            Console.WriteLine(text);

            return new string[] { };
        }
    }
}

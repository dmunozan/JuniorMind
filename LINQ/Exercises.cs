using System;
using System.Linq;

namespace LINQ
{
    public class Exercises
    {
        public int NumberOfVowels(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return 0;
            }

            return text.Split("aeiou".ToCharArray()).Length - 1;
        }

        public int NumberOfConsonants(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return 0;
            }

            return text.Split(" .?!".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(w => w.Length).Sum() - NumberOfVowels(text);
        }

        public (int consonants, int vowels) NumberOfLetters(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return (0, 0);
            }

            const string vowels = "aeiou";

            int[] numOfLetters =
                string.Concat(text.ToLowerInvariant().Split(".?! ;:,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)).
                GroupBy(c => vowels.Contains(c), (key, chars) => chars.Count()).ToArray();

            return (numOfLetters[0], numOfLetters[1]);
        }
    }
}

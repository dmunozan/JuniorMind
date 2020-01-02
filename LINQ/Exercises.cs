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
            text ??= "";

            return (text.Length, text.Length);
        }
    }
}

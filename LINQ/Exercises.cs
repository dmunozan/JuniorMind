using System;
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

            var groupsOfLetters =
                string.Concat(text.ToLowerInvariant().Split(".?! ;:,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)).
                GroupBy(c => vowels.Contains(c), (key, chars) => new { Key = key, Count = chars.Count() });

            foreach (var group in groupsOfLetters)
            {
                if (group.Key)
                {
                    letterCount.vowels = group.Count;
                }
                else
                {
                    letterCount.consonants = group.Count;
                }
            }

            return letterCount;
        }
    }
}

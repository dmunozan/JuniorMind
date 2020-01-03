﻿using System;
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
            if (text == "")
            {
                throw new FormatException("Argument is not in the correct format");
            }

            const int Ten = 10;

            int sign = (text.First() == '-') ? -1 : 1;

            return text.Where(c => char.IsDigit(c)).Aggregate(0, (total, next) => total * Ten + (next - '0')) * sign;
        }
    }
}

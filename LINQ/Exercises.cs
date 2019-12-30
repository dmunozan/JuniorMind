using System;

namespace LINQ
{
    public class Exercises
    {
        public int NumberOfVocals(string text)
        {
            return text.Count(
                c =>
                {
                    var isA = c == 'a' || c == 'A';
                    var isE = isA || c == 'e' || c == 'E';
                    var isI = isE || c == 'i' || c == 'I';
                    var isO = isI || c == 'o' || c == 'O';
                    return isO || c == 'u' || c == 'U';
                });
        }

        public int NumberOfConsonants(string text)
        {
            Console.WriteLine(text);

            return 0;
        }
    }
}

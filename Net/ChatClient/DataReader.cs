using System;

namespace ChatClient
{
    public class DataReader : IReader
    {
        public string Read(string textToShow)
        {
            Console.WriteLine(textToShow);
            return Console.ReadLine();
        }
    }
}

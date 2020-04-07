using System;

namespace ChatClient
{
    public class DataReader : IReader
    {
        public string Read(string textToShow)
        {
            Console.Write(textToShow);
            return Console.ReadLine();
        }
    }
}

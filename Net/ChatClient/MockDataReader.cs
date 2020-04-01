using System.Collections.Generic;

namespace ChatClient
{
    public class MockDataReader : IReader
    {
        public List<string> ListToRead = new List<string>();
        private int index;

        public string Read(string textToShow)
        {
            return ListToRead[index++];
        }
    }
}

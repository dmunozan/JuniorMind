namespace ChatClient
{
    public class MockDataReader : IReader
    {
        public string TextToRead { get; set; }

        public string Read(string textToShow)
        {
            return TextToRead;
        }
    }
}

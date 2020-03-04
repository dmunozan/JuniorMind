namespace Common
{
    public interface ISocket
    {
        public string Receive();

        public void Send(string data);
    }
}

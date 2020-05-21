using System.Net;

namespace DNSClient
{
    public class DNSClientSide
    {
        public string GetIP(string hostName)
        {
            string ip = null;

            foreach (var address in Dns.GetHostAddresses(hostName))
            {
                ip = address.ToString();

                if (ip != null)
                {
                    break;
                }
            }

            return ip;
        }
    }
}

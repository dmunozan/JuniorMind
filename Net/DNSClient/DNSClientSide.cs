using System.Linq;
using System.Net;

namespace DNSClient
{
    public class DNSClientSide
    {
        public string GetIP(string hostName)
        {
            return Dns.GetHostAddresses(hostName).SkipWhile(o => o == null).First().ToString();
        }
    }
}

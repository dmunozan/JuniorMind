using System.Net;
using Xunit;

namespace DNSClient.Tests
{
    public class DNSClientSideTests
    {
        [Fact]
        public void GetIPWhenValidHostShouldReturnFirstValidAddressFromAdressList()
        {
            DNSClientSide dnsClient = new DNSClientSide();

            string hostIP = dnsClient.GetIP("www.google.com");

            Assert.True(IPAddress.TryParse(hostIP, out IPAddress address));
        }
    }
}

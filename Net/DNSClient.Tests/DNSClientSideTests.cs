using System.Net;
using Xunit;

namespace DNSClient.Tests
{
    public class DNSClientSideTests
    {
        [Fact]
        public void GetIPWhenEmptyStringShouldReturnFirstValidAddressFromHostRunningClient()
        {
            DNSClientSide dnsClient = new DNSClientSide();

            string hostIP = dnsClient.GetIP("");

            Assert.True(IPAddress.TryParse(hostIP, out IPAddress address));
            Assert.Contains<IPAddress>(address, Dns.GetHostAddresses(Dns.GetHostName()));
        }

        [Fact]
        public void GetIPWhenValidHostShouldReturnFirstValidAddressFromAdressList()
        {
            DNSClientSide dnsClient = new DNSClientSide();

            string hostIP = dnsClient.GetIP("www.google.com");

            Assert.True(IPAddress.TryParse(hostIP, out IPAddress address));
        }
    }
}

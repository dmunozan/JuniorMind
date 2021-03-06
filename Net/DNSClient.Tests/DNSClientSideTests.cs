using System;
using System.Net;
using System.Net.Sockets;
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
        public void GetIPWhenHostIsInvalidIPShouldThrowException()
        {
            DNSClientSide dnsClient = new DNSClientSide();

            Assert.Throws<ArgumentException>(() => dnsClient.GetIP("0.0.0.0"));
        }

        [Fact]
        public void GetIPWhenHostIsIPShouldReturnSameIP()
        {
            DNSClientSide dnsClient = new DNSClientSide();

            string hostIP = dnsClient.GetIP("78.96.7.88");

            Assert.True(IPAddress.TryParse(hostIP, out IPAddress address));
            Assert.Equal("78.96.7.88", hostIP);
        }

        [Fact]
        public void GetIPWhenHostLengthIsGreaterThan255CharactersShouldThrowException()
        {
            DNSClientSide dnsClient = new DNSClientSide();

            string hostName = "www.t";

            for (int i = 0; i < 255; i++)
            {
                hostName += "o"; 
            }

            hostName += ".long";

            Assert.Throws<ArgumentOutOfRangeException>(() => dnsClient.GetIP(hostName));
        }

        [Fact]
        public void GetIPWhenNotResolvingHostShouldThrowException()
        {
            DNSClientSide dnsClient = new DNSClientSide();

            Assert.Throws<SocketException>(() => dnsClient.GetIP("invalidIPaddress"));
        }

        [Fact]
        public void GetIPWhenNullStringShouldThrowException()
        {
            DNSClientSide dnsClient = new DNSClientSide();

            Assert.Throws<ArgumentNullException>(() => dnsClient.GetIP(null));
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

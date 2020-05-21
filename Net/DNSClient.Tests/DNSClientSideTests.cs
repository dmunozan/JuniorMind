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

            string[] ipOctets = hostIP.Split('.');

            Assert.Equal(4, ipOctets.Length);

            bool validIP = true;

            foreach (var octet in ipOctets)
            {
                validIP = byte.TryParse(octet, out byte result);

                if (!validIP)
                {
                    break;
                }
            }

            Assert.True(validIP);
        }
    }
}

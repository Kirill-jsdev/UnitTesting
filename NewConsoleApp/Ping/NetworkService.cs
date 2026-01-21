using NetworkUtility.DNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Ping
{
    public class NetworkService
    {
        private readonly IDNS _dns;

        public NetworkService(IDNS dns) 
        {
            _dns = dns;
        
        }

        public string SendPing()
        {
            var dnsSuccess = _dns.SendDNS();

            if (!dnsSuccess)
            {
                return "FAILURE: DNS failed";
            }  else
            {
                return "SUCCESS: Ping sent";
            }

        }

        public int PingTimeout(int a, int b)
        {
            return a + b;
        }

        public DateTime LastPingDate()
        {
            return DateTime.Now;
        }

        public PingOptions GetPingOptions()
        {
            return new PingOptions
            {
                DontFragment = true,
                Ttl = 128
            };
        }

        public IEnumerable<PingOptions> MostRecentPings()
        {
            return new List<PingOptions>
            {
                new PingOptions
                {
                    DontFragment = true,
                    Ttl = 128
                },
                new PingOptions
                {
                    DontFragment = false,
                    Ttl = 64
                }
            };
        }
    }
}

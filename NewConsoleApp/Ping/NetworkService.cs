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
        public string SendPing()
        {
            return "SUCCESS: Ping sent";
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

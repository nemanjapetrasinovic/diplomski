using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace diplomski.Models
{
    public class WiFiConnection
    {
        public String WiFiNetworkName { get; set; }
        public String HostMacAddress { get; set; }
        public String ClientMacAddress { get; set; }
    }
}
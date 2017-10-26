using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using diplomski.Models;

namespace diplomski.Models
{
    public class Laptop:Computer
    {
        public String WifiMacAddress { get; set; }
        public String WiFiNetworkName { get; set; }
    }
}
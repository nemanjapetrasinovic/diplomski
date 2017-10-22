using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using diplomski.Models;

namespace diplomski.Models
{
    public class Router:Node
    {
        public String OS { get; set; }
        public String WiFiNetworkName { get; set; }
    }
}
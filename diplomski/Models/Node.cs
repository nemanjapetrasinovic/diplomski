using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace diplomski.Models
{
    public abstract class Node
    {
        public String name { get; set; }
        public String SerialNumber { get; set; }
        public String Manufacturer { get; set; }
        public int NumberOfPorts { get; set; }
        public int NumberOfTakenPorts { get; set; }
        public List<String> MacAddressList { get; set; }
    }
}
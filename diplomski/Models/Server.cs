using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using diplomski.Models;

namespace diplomski.Models
{
    public class Server:Computer
    {
        public String LanMacAddress { get; set; }
        public String Type { get; set; }
        public String Description { get; set; }
    }
}
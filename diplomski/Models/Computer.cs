using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace diplomski.Models
{
    public class Computer
    {
        public String name { get; set; }
        public String OS { get; set; }
        public String LanMacAddress { get; set; }
        public String Owner { get; set; }
        public String PhoneNumber { get; set; }
        public String Email { get; set; }
        public String Comment { get; set; }
        public String Model { get; set; }
        public String Configuration { get; set; }
    }
}
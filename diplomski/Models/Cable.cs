using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace diplomski.Models
{
    public abstract class Cable
    {
        public String Manufacturer { get; set; }
        public String Type { get; set; }
        public String End1 { get; set; }
        public String End2 { get; set; }
    }
}
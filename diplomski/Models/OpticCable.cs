using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using diplomski.Models;

namespace diplomski.Models
{
    public class OpticCable:Cable
    {
        public String Material { get; set; }
        public String Mode { get; set; }
    }
}
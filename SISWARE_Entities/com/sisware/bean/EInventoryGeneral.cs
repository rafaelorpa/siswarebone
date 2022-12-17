using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.sisware.bean
{
    public class EInventoryGeneral
    {
        public int ca_code { get; set; }
        public string ca_description { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string unid { get; set; }
        public DateTime date { get; set; }
        public double ufv { get; set; }
        public double balance_init { get; set; }
        public double bsUnitPrice { get; set; }
        public double balance { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.sisware.bean
{
    public class EKardex
    {
        public DateTime date { get; set; }
        public string hour { get; set; }
        public double exchange { get; set; }
        public string detail { get; set; }
        public int lote { get; set; }
        public double quantity_input { get; set; }
        public double bsUnitPrice_input { get; set; }
        public double quantity_output { get; set; }
        public double bsUnitPrice_output { get; set; }
        public double quantity_saldo { get; set; }
        public double bsUnitPrice_saldo { get; set; }
        public string numberInput { get; set; }
        public string numberOutput { get; set; }
    }
}

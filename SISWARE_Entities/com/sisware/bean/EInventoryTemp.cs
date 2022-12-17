using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.sisware.bean
{
    public class EInventoryTemp
    {
        public int code { get; set; }
        public int lot { get; set; }
        public double quantity { get; set; }
        public double ufvUnitPrice { get; set; }
        public double ufvTotalPrice { get; set; }
        public double bsUnitPrice { get; set; }
        public double bsTotalPrice { get; set; }
        public string description { get; set; }
        public double residue { get; set; }
        public int userCode { get; set; }
        public int articleCode { get; set; }
        public int inputCode { get; set; }
        public int providerCode { get; set; }
        public int inputBill { get; set; }
        public DateTime date { get; set; }

        public string toString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append(",code=").Append(code);
            sb.Append(",lot=").Append(lot);
            sb.Append(",quantity=").Append(quantity);
            sb.Append(",ufvUnitPrice=").Append(ufvUnitPrice);
            sb.Append(",ufvTotalPrice=").Append(ufvTotalPrice);
            sb.Append(",bsUnitPrice=").Append(bsUnitPrice);
            sb.Append(",bsTotalPrice=").Append(bsTotalPrice);
            sb.Append(",description=").Append(description);
            sb.Append(",residue=").Append(residue);
            sb.Append(",userCode=").Append(userCode);
            sb.Append(",articleCode=").Append(articleCode);
            sb.Append(",inputCode=").Append(inputCode);
            sb.Append(",providerCode=").Append(articleCode);
            sb.Append(",inputBill=").Append(inputCode);
            sb.Append(",date=").Append(date);
            sb.Append("}");
            return sb.ToString();
        }
    }
}

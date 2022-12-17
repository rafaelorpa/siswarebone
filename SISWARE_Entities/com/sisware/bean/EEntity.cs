using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.sisware.bean
{
    public class EEntity
    {
        public int code { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string representative { get; set; }
        public string place { get; set; }
        public string zone { get; set; }

        public string phone { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
        public string web { get; set; }
        public byte[] logo { get; set; }

        public string toString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append(",code=").Append(code);
            sb.Append(",name=").Append(name);
            sb.Append(",address=").Append(address);
            sb.Append(",representative=").Append(representative);
            sb.Append(",place=").Append(place);
            sb.Append(",zone=").Append(zone);
            sb.Append(",phone=").Append(phone);
            sb.Append(",email=").Append(email);
            sb.Append(",web=").Append(web);
            sb.Append(",logo=").Append(logo.ToString());
            sb.Append("}");
            return sb.ToString();
        }
    }
}

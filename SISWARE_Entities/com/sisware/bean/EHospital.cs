using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.sisware.bean
{
    internal class EHospital
    {
        public int id { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public string condition { get; set; }
        public string phone { get; set; }
        public DateTime date { get; set; }

        public string toString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append(",id=").Append(id); 
            sb.Append(",name=").Append(name);
            sb.Append(",city=").Append(city);
            sb.Append(",address=").Append(address);
            sb.Append(",phone").Append(phone);
            sb.Append(",date=").Append(date.ToString());
            sb.Append("}");
            return sb.ToString();
        }
    }
}

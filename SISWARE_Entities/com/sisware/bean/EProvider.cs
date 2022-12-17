using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.sisware.bean
{
    public class EProvider
    {
        public int id { get; set; }
        public string nit { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string address { get; set; }
        public string telephone { get; set; }   
        public string city { get; set; }
        public string country { get; set; }
        public string contactName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public DateTime date { get; set; }

        public string toString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append(",id=").Append(id);
            sb.Append(",nit=").Append(nit);
            sb.Append(",name=").Append(name);
            sb.Append(",category=").Append(category);
            sb.Append(",address=").Append(address);
            sb.Append(",telephone=").Append(telephone);
            sb.Append(",city=").Append(city);
            sb.Append(",country=").Append(country);
            sb.Append(",contactName=").Append(contactName);
            sb.Append(",phone=").Append(phone);
            sb.Append(",email=").Append(email);
            sb.Append(",date=").Append(date.ToString());
            sb.Append("}");
            return sb.ToString();
        }
    }
}

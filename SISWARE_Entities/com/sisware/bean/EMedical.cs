using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.sisware.bean
{
    public class EMedical
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname   { get; set; }
        public string speciality { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public string cell { get; set; }
        public string email { get; set; }
        public DateTime date { get; set; }

        public string toString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append(",id=").Append(id);
            sb.Append(",name=").Append(name);
            sb.Append(",surname=").Append(surname);
            sb.Append(",speciality=").Append(speciality);
            sb.Append(",city=").Append(city);
            sb.Append(",address=").Append(address);
            sb.Append(",cell=").Append(cell);
            sb.Append(",email=").Append(email);
            sb.Append(",date=").Append(date.ToString());
            sb.Append("}");
            return sb.ToString();
        }
    }
}

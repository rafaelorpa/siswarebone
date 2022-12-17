using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.sisware.bean
{
    public class EUser
    {
        public int id { get; set; }
        public string ci { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string names { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public string trace { get; set; }
        public DateTime date { get; set; }
        public string role { get; set; }

        public string toString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append(",id=").Append(id);
            sb.Append(",ci=").Append(ci);
            sb.Append(",firstName=").Append(firstName);
            sb.Append(",lastName=").Append(lastName);
            sb.Append(",names=").Append(names);
            sb.Append(",password=").Append(password);
            sb.Append(",trace=").Append(trace);
            sb.Append(",date=").Append(date.ToString());
            sb.Append(",role").Append(role);
            sb.Append("}");
            return sb.ToString();
        }
    }
}

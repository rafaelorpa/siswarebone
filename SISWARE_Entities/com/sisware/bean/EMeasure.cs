using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.sisware.bean
{
    public class EMeasure
    {
        public int id { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }
        
        public string toString()
        {
            StringBuilder sb =new StringBuilder();
            sb.Append("{");
            sb.Append(",id=").Append(id);
            sb.Append(",description=").Append(description);
            sb.Append("'date=").Append(date.ToString());
            sb.Append("}");
            return sb.ToString();
        }
    }
}

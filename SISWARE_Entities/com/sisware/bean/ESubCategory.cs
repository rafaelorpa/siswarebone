using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.sisware.bean
{
    public class ESubCategory
    {
        public int id { get; set; }
        public string name { get; set; }
        public int categoryId { get; set; }
        public DateTime date { get; set; }

        public string toString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append(",id=").Append(id);
            sb.Append(",name=").Append(name);
            sb.Append(",categoryId=").Append(categoryId);
            sb.Append(",date=").Append(date.ToString());
            sb.Append("}");
            return sb.ToString();
        }
    }
}

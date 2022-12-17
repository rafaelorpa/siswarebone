using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.sisware.bean
{
    public class ERole
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public string name { get; set; }
        public string toString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append(",id=").Append(id);
            sb.Append(",descripcion=").Append(descripcion);
            sb.Append(",name=").Append(name);
            sb.Append("}");
            return sb.ToString();

        }
    }
}

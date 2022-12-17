using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.sisware.bean
{
    public class EInventory
    {
        public int id { get; set; }
        public string code { get; set; }
        public int lot { get; set; }
        public double quantity { get; set; }
        public string description { get; set; }
        public double residue { get; set; }
        public int userId { get; set; }
        public int articleId { get; set; }
        public int inputId { get; set; }

        public string toString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append(",id=").Append(code);
            sb.Append(",code=").Append(code);
            sb.Append(",lot=").Append(lot);
            sb.Append(",quantity=").Append(quantity);
            sb.Append(",description=").Append(description);
            sb.Append(",residue=").Append(residue);
            sb.Append(",userId=").Append(userId);
            sb.Append(",articleId=").Append(articleId);
            sb.Append(",inputId=").Append(inputId);
            sb.Append("}");
            return sb.ToString();
        }
    }
}

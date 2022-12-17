using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.sisware.bean
{
    public class EInput
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string hour { get; set; }
        public string inputNumber { get; set; }
        public string code { get; set; }
        public double quantity { get; set; }
        public string observation { get; set; }
        public int userId { get; set; }
        public int providerId { get; set; }
        public int articleId { get; set; }

        public string toString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append(",code=").Append(code);
            sb.Append(",date=").Append(date.ToString());
            sb.Append(",hour=").Append(hour);
            sb.Append(",inputNumber=").Append(inputNumber);
            sb.Append(",code=").Append(code);
            sb.Append(",quantity=").Append(quantity);
            sb.Append(",observation=").Append(observation);
            sb.Append(",userId=").Append(userId);
            sb.Append(",providerId=").Append(providerId);
            sb.Append(",articleId=").Append(articleId);
            sb.Append("}");
            return sb.ToString();
        }
    }
}

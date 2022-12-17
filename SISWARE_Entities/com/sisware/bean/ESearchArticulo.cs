using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.sisware.bean
{
    public class ESearchArticle
    {
        public int articleId { get; set; }
        public string articleDescription { get; set; }
        public string articleMeasureUnit { get; set;}

        public string toString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append("articleId,=").Append(articleId);
            sb.Append(",articleDescription=").Append(articleDescription);
            sb.Append(",articleMeasureUnit=").Append(articleMeasureUnit);
            sb.Append("}");
            return sb.ToString();
        }
    }
}

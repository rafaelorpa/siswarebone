﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.sisware.bean
{
    public class EArticle
    {
        public int id { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }
        public int userId { get; set; }
        public int subCategoryId { get; set; }
        public int measureId { get; set; }
        public string measure { get; set; }

      

        public string toString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append(",id=").Append(id);
            sb.Append(",description=").Append(description);
            sb.Append(",date=").Append(date.ToString());
            sb.Append(",userId=").Append(userId);
            sb.Append(",subCategoryId=").Append(subCategoryId);
            sb.Append(",measureId=").Append(measureId);
            sb.Append(",measure=").Append(measure);
            sb.Append("}");
            return sb.ToString();
        }
    }
}

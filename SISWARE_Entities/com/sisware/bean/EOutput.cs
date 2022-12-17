using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.sisware.bean
{
    public class EOutput
    {
        public int id { get; set; }
        public string outputNumber { get; set; }
        public DateTime date { get; set; }
        public string hourEntry { get; set; }
        public string hourExit { get; set; }
        public int instrumentalistId { get; set; }
        public DateTime dateConfirm  { get; set; }
        public DateTime dateSurgery { get; set; }
        public int hospitalId { get; set; }
        public int medicalId { get; set; }
        public string diagnosis { get; set; }
        public int patientId { get; set; }
        public double quantity { get; set; }
        public int articleId { get; set; }
        public string observation { get; set; }
        public int userId { get; set; }
        public int inventaryId { get; set; }
        public string toString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append(",id=").Append(id);
            sb.Append(",outputNumber=").Append(outputNumber);
            sb.Append(",date=").Append(date.ToString());
            sb.Append(",hourEntry=").Append(hourEntry);
            sb.Append(",hourExit=").Append(hourExit);
            sb.Append(",instrumentalistId=").Append(instrumentalistId);
            sb.Append(",dateConfirm=").Append(dateConfirm);
            sb.Append(",dateSurgery=").Append(dateSurgery);
            sb.Append(",hospitalId=").Append(hospitalId);
            sb.Append(",medicalId=").Append(medicalId);
            sb.Append(",diagnosis").Append(diagnosis);
            sb.Append(",patientId").Append(patientId);
            sb.Append(",quantity=").Append(quantity);
            sb.Append(",articleId=").Append(articleId);
            sb.Append(",observation=").Append(observation);
            sb.Append(",userId=").Append(userId);
            sb.Append(",inventaryId=").Append(inventaryId);
            sb.Append("}");
            return sb.ToString();
        }
    }
}

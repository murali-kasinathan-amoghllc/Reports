using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmoghReports.Library
{
    public class Duqm_NDE_HT_Status_Model
    {
        public string PROJ_ID { get; set; }
        public string JOB_CODE { get; set; }
        public string CLIENT_NAME { get; set; }
        public string JV_OF { get; set; }
        public string JOB_NAME { get; set; }
        public string SHORT_CODE { get; set; }
        public string REP_TITLE1 { get; set; }
        public string REP_TITLE2 { get; set; }
        public int SUB_CON_ID { get; set; }
        public string SUB_CON_NAME { get; set; }
        public int CAT_ID { get; set; }
        public string CAT_NAME { get; set; }
        public string LINE_CLASS { get; set; }
        public string HT { get; set; }
        public int TOTAL_JOINTS { get; set; }
        public int HT_WELDED { get; set; }
        public int HT_REQUIRED { get; set; }
        public int HT_REQUESTED { get; set; }
        public int HT_DONE { get; set; }
        public double HT_COVERAGE { get; set; }
        public int HT_BALANCE { get; set; }
    }
}

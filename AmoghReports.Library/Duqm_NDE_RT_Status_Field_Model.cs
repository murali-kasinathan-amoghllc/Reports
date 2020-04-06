using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmoghReports.Library
{
    public class Duqm_NDE_RT_Status_Field_Model
    {
        public string PROJ_ID { get; set; }
        public string JOB_CODE { get; set; }
        public string CLIENT_NAME { get; set; }
        public string JV_OF { get; set; }
        public string JOB_NAME { get; set; }
        public string SHORT_CODE { get; set; }
        public string REP_TITLE1 { get; set; }
        public string REP_TITLE2 { get; set; }
        public string SUB_CON_ID { get; set; }
        public string SUB_CON_NAME { get; set; }
        public string CAT_ID { get; set; }
        public string CAT_NAME { get; set; }
        public string LINE_CLASS { get; set; }
        public int RT { get; set; }
        public int TOTAL_JOINTS { get; set; }
        public int BW_JOINTS { get; set; }
        public int SW_JOINTS { get; set; }
        public int BW_WELDED { get; set; }
        public int SW_WELDED { get; set; }
        public int BW_REQUIRED { get; set; }
        public int SW_REQUIRED { get; set; }
        public int BW_REQUESTED { get; set; }
        public int SW_REQUESTED { get; set; }
        public int BW_DONE { get; set; }
        public int SW_DONE { get; set; }
        public double BW_COVERAGE { get; set; }
        public double SW_COVERAGE { get; set; }
        public double COVERAGE { get; set; }
        public int BW_BALANCE { get; set; }
        public int SW_BALANCE { get; set; }
        public int BW_REJ { get; set; }
        public int SW_REJ { get; set; }
        public int REPAIR_PCNT { get; set; }
    }
}

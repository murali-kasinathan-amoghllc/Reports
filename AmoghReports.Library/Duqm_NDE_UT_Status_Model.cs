using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmoghReports.Library
{
    public class Duqm_NDE_UT_Status_Model
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
        public string UT { get; set; }
        public int TOTAL_JOINTS { get; set; }
        public int TOTAL_JOINT_LS { get; set; }
        public int BW_JOINTS { get; set; }
        public int SW_JOINTS { get; set; }
        public int LET_JOINTS { get; set; }
        public int SOB_JOINTS { get; set; }
        public int BW_WELDED { get; set; }
        public int SW_WELDED { get; set; }
        public int LET_WELDED { get; set; }
        public int SOB_WELDED { get; set; }
        public int BW_REQUIRED { get; set; }
        public int SW_REQUIRED { get; set; }
        public int LET_REQUIRED { get; set; }
        public int SOB_REQUIRED { get; set; }
        public int BW_REQUESTED { get; set; }
        public int SW_REQUESTED { get; set; }
        public int LET_REQUESTED { get; set; }
        public int SOB_REQUESTED { get; set; }
        public int BW_DONE { get; set; }
        public int SW_DONE { get; set; }
        public int LET_DONE { get; set; }
        public int SOB_DONE { get; set; }
        public double BW_COVERAGE { get; set; }
        public double SW_COVERAGE { get; set; }
        public double LET_COVERAGE { get; set; }
        public double SOB_COVERAGE { get; set; }
        public double COVERAGE { get; set; }
        public double COVERAGE_LS { get; set; }
        public int BW_BALANCE { get; set; }
        public int SW_BALANCE { get; set; }
        public int LET_BALANCE { get; set; }
        public int SOB_BALANCE { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmoghReports.Library
{
    public class Welder_Performance_Model
    {
        public string PROJECT_ID { get; set; }
        public string JOB_CODE { get; set; }
        public string CLIENT_NAME { get; set; }
        public string PROJ_DESC { get; set; }
        public string JOB_NAME { get; set; }
        public int SC_ID { get; set; }
        public string REP_TITLE1 { get; set; }
        public string REP_TITLE2 { get; set; }
        public string SUB_CON_NAME { get; set; }
        public string MAT_TYPE { get; set; }
        public string LINE_CLASS { get; set; }
        public int WELDER_ID { get; set; }
        public string WELDER_NO { get; set; }
        public double JNTS_WELDED_C { get; set; }
        public double JNTS_RT_DONE_C { get; set; }
        public double JNTS_REPAR_C { get; set; }
        public double JNTS_WELDED_THIS { get; set; }
        public double JNTS_RT_DONE_THIS { get; set; }
        public double JNTS_REPAR_THIS { get; set; }
        public double JNTS_WELDED_LAST_WEEK { get; set; }
        public double JNTS_RT_DONE_LAST_WEEK { get; set; }
        public double JNTS_REPAR_LAST_WEEK { get; set; }
        public double JNTS_WELDED_PREV { get; set; }
        public double JNTS_RT_DONE_PREV { get; set; }
        public double JNTS_REPAR_PREV { get; set; }
    }
}

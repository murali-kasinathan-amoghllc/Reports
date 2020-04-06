using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmoghReports.Library
{
    public class Welder_Performance_Percent_Model
    {
        public string PROJECT_ID { get; set; }
        public string JOB_CODE { get; set; }
        public string CLIENT_NAME { get; set; }
        public string PROJ_DESC { get; set; }
        public string JOB_NAME { get; set; }
        public int SC_ID { get; set; }
        public int JOINT_SIZE { get; set; }
        public string SUB_CON_NAME { get; set; }
        public int WELDER_ID { get; set; }
        public int RT { get; set; }
        public string WELDER_NO { get; set; }
        public double JNTS_WELDED_P { get; set; }
        public double JNTS_WELDED_C { get; set; }
        public double JNTS_RT_DONE_P { get; set; }
        public double JNTS_RT_DONE_C { get; set; }
        public double JNTS_REPAR_P { get; set; }
        public double JNTS_REPAR_C { get; set; }
        public double SIZE_DEC { get; set; }
    }
}

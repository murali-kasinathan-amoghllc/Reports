using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmoghReports.Library
{
    public class FitupWeldingProgress_SizeWise_Model
    {
        public string JOB_CODE { get; set; }
        public string JOB_NAME { get; set; }
        public string PROJ_REM { get; set; }
        public int SUB_CON_ID { get; set; }
        public int FIELD_SC_ID { get; set; }
        public string SUB_CON_NAME { get; set; }
        public string JOINT_SIZE { get; set; }
        public double JOINT_SIZE_DEC { get; set; }
        public double S_ID_SCOPE { get; set; }
        public double S_FITUP_DONE { get; set; }
        public double S_WELDING_DONE { get; set; }
        public double F_ID_SCOPE { get; set; }
        public double F_FITUP_DONE { get; set; }
        public double F_WELDING_DONE { get; set; }
    }
}

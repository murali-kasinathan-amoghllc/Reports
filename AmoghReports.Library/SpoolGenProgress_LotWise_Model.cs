using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmoghReports.Library
{
    public class SpoolGenProgress_LotWise_Model
    {
        public string PROJECT_ID { get; set; }
        public string JOB_CODE { get; set; }
        public string CLIENT_NAME { get; set; }
        public string PROJ_REM { get; set; }
        public string JOB_NAME { get; set; }
        public string LOT_NO { get; set; }
        public string LOT_RECV { get; set; }
        public int HCOPY_RECV { get; set; }
        public int IDF_RECV { get; set; }
        public int MARK_DATE { get; set; }
        public int SG_DATE { get; set; }
        public int SG_BAL { get; set; }
        public int BACK_CHK { get; set; }
        public int BCK_CHK_BAL { get; set; }
        public int MAT_CHK { get; set; }
        public int MAT_CHK_BAL { get; set; }
        public int TRANS_QTY { get; set; }
        public int HOLD_QTY { get; set; }
        public int TRANS_BAL { get; set; }
    }
}

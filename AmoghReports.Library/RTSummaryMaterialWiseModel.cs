using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmoghReports.Library
{
    public class RTSummaryMaterialWiseModel
    {
        public int project_id { get; set; }
        public string job_code { get; set; }
        public string job_name { get; set; }
        public string client_name { get; set; }
        public string proj_rem { get; set; }
        public string app_logo1 { get; set; }
        public string app_logo2 { get; set; }
        public string mat_type { get; set; }
        public int cat_id { get; set; }
        public int rt_percentage { get; set; }
        public int jnt_welded { get; set; }
        public int jnt_nde_done { get; set; }
        public int jnt_repair { get; set; }
        public int jnt_repaired { get; set; }
        public int total_films { get; set; }
        public int acc_films { get; set; }
        public int rej_films { get; set; }
        public int reshoot_films { get; set; }

        public RTSummaryMaterialWiseModel()
        {

        }
    }
}

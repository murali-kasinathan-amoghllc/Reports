using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmoghReports.Library
{
    public class RadiographyInspectionModel
    {
        public string project_id { get; set; }
        public string job_code { get; set; }
        public string iso_title1 { get; set; }
        public string spool { get; set; }
        public string joint_no { get; set; }
        public string joint_id { get; set; }
        public string root_hot_welder { get; set; }
        public string fill_cap_welder { get; set; }
        public string joint_size_dec { get; set; }
        public string schedule { get; set; }
        public string joint_type { get; set; }
        public string weld_process { get; set; }
        public string material { get; set; }
        public string wps_no { get; set; }
        public string pwht { get; set; }
        public string nde_rep_no { get; set; }
        public string nde_date { get; set; }
        public string pass_flg { get; set; }
        public string nde_type { get; set; }
        public string total_films { get; set; }
        public string repair_films { get; set; }
        public string reshoot_films { get; set; }
        public string repair_code { get; set; }
    }
}

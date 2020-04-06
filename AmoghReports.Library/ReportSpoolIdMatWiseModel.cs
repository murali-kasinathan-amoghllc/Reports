using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmoghReports.Library
{
    public class ReportSpoolIdMatWiseModel
    {
        public int project_id { get; set; }
        public string job_code { get; set; }
        public string job_name { get; set; }
        public string client_name { get; set; }
        public string proj_rem { get; set; }
        public string app_logo1 { get; set; }
        public string app_logo2 { get; set; }
        public string mat_type { get; set; }
        public double sg_shop { get; set; }
        public double sg_field { get; set; }
        public double sg_total { get; set; }
        public double mat_avl { get; set; }
        public double jc_issued { get; set; }
        public double swn { get; set; }
        public double nde_cmplt { get; set; }
        public double dim_check { get; set; }
        public double qc_cleared { get; set; }
        public double paint_req { get; set; }
        public double shipping_jc { get; set; }
        public double painted { get; set; }
        public double shipping { get; set; }
        public double shop_fitup { get; set; }
        public double shop_welding { get; set; }
        public double field_fitup { get; set; }
        public double field_welding { get; set; }
    }
}

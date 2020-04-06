using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmoghReports.Library
{
    public class RFI_Transmittal_Model
    {
        public string project_id { get; set; }
        public string rfi_number { get; set; }
        public string rfi_item_id { get; set; }
        public string rfi_date { get; set; }
        public string area_location { get; set; }
        public string sub_con_id { get; set; }
        public string sub_con_name { get; set; }
        public string intervention_point { get; set; }
        public string intervention { get; set; }
        public string discipline { get; set; }
        public string rfi_discipline_type { get; set; }
        public string itr_number { get; set; }
        public string itp_number { get; set; }
        public string itp_item_no { get; set; }
        public string sub_sys_number { get; set; }
        public string inspector_name { get; set; }
        public string inspector_activity { get; set; }
        public string inspector_tag_number { get; set; }
        public string drawing_rev_no { get; set; }
        public string inspection_result { get; set; }
        public string inspection { get; set; }
        public string itr_signed_off { get; set; }
        public string itr_signed { get; set; }
        public string rfi_reason { get; set; }
        public string rfi_reason_desc { get; set; }
        public string remarks { get; set; }
        public string created_at { get; set; }
        public string created_by { get; set; }
        public string job_code { get; set; }
        public string short_code { get; set; }
        public string app_logo1 { get; set; }
        public string app_logo2 { get; set; }
    }
}

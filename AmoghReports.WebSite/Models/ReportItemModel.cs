using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmoghReports.WebSite.Models
{
    public class ReportItemModel
    {
        public int categoryID { get; set; }
        public int reportId { get; set; }
        public string reportTitle { get; set; }
        public string isChart { get; set; }
        public string ServiceUrl { get; set; }
        public int forProjId { get; set; }
        public List<ReportItemParam> reportParams { get; set; }
        public ReportItemModel()
        {
            reportParams = new List<ReportItemParam>();
        }
    }
}
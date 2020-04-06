using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmoghHome.Web.Models
{
    public class ReportItemParam
    {
        public int reportId { get; set; }
        public string paramName { get; set; }
        public string paramText { get; set; }
        public int paramTypeId { get; set; }
        public string paramTypeName { get; set; }
        public ReportItemParam()
        {
        }
    }
}
using AmoghReports.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmoghHome.Web.Views.Home
{
    public partial class RT_SummaryMaterialWiseReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ProjId = Convert.ToInt32(Session["ProjId"]);
            RTSummaryMaterialWiseReport reports = new RTSummaryMaterialWiseReport();
            reports.ReportParameters[0].Value = 1;
            reports.ReportParameters[1].Value = ProjId;
            ReportViewer1.ReportSource = reports;
        }
    }
}
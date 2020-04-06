using AmoghReports.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmoghReports.WebSite.Reports
{
    public partial class SpoolGenProgressExclude3RevLotWiseReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ProjId = Convert.ToInt32(Session["ProjId"]);
            SpoolGenProgress_LotWise_Exclude3RevReport reports = new SpoolGenProgress_LotWise_Exclude3RevReport();
            reports.ReportParameters[0].Value = ProjId;
            ReportViewer1.ReportSource = reports;
        }
    }
}
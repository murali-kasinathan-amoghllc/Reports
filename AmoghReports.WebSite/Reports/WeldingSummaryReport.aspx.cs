using AmoghReports.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmoghReports.WebSite.Reports
{
    public partial class WeldingSummaryReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            projId.Value = Session["ProjId"].ToString();
            ReportViewer1.Visible = false;
        }

        protected void BtnReports_Click(object sender, EventArgs e)
        {
            int ProjId = Convert.ToInt32(Session["ProjId"]);
            var weldNo = weldNumber.Value;
            ReportViewer1.Visible = true;
            Duqm_DailyWeldingControlSheet report = new Duqm_DailyWeldingControlSheet();
            report.ReportParameters[0].Value = ProjId;
            report.ReportParameters[1].Value = weldNo;
            ReportViewer1.ReportSource = report;
        }
    }
}
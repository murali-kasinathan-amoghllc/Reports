using AmoghReports.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmoghReports.WebSite.Reports
{
    public partial class Magnetic_ParticleTestingReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportViewer1.Visible = false;
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            int ProjId = Convert.ToInt32(Session["ProjId"]);
            ReportViewer1.Visible = true;
            MagneticParticleTestingReport report = new MagneticParticleTestingReport();
            report.ReportParameters[0].Value = ProjId;
            report.ReportParameters[1].Value = mt_NDE_ReportNo.Value;
            ReportViewer1.ReportSource = report;
        }
    }
}
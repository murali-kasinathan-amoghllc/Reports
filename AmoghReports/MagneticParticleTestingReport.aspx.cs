using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AmoghReports.Library;
using Telerik.Reporting.Processing;

namespace AmoghReports.Website
{
    public partial class MagneticParticleTestingReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            MagneticParticleTesting report = new MagneticParticleTesting();
            report.ReportParameters[0].Value = txtProjectID.Text;
            this.magneticParticleTestingReportViewer.ReportSource = report;
        }
    }
}
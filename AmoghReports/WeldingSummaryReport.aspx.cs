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
    public partial class WeldingSummaryReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            //Duqm_DailyWeldingControlSheet report = new Duqm_DailyWeldingControlSheet();
            //report.ReportParameters[0].Value = txtProjectId.Text;
            //report.ReportParameters[1].Value = txtWeldNumber.Text;
            //this.ReportViewer1.ReportSource = report;
        }
    }
}
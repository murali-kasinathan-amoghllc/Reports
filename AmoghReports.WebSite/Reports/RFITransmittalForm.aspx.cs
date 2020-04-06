using AmoghReports.Library;
using AmoghReports.WebSite.RFITransmittalWebservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmoghReports.WebSite.Reports
{
    public partial class RFITransmittalForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportViewer1.Visible = false;
            projId.Value = Session["ProjId"].ToString();
            RFIInput.Visible = false;
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            int ProjId = Convert.ToInt32(Session["ProjId"]);
            var rfiNumber = txtRptRFINumber.Value;
            ReportViewer1.Visible = true;
            RFIReport report = new RFIReport();
            report.ReportParameters[0].Value = ProjId;
            report.ReportParameters[1].Value = rfiNumber;
            ReportViewer1.ReportSource = report;

            RFIInput.Visible = false;
            RFIReport.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            RFIInput.Visible = false;
            RFIReport.Visible = true;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            projId.Value = Session["ProjId"].ToString();
            RFIInput.Visible = true;
            RFIReport.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int ProjectId = Convert.ToInt32(Session["ProjId"]);
            string rfiNumber = Request.Form[6];
            int subCon = Convert.ToInt32(Request.Form[7]);
            string insName = Request.Form[8];
            string insDate = Request.Form[9];
            string itemDes = Request.Form[10];
            string insResult = Request.Form[11];

            var service = new RFITransmittalService();
            int status = service.RegisterRFITransmittalDetails(ProjectId, rfiNumber, subCon, insName, insDate, itemDes, insResult);
            RFIInput.Visible = false;
            RFIReport.Visible = true;
        }
    }
}
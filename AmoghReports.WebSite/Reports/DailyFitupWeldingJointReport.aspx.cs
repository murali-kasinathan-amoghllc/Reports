using AmoghReports.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace AmoghReports.WebSite.Reports
{
    public partial class DailyFitupWeldingJointReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportViewer1.Visible = false;
            projId.Value = Session["ProjId"].ToString();
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            int ProjId = Convert.ToInt32(Session["ProjId"]);
            string category = Request.Form[6];
            string subCon = Request.Form[7];
            string matType = Request.Form[8];
            string dateFrom = Request.Form[9];
            string dateTo = Request.Form[10];
            string selectedReportType = Request.Form[11];
            ReportViewer1.Visible = true;
            //ProjId = 2;
            if (selectedReportType == "Fitup")
            {
                if (category == "1")
                {
                    DailyFitupShopReport report = new DailyFitupShopReport();
                    report.ReportParameters["ProjId"].Value = ProjId;
                    report.ReportParameters["CatId"].Value = category;
                    report.ReportParameters["SubConId"].Value = subCon;
                    report.ReportParameters["MatType"].Value = matType;
                    report.ReportParameters["DateFrom"].Value = dateFrom;
                    report.ReportParameters["DateTo"].Value = dateTo;
                    ReportViewer1.ReportSource = report;
                }
                else
                {
                    DailyFitup_Joint_Field_Report report = new DailyFitup_Joint_Field_Report();
                    report.ReportParameters["ProjId"].Value = ProjId;
                    report.ReportParameters["CatId"].Value = category;
                    report.ReportParameters["SubConId"].Value = subCon;
                    report.ReportParameters["MatType"].Value = matType;
                    report.ReportParameters["DateFrom"].Value = dateFrom;
                    report.ReportParameters["DateTo"].Value = dateTo;
                    ReportViewer1.ReportSource = report;
                }
            }

            if (selectedReportType == "Welding")
            {
                if (category == "1")
                {
                    DailyWelding_Joint_Shop_Report report = new DailyWelding_Joint_Shop_Report();
                    report.ReportParameters["ProjId"].Value = ProjId;
                    report.ReportParameters["CatId"].Value = category;
                    report.ReportParameters["SubConId"].Value = subCon;
                    report.ReportParameters["MatType"].Value = matType;
                    report.ReportParameters["DateFrom"].Value = dateFrom;
                    report.ReportParameters["DateTo"].Value = dateTo;
                    ReportViewer1.ReportSource = report;
                }
                else
                {
                    DailyWelding_Joint_Field_Report report = new DailyWelding_Joint_Field_Report();
                    report.ReportParameters["ProjId"].Value = ProjId;
                    report.ReportParameters["CatId"].Value = category;
                    report.ReportParameters["SubConId"].Value = subCon;
                    report.ReportParameters["MatType"].Value = matType;
                    report.ReportParameters["DateFrom"].Value = dateFrom;
                    report.ReportParameters["DateTo"].Value = dateTo;
                    ReportViewer1.ReportSource = report;
                }
            }
        }
    }
}
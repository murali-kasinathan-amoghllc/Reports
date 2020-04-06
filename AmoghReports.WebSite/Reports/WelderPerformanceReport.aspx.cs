using AmoghReports.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmoghReports.WebSite.Reports
{
    public partial class WelderPerformanceReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportViewer1.Visible = false;
            projId.Value = Session["ProjId"].ToString();
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            int ProjId = Convert.ToInt32(Session["ProjId"]);
            string dateFrom = Request.Form[6];
            string dateTo = Request.Form[7];
            string subCon = Request.Form[8];
            string selectedReportType = Request.Form[9];
            ReportViewer1.Visible = true;
            //ProjId = 2;

            if(selectedReportType == "Welder Wise")
            { 
                WelderPerformance report = new WelderPerformance();
                report.ReportParameters["ProjId"].Value = ProjId;
                report.ReportParameters["SubConId"].Value = subCon;
                report.ReportParameters["DateFrom"].Value = dateFrom;
                report.ReportParameters["DateTo"].Value = dateTo;
                ReportViewer1.ReportSource = report;
            }
            if (selectedReportType == "Length Wise")
            {
                WelderPerformanceLengthWise report = new WelderPerformanceLengthWise();
                report.ReportParameters["ProjId"].Value = ProjId;
                report.ReportParameters["SubConId"].Value = subCon;
                report.ReportParameters["DateFrom"].Value = dateFrom;
                report.ReportParameters["DateTo"].Value = dateTo;
                ReportViewer1.ReportSource = report;
            }
            if (selectedReportType == "Material Wise")
            {
                FitupWeldingProgressMaterialWise report = new FitupWeldingProgressMaterialWise();
                report.ReportParameters["ProjId"].Value = ProjId;
                report.ReportParameters["SubConId"].Value = subCon;
                report.ReportParameters["DateFrom"].Value = dateFrom;
                report.ReportParameters["DateTo"].Value = dateTo;
                ReportViewer1.ReportSource = report;
            }
            if (selectedReportType == "RT Percent")
            {
                Welder_Performance_RTPercent_Report report = new Welder_Performance_RTPercent_Report();
                report.ReportParameters["ProjId"].Value = ProjId;
                report.ReportParameters["SubConId"].Value = subCon;
                report.ReportParameters["DateFrom"].Value = dateFrom;
                report.ReportParameters["DateTo"].Value = dateTo;
                ReportViewer1.ReportSource = report;
            }
            if (selectedReportType == "Weld Size")
            {
                Welder_Performance_WeldSize_Report report = new Welder_Performance_WeldSize_Report();
                report.ReportParameters["ProjId"].Value = ProjId;
                report.ReportParameters["SubConId"].Value = subCon;
                report.ReportParameters["DateFrom"].Value = dateFrom;
                report.ReportParameters["DateTo"].Value = dateTo;
                ReportViewer1.ReportSource = report;
            }
            if (selectedReportType == "Monthly")
            {
                Welder_Performance_Monthly_Report report = new Welder_Performance_Monthly_Report();
                report.ReportParameters["ProjId"].Value = ProjId;
                report.ReportParameters["SubConId"].Value = subCon;
                report.ReportParameters["DateFrom"].Value = dateFrom;
                report.ReportParameters["DateTo"].Value = dateTo;
                ReportViewer1.ReportSource = report;
            }
            if (selectedReportType == "Welder/Lineclass Wise")
            {
                Welder_Performance_LineClass_Report report = new Welder_Performance_LineClass_Report();
                report.ReportParameters["ProjId"].Value = ProjId;
                report.ReportParameters["SubConId"].Value = subCon;
                report.ReportParameters["DateFrom"].Value = dateFrom;
                report.ReportParameters["DateTo"].Value = dateTo;
                ReportViewer1.ReportSource = report;
            }
            if (selectedReportType == "Length/Lineclass Wise")
            {
                Welder_Performance_LineClassLength_Report report = new Welder_Performance_LineClassLength_Report();
                report.ReportParameters["ProjId"].Value = ProjId;
                report.ReportParameters["SubConId"].Value = subCon;
                report.ReportParameters["DateFrom"].Value = dateFrom;
                report.ReportParameters["DateTo"].Value = dateTo;
                ReportViewer1.ReportSource = report;
            }
        }
    }
}
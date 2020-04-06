using AmoghReports.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmoghReports.WebSite.Reports
{
    public partial class FitupWeldingProgressReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportViewer1.Visible = false;
            projId.Value = Session["ProjId"].ToString();

            if (!IsPostBack)
            {

            }
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            int ProjId = Convert.ToInt32(Session["ProjId"]);
            string category = Request.Form[6];
            string subCon = Request.Form[7];
            string dateFrom = Request.Form[8];
            string dateTo = Request.Form[9];
            string selectedReportType = Request.Form[10];
            ReportViewer1.Visible = true;
            //ProjId = 2;

            if (selectedReportType == "Area Wise")
            {
                if(category == "1")
                {
                    FitupWeldingProgressAreaWise report = new FitupWeldingProgressAreaWise();
                    report.ReportParameters["ProjId"].Value = ProjId;
                    report.ReportParameters["CatId"].Value = category;
                    report.ReportParameters["SubConId"].Value = subCon;
                    report.ReportParameters["DateFrom"].Value = dateFrom;
                    report.ReportParameters["DateTo"].Value = dateTo;
                    ReportViewer1.ReportSource = report;
                }
                else
                {
                    FitupWeldingProgressFieldAreaWise report = new FitupWeldingProgressFieldAreaWise();
                    report.ReportParameters["ProjId"].Value = ProjId;
                    report.ReportParameters["CatId"].Value = category;
                    report.ReportParameters["SubConId"].Value = subCon;
                    report.ReportParameters["DateFrom"].Value = dateFrom;
                    report.ReportParameters["DateTo"].Value = dateTo;
                    ReportViewer1.ReportSource = report;
                }
            }

            if (selectedReportType == "Size Wise")
            {
                if (category == "1")
                {
                    FitupWeldingProgressSizeWise report = new FitupWeldingProgressSizeWise();
                    report.ReportParameters["ProjId"].Value = ProjId;
                    report.ReportParameters["CatId"].Value = category;
                    report.ReportParameters["SubConId"].Value = subCon;
                    report.ReportParameters["DateFrom"].Value = dateFrom;
                    report.ReportParameters["DateTo"].Value = dateTo;
                    ReportViewer1.ReportSource = report;
                }
                else
                {
                    FitupWeldingProgressField_SizeWise_Report report = new FitupWeldingProgressField_SizeWise_Report();
                    report.ReportParameters["ProjId"].Value = ProjId;
                    report.ReportParameters["CatId"].Value = category;
                    report.ReportParameters["SubConId"].Value = subCon;
                    report.ReportParameters["DateFrom"].Value = dateFrom;
                    report.ReportParameters["DateTo"].Value = dateTo;
                    ReportViewer1.ReportSource = report;
                }
            }

            if (selectedReportType == "Material Wise")
            {
                if (category == "1")
                {
                    FitupWeldingProgressMatWise report = new FitupWeldingProgressMatWise();
                    report.ReportParameters["ProjId"].Value = ProjId;
                    report.ReportParameters["CatId"].Value = category;
                    report.ReportParameters["SubConId"].Value = subCon;
                    report.ReportParameters["DateFrom"].Value = dateFrom;
                    report.ReportParameters["DateTo"].Value = dateTo;
                    ReportViewer1.ReportSource = report;
                }
                else
                {
                    FitupWeldingProgressMaterialWise report = new FitupWeldingProgressMaterialWise();
                    report.ReportParameters["ProjId"].Value = ProjId;
                    report.ReportParameters["CatId"].Value = category;
                    report.ReportParameters["SubConId"].Value = subCon;
                    report.ReportParameters["DateFrom"].Value = dateFrom;
                    report.ReportParameters["DateTo"].Value = dateTo;
                    ReportViewer1.ReportSource = report;
                }
            }

        }
    }
}
using AmoghReports.Library;
using AmoghReports.WebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmoghReports.WebSite.Reports
{
    public partial class NDE_StatusReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportViewer1.Visible = false;
            projId.Value = Session["ProjId"].ToString();
           
            if (!IsPostBack) { 
                
            }
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            int ProjId = Convert.ToInt32(Session["ProjId"]);
            string selectedSubcon = Request.Form[8];
            string selectedNDE = Request.Form[9];
            ReportViewer1.Visible = true;
           // ProjId = 2;
            int cat_Id;
            string includeProd = string.Empty;
            if (rdo_Category_shop.Checked == true)
                cat_Id = int.Parse(rdo_Category_shop.Value);
            else
                cat_Id = int.Parse(rdo_Category_field.Value);

            int nde_type_id;
            if (selectedNDE == "3.1")
                nde_type_id = 31;
            else
                nde_type_id = int.Parse(selectedNDE);

            if (rdo_reportType_include.Checked == true)
                includeProd = "Y";
            else
                includeProd = "N";


                if (nde_type_id == 1)
                {
                        NDE_RT_Status_ClassWise_Report report1 = new NDE_RT_Status_ClassWise_Report();
                        report1.ReportParameters[0].Value = ProjId;
                        report1.ReportParameters[1].Value = selectedSubcon;
                        report1.ReportParameters[2].Value = cat_Id;
                        report1.ReportParameters[3].Value = includeProd;
                        ReportViewer1.ReportSource = report1;
                }

            if (nde_type_id == 7)
            {
                    NDE_PWHT_Status_ClassWise_Report report1 = new NDE_PWHT_Status_ClassWise_Report();
                    report1.ReportParameters[0].Value = ProjId;
                    report1.ReportParameters[1].Value = selectedSubcon;
                    report1.ReportParameters[2].Value = cat_Id;
                    report1.ReportParameters[3].Value = includeProd;
                    ReportViewer1.ReportSource = report1;
            }

            if (nde_type_id == 8)
            {
                    NDE_HT_Status_ClassWise_Report report1 = new NDE_HT_Status_ClassWise_Report();
                    report1.ReportParameters[0].Value = ProjId;
                    report1.ReportParameters[1].Value = selectedSubcon;
                    report1.ReportParameters[2].Value = cat_Id;
                    report1.ReportParameters[3].Value = includeProd;
                    ReportViewer1.ReportSource = report1;
            }

            if (nde_type_id == 9)
            {
                NDE_PMI_Status_ClassWise_Report report1 = new NDE_PMI_Status_ClassWise_Report();
                report1.ReportParameters[0].Value = ProjId;
                report1.ReportParameters[1].Value = selectedSubcon;
                report1.ReportParameters[2].Value = cat_Id;
                report1.ReportParameters[3].Value = includeProd;
                ReportViewer1.ReportSource = report1;
            }

            if (nde_type_id == 10)
            {
                    NDE_FT_Status_ClassWise_Report report1 = new NDE_FT_Status_ClassWise_Report();
                    report1.ReportParameters[0].Value = ProjId;
                    report1.ReportParameters[1].Value = selectedSubcon;
                    report1.ReportParameters[2].Value = cat_Id;
                    report1.ReportParameters[3].Value = includeProd;
                    ReportViewer1.ReportSource = report1;
            }

            if (nde_type_id == 12)
            {
                    NDE_UT_Status_ClassWise_Report report1 = new NDE_UT_Status_ClassWise_Report();
                    report1.ReportParameters[0].Value = ProjId;
                    report1.ReportParameters[1].Value = selectedSubcon;
                    report1.ReportParameters[2].Value = cat_Id;
                    report1.ReportParameters[3].Value = includeProd;
                    ReportViewer1.ReportSource = report1;
            }
            
        }

      
    }
}
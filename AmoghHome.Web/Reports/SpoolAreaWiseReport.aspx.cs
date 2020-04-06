using AmoghHome.Web.Models;
using AmoghReports.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmoghHome.Web.Views.Home
{
    public partial class SpoolAreaWiseReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //var rptName = Request.QueryString["reportName"];
            //string rptParam = Request.QueryString["param"];

            //JavaScriptSerializer js = new JavaScriptSerializer();
            //List<ReportItemParam> json_rpts = js.Deserialize<List<ReportItemParam>>(rptParam);

            int ProjId = Convert.ToInt32(Session["ProjId"]);
            SpoolIdAreaWise reports = new SpoolIdAreaWise();
            reports.ReportParameters[0].Value = ProjId;
            //report.ReportParameters[0].Value = ProjId;
            ReportViewer1.ReportSource = reports;
        }
    }
}
using AmoghReports.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmoghHome.Web.Views.Home
{
    public partial class SpoolId_PieChart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ProjId = Convert.ToInt32(Session["ProjId"]);
            SpoolIdPieChart chart = new SpoolIdPieChart();
            chart.ReportParameters[0].Value = ProjId;
            //report.ReportParameters[0].Value = ProjId;
            ReportViewer1.ReportSource = chart;
        }
    }
}
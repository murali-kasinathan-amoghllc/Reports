﻿using AmoghReports.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmoghHome.Web.Reports
{
    public partial class Liquid_PenetrantTestingReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            int ProjId = Convert.ToInt32(Session["ProjId"]);
            LiquidPenetrantTestingReport report = new LiquidPenetrantTestingReport();
            report.ReportParameters[0].Value = ProjId;
            report.ReportParameters[1].Value = rt_NDE_ReportNo.Value;
            ReportViewer1.ReportSource = report;
        }
    }
}
using AmoghReports.Library;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace AmoghReports.Service
{
    [WebService(Namespace = "http://maakuthari.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class DuqmWeldingReportService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetDailyWeldingControlSheet(int ProjId, string weldReportNo)
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            List<DuqmDailyWeldingControlSheetModel> weldSummary = new List<DuqmDailyWeldingControlSheetModel>();
            string conn_str = DatabaseTools.AmgDbConnectionString(ProjId);
            using (OracleConnection conn = new OracleConnection(conn_str))
            {
                conn.Open();
                string sql = "SELECT * FROM REP_DAILY_WELDING_CTRL_SHT" +
                    $" WHERE PROJECT_ID={1} AND WELD_REP_NO = '{weldReportNo}'";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DuqmDailyWeldingControlSheetModel summary = new DuqmDailyWeldingControlSheetModel();
                        summary.duqm_no = dr["DUQM_NO"].ToString();
                        summary.iso_title1 = dr["ISO_TITLE1"].ToString();
                        summary.spool = dr["SPOOL"].ToString();
                        summary.joint_no = dr["JOINT_NO"].ToString();
                        summary.heat_no1 = dr["HEAT_NO1"].ToString();
                        summary.heat_no2 = dr["HEAT_NO2"].ToString();
                        summary.cat_name = dr["CAT_NAME"].ToString();
                        summary.mat_class = dr["MAT_CLASS"].ToString();
                        summary.ps = dr["PS"].ToString();
                        summary.joint_size_dec = double.Parse(dr["JOINT_SIZE_DEC"].ToString());
                        summary.schedule = dr["SCHEDULE"].ToString();
                        summary.joint_thk = double.Parse(dr["JOINT_THK"].ToString());
                        summary.joint_type = dr["JOINT_TYPE"].ToString();
                        summary.wps_no = dr["WPS_NO"].ToString();
                        //summary.welding_consumables = dr["WELDING_CONSUMABLES"].ToString();
                        summary.electrode_size = dr["ELECTRODE_SIZE"].ToString();
                        summary.batch_no = dr["BATCH_NO"].ToString();

                        string weld_date = dr["WELD_DATE"].ToString();
                        if (!string.IsNullOrEmpty(weld_date))
                        {
                            summary.weld_date = DateTime.Parse(dr["WELD_DATE"].ToString()).ToString("dd-MMM-yyyy");
                        }
                        
                        summary.fitup_date = DateTime.Parse(dr["FITUP_DATE"].ToString()).ToString("dd-MMM-yyyy");

                        summary.visual_affect = dr["VISUAL_AFFECT"].ToString();
                        summary.root_hot_welder = dr["ROOT_HOT_WELDER"].ToString();
                        summary.fill_cap_welder = dr["FILL_CAP_WELDER"].ToString();
                        summary.weld_rep_no = dr["WELD_REP_NO"].ToString();
                        summary.rt = double.Parse(string.IsNullOrEmpty(dr["RT"].ToString()) ? "0" : dr["RT"].ToString());
                        summary.pwht = dr["PWHT"].ToString();
                        summary.mt = dr["MT"].ToString();
                        summary.pt = dr["PT"].ToString();
                        summary.ut = dr["UT"].ToString();
                        summary.pmi = dr["PMI"].ToString();
                        summary.ht = dr["HT"].ToString();
                        weldSummary.Add(summary);
                    }
                }
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = int.MaxValue;
            string data = js.Serialize(weldSummary);
            Context.Response.Write(data);
        }


        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetDailyWeldingControlSheetPDF(int ProjId, string weldReportNo)
        {
            Random random = new Random();
            int fileId = random.Next(1000, 9999);
            string fileName = $"report_{fileId}.pdf";
            string filePath = $@"C:\Temp\{fileName}";

            Duqm_DailyWeldingControlSheet report = new Duqm_DailyWeldingControlSheet();
            Telerik.Reporting.Processing.ReportProcessor reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();
            report.ReportParameters["ProjId"].Value = ProjId;
            report.ReportParameters["weldReportNo"].Value = weldReportNo;

            Telerik.Reporting.Processing.RenderingResult renderingResult = reportProcessor.RenderReport("PDF", report, null);

            FileStream fs = new FileStream(filePath, FileMode.Create);
            fs.Write(renderingResult.DocumentBytes, 0, renderingResult.DocumentBytes.Length);
            fs.Close();

            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.AddHeader("Content-Disposition", $"attachment;filename={fileName}");
            HttpContext.Current.Response.TransmitFile(filePath);
            HttpContext.Current.Response.End();
        }

    }
}

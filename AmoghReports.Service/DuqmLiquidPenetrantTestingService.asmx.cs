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
    public class LiquidPenetrantTestingService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetLiquidPenetrantTestingDetails(int ProjId, string NDE_Rep_No)
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            List<LiquidPenetrantTestingModel> liquidPenetrantList = new List<LiquidPenetrantTestingModel>();
            string conn_str = DatabaseTools.AmgDbConnectionString(ProjId);
            using (OracleConnection conn = new OracleConnection(conn_str))
            {
                conn.Open();
                string sql = "SELECT * FROM VIEW_PT_REPORT_FORMAT_DT" +
                    $" WHERE PROJECT_ID={1} AND NDE_REP_NO = '{NDE_Rep_No}'";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        LiquidPenetrantTestingModel liquidPenetrant = new LiquidPenetrantTestingModel();
                        liquidPenetrant.project_id = dr["PROJECT_ID"].ToString();
                        liquidPenetrant.job_code = dr["JOB_CODE"].ToString();
                        liquidPenetrant.iso_title1 = dr["ISO_TITLE1"].ToString();
                        liquidPenetrant.spool = dr["SPOOL"].ToString();
                        liquidPenetrant.joint_no = dr["JOINT_NO"].ToString();
                        liquidPenetrant.joint_id = dr["JOINT_ID"].ToString();
                        liquidPenetrant.root_hot_welder = dr["ROOT_HOT_WELDER"].ToString();
                        liquidPenetrant.fill_cap_welder = dr["FILL_CAP_WELDER"].ToString();
                        liquidPenetrant.joint_size_dec = dr["JOINT_SIZE_DEC"].ToString();
                        liquidPenetrant.schedule = dr["SCHEDULE"].ToString();
                        liquidPenetrant.joint_type = dr["JOINT_TYPE"].ToString();
                        liquidPenetrant.weld_process = dr["WELD_PROCESS"].ToString();
                        liquidPenetrant.material = dr["MATERIAL"].ToString();
                        liquidPenetrant.wps_no = dr["WPS_NO"].ToString();
                        liquidPenetrant.pwht = dr["PWHT"].ToString();
                        liquidPenetrant.nde_rep_no = dr["NDE_REP_NO"].ToString();
                        string nde_date = dr["NDE_DATE"].ToString();
                        if (!string.IsNullOrEmpty(nde_date))
                        {
                            liquidPenetrant.nde_date = DateTime.Parse(dr["NDE_DATE"].ToString()).ToString("dd-MMM-yyyy");
                        }
                        liquidPenetrant.pass_flg = dr["PASS_FLG"].ToString();
                        liquidPenetrant.nde_type = dr["NDE_TYPE"].ToString();
                        liquidPenetrant.total_films = dr["TOTAL_FILMS"].ToString();
                        liquidPenetrant.repair_films = dr["REPAIR_FILMS"].ToString();
                        liquidPenetrant.reshoot_films = dr["RESHOOT_FILMS"].ToString();
                        liquidPenetrant.repair_code = dr["REPAIR_CODE"].ToString();
                        liquidPenetrant.cat_name = dr["CAT_NAME"].ToString();
                        liquidPenetrantList.Add(liquidPenetrant);
                    }
                }
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = int.MaxValue;
            string data = js.Serialize(liquidPenetrantList);
            Context.Response.Write(data);
        }


        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetLiquidPenetrantTestingDetailsPDF(int ProjId, string NDE_Rep_No)
        {
            Random random = new Random();
            int fileId = random.Next(1000, 9999);
            string fileName = $"report_{fileId}.pdf";
            string filePath = $@"C:\Temp\{fileName}";

            LiquidPenetrantTestingReport report = new LiquidPenetrantTestingReport();
            Telerik.Reporting.Processing.ReportProcessor reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();
            report.ReportParameters["ProjId"].Value = ProjId;
            report.ReportParameters["NDE_Report_No"].Value = NDE_Rep_No;

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

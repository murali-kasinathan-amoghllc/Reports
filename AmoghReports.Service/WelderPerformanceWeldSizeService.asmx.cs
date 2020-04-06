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
    /// <summary>
    /// Summary description for WelderPerformanceWeldSizeService
    /// </summary>
    [WebService(Namespace = "http://maakuthari.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class WelderPerformanceWeldSizeService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetWelderPerformanceWeldSizeDetails(int ProjId, int SUB_CON_ID, string DATE_FROM, string DATE_TO)
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            List<Welder_Performance_Percent_Model> welderPerformanceList = new List<Welder_Performance_Percent_Model>();
            string conn_str = DatabaseTools.AmgDbConnectionString(ProjId);
            using (OracleConnection conn = new OracleConnection(conn_str))
            {
                conn.Open();

                if (string.IsNullOrEmpty(DATE_FROM) && string.IsNullOrEmpty(DATE_TO))
                {
                    DATE_FROM = DateTime.Now.ToString("dd-MMM-yyyy");
                    DATE_TO = DateTime.Now.ToString("dd-MMM-yyyy");
                }

                string sql = "SELECT PROJECT_ID, JOB_CODE, CLIENT_NAME, JOB_NAME, PROJ_DESC, " +
                      $"SC_ID, SUB_CON_NAME, JOINT_SIZE,FNC_JNT_SIZE_DEC(JOINT_SIZE) AS SIZE_DEC, WELDER_ID, WELDER_NO," +
                      $"SUM(FNC_IIF_DATE(CREATE_DATE, '{DATE_FROM}', 0, WELD_JNTS, 0)) AS JNTS_WELDED_P," +
                      $"SUM(FNC_IIF_DATE(CREATE_DATE, '{DATE_TO}', WELD_JNTS, WELD_JNTS, 0)) AS JNTS_WELDED_C," +
                      $"SUM(FNC_IIF_DATE(CREATE_DATE, '{DATE_FROM}', 0, RT_JNTS, 0)) AS JNTS_RT_DONE_P," +
                      $"SUM(FNC_IIF_DATE(CREATE_DATE, '{DATE_TO}', RT_JNTS, RT_JNTS, 0)) AS JNTS_RT_DONE_C," +
                      $"SUM(FNC_IIF_DATE(CREATE_DATE, '{DATE_FROM}', 0, REP_JNTS, 0)) AS JNTS_REPAR_P," +
                      $"SUM(FNC_IIF_DATE(CREATE_DATE, '{DATE_TO}', REP_JNTS, REP_JNTS, 0)) AS JNTS_REPAR_C FROM VIEW_WELDER_PERF_F " +
                      $"WHERE PROJECT_ID={1}  AND SC_ID = {SUB_CON_ID} " +
                      $"GROUP BY WELDER_ID, WELDER_NO, SC_ID, SUB_CON_NAME, PROJECT_ID, JOB_CODE, CLIENT_NAME, JOB_NAME, PROJ_DESC, JOINT_SIZE, FNC_JNT_SIZE_DEC(JOINT_SIZE)" +
                      $"ORDER BY SUB_CON_NAME, SIZE_DEC, WELDER_NO";


                using (OracleCommand cmd = new OracleCommand(sql, conn))
                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Welder_Performance_Percent_Model welderPerformance = new Welder_Performance_Percent_Model();
                        welderPerformance.PROJECT_ID = dr["PROJECT_ID"].ToString();
                        welderPerformance.JOB_CODE = dr["JOB_CODE"].ToString();
                        welderPerformance.CLIENT_NAME = dr["CLIENT_NAME"].ToString();
                        welderPerformance.PROJ_DESC = dr["PROJ_DESC"].ToString();
                        welderPerformance.JOB_NAME = dr["JOB_NAME"].ToString();
                        welderPerformance.SUB_CON_NAME = dr["SUB_CON_NAME"].ToString();
                        welderPerformance.SC_ID = Convert.ToInt32(dr["SC_ID"].ToString());
                        string JOINT_SIZE = dr["JOINT_SIZE"].ToString();
                        if (!string.IsNullOrEmpty(JOINT_SIZE))
                        {
                            welderPerformance.JOINT_SIZE = Convert.ToInt32(dr["JOINT_SIZE"].ToString());
                        }
                        string SIZE_DEC = dr["SIZE_DEC"].ToString();
                        if (!string.IsNullOrEmpty(SIZE_DEC))
                        {
                            welderPerformance.SIZE_DEC = Convert.ToDouble(dr["SIZE_DEC"].ToString());
                        }
                        string welderID = dr["WELDER_ID"].ToString();
                        if (!string.IsNullOrEmpty(welderID))
                        {
                            welderPerformance.WELDER_ID = Convert.ToInt32(dr["WELDER_ID"].ToString());
                        }
                        welderPerformance.WELDER_NO = dr["WELDER_NO"].ToString();
                        welderPerformance.JNTS_WELDED_P = Convert.ToDouble(dr["JNTS_WELDED_P"].ToString());
                        welderPerformance.JNTS_WELDED_C = Convert.ToDouble(dr["JNTS_WELDED_C"].ToString());
                        welderPerformance.JNTS_RT_DONE_P = Convert.ToDouble(dr["JNTS_RT_DONE_P"].ToString());
                        welderPerformance.JNTS_RT_DONE_C = Convert.ToDouble(dr["JNTS_RT_DONE_C"].ToString());
                        welderPerformance.JNTS_REPAR_P = Convert.ToDouble(dr["JNTS_REPAR_P"].ToString());
                        welderPerformance.JNTS_REPAR_C = Convert.ToDouble(dr["JNTS_REPAR_C"].ToString());
                        welderPerformanceList.Add(welderPerformance);
                    }
                }
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = int.MaxValue;
            string data = js.Serialize(welderPerformanceList);
            Context.Response.Write(data);
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetWelderPerformanceWeldSizeDetailsPDF(int ProjId, int SUB_CON_ID, string DATE_FROM, string DATE_TO)
        {
            Random random = new Random();
            int fileId = random.Next(1000, 9999);
            string fileName = $"WelderPerformanceWeldSize_{fileId}.pdf";
            string filePath = $@"C:\Temp\{fileName}";

            if (string.IsNullOrEmpty(DATE_FROM) && string.IsNullOrEmpty(DATE_TO))
            {
                DATE_FROM = DateTime.Now.ToString("dd-MMM-yyyy");
                DATE_TO = DateTime.Now.ToString("dd-MMM-yyyy");
            }

            Welder_Performance_WeldSize_Report report = new Welder_Performance_WeldSize_Report();
            Telerik.Reporting.Processing.ReportProcessor reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();
            report.ReportParameters["ProjId"].Value = ProjId;
            report.ReportParameters["SubConId"].Value = SUB_CON_ID;
            report.ReportParameters["DateFrom"].Value = DATE_FROM;
            report.ReportParameters["DateTo"].Value = DATE_TO;

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

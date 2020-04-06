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
    /// Summary description for WelderPerformanceMaterialWiseService
    /// </summary>
    [WebService(Namespace = "http://maakuthari.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class WelderPerformanceMaterialWiseService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetWelderPerformanceMaterialWiseDetails(int ProjId, int SUB_CON_ID, string DATE_FROM, string DATE_TO)
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            List<Welder_Performance_Model> welderPerformanceList = new List<Welder_Performance_Model>();
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
                      $"SC_ID, SUB_CON_NAME, MAT_TYPE, WELDER_ID, WELDER_NO," +
                      $"SUM(FNC_IIF_DATE(CREATE_DATE, '{DATE_TO}', WELD_JNTS, WELD_JNTS, 0)) AS JNTS_WELDED_C," +
                      $"SUM(FNC_IIF_DATE(CREATE_DATE, '{DATE_TO}', RT_JNTS, RT_JNTS, 0)) AS JNTS_RT_DONE_C," +
                      $"SUM(FNC_IIF_DATE(CREATE_DATE, '{DATE_TO}', REP_JNTS, REP_JNTS, 0)) AS JNTS_REPAR_C," +
                      $"SUM(FNC_BETWEEN_DATE('{DATE_FROM}', '{DATE_TO}', CREATE_DATE, WELD_JNTS)) AS JNTS_WELDED_THIS," +
                      $"SUM(FNC_BETWEEN_DATE('{DATE_FROM}', '{DATE_TO}', CREATE_DATE, RT_JNTS)) AS JNTS_RT_DONE_THIS," +
                      $"SUM(FNC_BETWEEN_DATE('{DATE_FROM}', '{DATE_TO}', CREATE_DATE, REP_JNTS)) AS JNTS_REPAR_THIS," +
                      $"SUM(FNC_BETWEEN_DATE(TO_DATE('{DATE_FROM}') -7, TO_DATE('{DATE_FROM}') - 1, CREATE_DATE, WELD_JNTS)) AS JNTS_WELDED_LAST_WEEK," +
                      $"SUM(FNC_BETWEEN_DATE(TO_DATE('{DATE_FROM}') -7, TO_DATE('{DATE_FROM}') - 1, CREATE_DATE, RT_JNTS)) AS JNTS_RT_DONE_LAST_WEEK," +
                      $"SUM(FNC_BETWEEN_DATE(TO_DATE('{DATE_FROM}') -7, TO_DATE('{DATE_FROM}') - 1, CREATE_DATE, REP_JNTS)) AS JNTS_REPAR_LAST_WEEK," +
                      $"SUM(FNC_IIF_DATE(CREATE_DATE, TO_DATE('{DATE_FROM}' )-7, 0, WELD_JNTS, 0)) AS JNTS_WELDED_PREV," +
                      $"SUM(FNC_IIF_DATE(CREATE_DATE, TO_DATE('{DATE_FROM}') -7, 0, RT_JNTS, 0)) AS JNTS_RT_DONE_PREV," +
                      $"SUM(FNC_IIF_DATE(CREATE_DATE, TO_DATE('{DATE_FROM}') -7, 0, REP_JNTS, 0)) AS JNTS_REPAR_PREV FROM VIEW_WELDER_PERF_F " +
                      $"WHERE PROJECT_ID={1}  AND SC_ID = {SUB_CON_ID} " +
                      $"GROUP BY WELDER_ID, WELDER_NO, SC_ID, SUB_CON_NAME, PROJECT_ID, JOB_CODE, CLIENT_NAME, JOB_NAME, PROJ_DESC, MAT_TYPE " +
                      $"ORDER BY SUB_CON_NAME, MAT_TYPE, WELDER_NO";


                using (OracleCommand cmd = new OracleCommand(sql, conn))
                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Welder_Performance_Model welderPerformance = new Welder_Performance_Model();
                        welderPerformance.PROJECT_ID = dr["PROJECT_ID"].ToString();
                        welderPerformance.JOB_CODE = dr["JOB_CODE"].ToString();
                        welderPerformance.CLIENT_NAME = dr["CLIENT_NAME"].ToString();
                        welderPerformance.PROJ_DESC = dr["PROJ_DESC"].ToString();
                        welderPerformance.JOB_NAME = dr["JOB_NAME"].ToString();
                        welderPerformance.MAT_TYPE = dr["MAT_TYPE"].ToString();
                        welderPerformance.SUB_CON_NAME = dr["SUB_CON_NAME"].ToString();
                        welderPerformance.SC_ID = Convert.ToInt32(dr["SC_ID"].ToString());
                        string welderID = dr["WELDER_ID"].ToString();
                        if (!string.IsNullOrEmpty(welderID))
                        {
                            welderPerformance.WELDER_ID = Convert.ToInt32(dr["WELDER_ID"].ToString());
                        }
                        welderPerformance.WELDER_NO = dr["WELDER_NO"].ToString();
                        welderPerformance.JNTS_WELDED_C = Convert.ToDouble(dr["JNTS_WELDED_C"].ToString());
                        welderPerformance.JNTS_RT_DONE_C = Convert.ToDouble(dr["JNTS_RT_DONE_C"].ToString());
                        welderPerformance.JNTS_REPAR_C = Convert.ToDouble(dr["JNTS_REPAR_C"].ToString());
                        welderPerformance.JNTS_WELDED_THIS = Convert.ToDouble(dr["JNTS_WELDED_THIS"].ToString());
                        welderPerformance.JNTS_RT_DONE_THIS = Convert.ToDouble(dr["JNTS_RT_DONE_THIS"].ToString());
                        welderPerformance.JNTS_REPAR_THIS = Convert.ToDouble(dr["JNTS_REPAR_THIS"].ToString());
                        welderPerformance.JNTS_WELDED_LAST_WEEK = Convert.ToDouble(dr["JNTS_WELDED_LAST_WEEK"].ToString());
                        welderPerformance.JNTS_RT_DONE_LAST_WEEK = Convert.ToDouble(dr["JNTS_RT_DONE_LAST_WEEK"].ToString());
                        welderPerformance.JNTS_REPAR_LAST_WEEK = Convert.ToDouble(dr["JNTS_REPAR_LAST_WEEK"].ToString());
                        welderPerformance.JNTS_WELDED_PREV = Convert.ToDouble(dr["JNTS_WELDED_PREV"].ToString());
                        welderPerformance.JNTS_RT_DONE_PREV = Convert.ToDouble(dr["JNTS_RT_DONE_PREV"].ToString());
                        welderPerformance.JNTS_REPAR_PREV = Convert.ToDouble(dr["JNTS_REPAR_PREV"].ToString());
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
        public void GetWelderPerformanceMaterialWiseDetailsPDF(int ProjId, int SUB_CON_ID, string DATE_FROM, string DATE_TO)
        {
            Random random = new Random();
            int fileId = random.Next(1000, 9999);
            string fileName = $"WelderPerformanceMaterialWise_{fileId}.pdf";
            string filePath = $@"C:\Temp\{fileName}";

            if (string.IsNullOrEmpty(DATE_FROM) && string.IsNullOrEmpty(DATE_TO))
            {
                DATE_FROM = DateTime.Now.ToString("dd-MMM-yyyy");
                DATE_TO = DateTime.Now.ToString("dd-MMM-yyyy");
            }

            Welder_Performance_MaterialWise_Report report = new Welder_Performance_MaterialWise_Report();
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

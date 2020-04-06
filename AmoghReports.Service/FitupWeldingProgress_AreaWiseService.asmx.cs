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
using Telerik.Reporting;

namespace AmoghReports.Service
{
    /// <summary>
    /// Summary description for FitupWeldingProgress_AreaWiseService
    /// </summary>
    [WebService(Namespace = "http://maakuthari.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class FitupWeldingProgress_AreaWiseService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetFitupWeldingProgress_AreaWiseDetails(int ProjId, string CAT_ID, int SUB_CON_ID, string DATE_FROM, string DATE_TO, string IsShop)
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            List<FitupWeldingProgress_AreaWise_Model> fitupWeldingProgressList = new List<FitupWeldingProgress_AreaWise_Model>();
            string conn_str = DatabaseTools.AmgDbConnectionString(ProjId);
            using (OracleConnection conn = new OracleConnection(conn_str))
            {
                conn.Open();
                string sql = string.Empty;

                if (string.IsNullOrEmpty(DATE_FROM) && string.IsNullOrEmpty(DATE_TO))
                {
                    DATE_FROM = DateTime.Now.ToString("dd-MMM-yyyy");
                    DATE_TO = DateTime.Now.ToString("dd-MMM-yyyy");
                }

                if (IsShop.ToUpper() == "Y")
                { 
                    string query = "SELECT JOB_CODE, JOB_NAME, PROJ_REM, SUB_CON_ID, " +
                      $"SUB_CON_NAME, AREA_L1, AREA_L2," +
                      $"SUM(S_ID_SCOPE) AS S_ID_SCOPE," +
                      $"SUM(FNC_BETWEEN_DATE('{DATE_FROM}', '{DATE_TO}', FITUP_DATE, S_FITUP_DONE)) AS S_FITUP_DONE," +
                      $"SUM(FNC_BETWEEN_DATE('{DATE_FROM}', '{DATE_TO}', WELD_DATE, S_WELDING_DONE)) AS S_WELDING_DONE," +
                      $"SUM(F_ID_SCOPE) AS F_ID_SCOPE," +
                      $"SUM(FNC_BETWEEN_DATE('{DATE_FROM}', '{DATE_TO}', FITUP_DATE, F_FITUP_DONE)) AS F_FITUP_DONE," +
                      $"SUM(FNC_BETWEEN_DATE('{DATE_FROM}', '{DATE_TO}', WELD_DATE, F_WELDING_DONE)) AS F_WELDING_DONE FROM VIEW_WELDING_REPORT_SF " +
                      $"WHERE PROJECT_ID={1}  AND (SUB_CON_ID = {SUB_CON_ID}  OR {SUB_CON_ID} = 99) " +
                      $"GROUP BY JOB_CODE, JOB_NAME, PROJ_REM, AREA_L1, AREA_L2, SUB_CON_ID, SUB_CON_NAME";
                    sql = query;
                }
                else
                {
                    string query = "SELECT JOB_CODE, JOB_NAME, PROJ_REM, FIELD_SC_ID, " +
                      $"SUB_CON_NAME, AREA_L1, AREA_L2," +
                      $"SUM(F_ID_SCOPE) AS F_ID_SCOPE," +
                      $"SUM(FNC_BETWEEN_DATE('{DATE_FROM}', '{DATE_TO}', FITUP_DATE, F_FITUP_DONE)) AS F_FITUP_DONE," +
                      $"SUM(FNC_BETWEEN_DATE('{DATE_FROM}', '{DATE_TO}', WELD_DATE, F_WELDING_DONE)) AS F_WELDING_DONE FROM VIEW_WELDING_REPORT_FIELD_A " +
                      $"WHERE PROJECT_ID={1}  AND (FIELD_SC_ID = {SUB_CON_ID}  OR {SUB_CON_ID} = 99) " +
                      $"GROUP BY JOB_CODE, JOB_NAME, PROJ_REM, AREA_L1, AREA_L2, FIELD_SC_ID, SUB_CON_NAME";
                    sql = query;
                }

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        FitupWeldingProgress_AreaWise_Model fitupWeldingProgress = new FitupWeldingProgress_AreaWise_Model();
                        fitupWeldingProgress.JOB_CODE = dr["JOB_CODE"].ToString();
                        fitupWeldingProgress.JOB_NAME = dr["JOB_NAME"].ToString();
                        fitupWeldingProgress.PROJ_REM = dr["PROJ_REM"].ToString();
                        fitupWeldingProgress.SUB_CON_NAME = dr["SUB_CON_NAME"].ToString();
                        fitupWeldingProgress.AREA_L1 = dr["AREA_L1"].ToString();
                        fitupWeldingProgress.AREA_L2 = dr["AREA_L2"].ToString();
                        if(IsShop.ToUpper() == "Y")
                        { 
                        fitupWeldingProgress.SUB_CON_ID = Convert.ToInt32(dr["SUB_CON_ID"].ToString());
                        fitupWeldingProgress.S_ID_SCOPE = MathUtility.stringToDouble(dr["S_ID_SCOPE"].ToString());
                        fitupWeldingProgress.S_FITUP_DONE = MathUtility.stringToDouble(dr["S_FITUP_DONE"].ToString());
                        fitupWeldingProgress.S_WELDING_DONE = MathUtility.stringToDouble(dr["S_WELDING_DONE"].ToString());
                        }
                        if (IsShop.ToUpper() == "N")
                        { 
                            fitupWeldingProgress.FIELD_SC_ID = Convert.ToInt32(dr["FIELD_SC_ID"].ToString());
                        }
                        fitupWeldingProgress.F_ID_SCOPE = MathUtility.stringToDouble(dr["F_ID_SCOPE"].ToString());
                        fitupWeldingProgress.F_FITUP_DONE = MathUtility.stringToDouble(dr["F_FITUP_DONE"].ToString());
                        fitupWeldingProgress.F_WELDING_DONE = MathUtility.stringToDouble(dr["F_WELDING_DONE"].ToString());
                        fitupWeldingProgressList.Add(fitupWeldingProgress);
                    }
                }
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = int.MaxValue;
            string data = js.Serialize(fitupWeldingProgressList);
            Context.Response.Write(data);
        } // method


        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetFitupWeldingProgress_AreaWiseDetailsPDF(int ProjId, string CAT_ID, int SUB_CON_ID, string DATE_FROM, string DATE_TO, string IsShop)
        {
            Random random = new Random();
            int fileId = random.Next(1000, 9999);
            string fileName = $"FitupWeldingProgress_Area_Wise_{ fileId}.pdf";
            string filePath = $@"C:\Temp\{fileName}";

            if (string.IsNullOrEmpty(DATE_FROM) && string.IsNullOrEmpty(DATE_TO))
            {
                DATE_FROM = DateTime.Now.ToString("dd-MMM-yyyy");
                DATE_TO = DateTime.Now.ToString("dd-MMM-yyyy");
            }

            if (IsShop.ToUpper() == "Y")
            { 
                FitupWeldingProgressAreaWise report = new FitupWeldingProgressAreaWise();
                Telerik.Reporting.Processing.ReportProcessor reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();
                report.ReportParameters["ProjId"].Value = ProjId;
                report.ReportParameters["CatId"].Value = CAT_ID;
                report.ReportParameters["SubConId"].Value = SUB_CON_ID;
                report.ReportParameters["DateFrom"].Value = DATE_FROM;
                report.ReportParameters["DateTo"].Value = DATE_TO;
                Telerik.Reporting.Processing.RenderingResult renderingResult = reportProcessor.RenderReport("PDF", report, null);

                FileStream fs = new FileStream(filePath, FileMode.Create);
                fs.Write(renderingResult.DocumentBytes, 0, renderingResult.DocumentBytes.Length);
                fs.Close();
            }
            else
            {
                FitupWeldingProgressFieldAreaWise report = new FitupWeldingProgressFieldAreaWise();
                Telerik.Reporting.Processing.ReportProcessor reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();
                report.ReportParameters["ProjId"].Value = ProjId;
                report.ReportParameters["CatId"].Value = CAT_ID;
                report.ReportParameters["SubConId"].Value = SUB_CON_ID;
                report.ReportParameters["DateFrom"].Value = DATE_FROM;
                report.ReportParameters["DateTo"].Value = DATE_TO;
                Telerik.Reporting.Processing.RenderingResult renderingResult = reportProcessor.RenderReport("PDF", report, null);

                FileStream fs = new FileStream(filePath, FileMode.Create);
                fs.Write(renderingResult.DocumentBytes, 0, renderingResult.DocumentBytes.Length);
                fs.Close();
            }

            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.AddHeader("Content-Disposition", $"attachment;filename={fileName}");
            HttpContext.Current.Response.TransmitFile(filePath);
            HttpContext.Current.Response.End();
        }
    }
}

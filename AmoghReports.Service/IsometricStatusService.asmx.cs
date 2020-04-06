using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using AmoghReports.Library;
using Oracle.ManagedDataAccess.Client;

namespace AmoghReports.Service
{
    [WebService(Namespace = "http://maakuthari.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class IsometricStatusService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetSgSummaryMaterialWise(int ProjId)
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            List<IsomeSumaryMaterialModel> items = new List<IsomeSumaryMaterialModel>();
            string conn_str = DatabaseTools.AmgDbConnectionString(ProjId);
            using (OracleConnection conn = new OracleConnection(conn_str))
            {
                conn.Open();
                string sql = "SELECT * FROM REP_SG_SUMMARY_MAT WHERE PROJECT_ID = 1 ORDER BY MAIN_MAT";
                //PROJECT_ID, JOB_CODE, JOB_NAME, CLIENT_NAME, PROJ_REM,
                //APP_LOGO1, APP_LOGO2, APP_LOGO3, MAIN_MAT, RECVD, IDF_RECVD,
                //HOLD_QTY, SG_DONE, BCHK_DONE, TRANSMITTED

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        IsomeSumaryMaterialModel item = new IsomeSumaryMaterialModel();
                        item.ProjectId = int.Parse(dr["PROJECT_ID"].ToString());
                        item.MainMat = dr["MAIN_MAT"].ToString();
                        item.IsoReceived = MathUtility.stringToInt(dr["RECVD"].ToString());
                        item.IdfReceived = MathUtility.stringToInt(dr["IDF_RECVD"].ToString());
                        item.OnHold = MathUtility.stringToInt(dr["HOLD_QTY"].ToString());
                        item.SgDone = MathUtility.stringToInt(dr["SG_DONE"].ToString());
                        item.BackCheckDone = MathUtility.stringToInt(dr["BCHK_DONE"].ToString());
                        item.Transmitted = MathUtility.stringToInt(dr["TRANSMITTED"].ToString());

                        items.Add(item);
                    }
                }
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = int.MaxValue;
            string data = js.Serialize(items);
            Context.Response.Write(data);
        } // method


        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetSgSummaryMaterialWisePDF(int ProjId)
        {
            Random random = new Random();
            int fileId = random.Next(1000, 9999);
            string fileName = $"report_{fileId}.pdf";
            string filePath = $@"C:\Temp\{fileName}";

            IsometricSummaryMatWiselReport report = new IsometricSummaryMatWiselReport();
            Telerik.Reporting.Processing.ReportProcessor reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();
            report.ReportParameters[0].Value = ProjId;
            Telerik.Reporting.Processing.RenderingResult renderingResult = reportProcessor.RenderReport("PDF", report, null);

            FileStream fs = new FileStream(filePath, FileMode.Create);
            fs.Write(renderingResult.DocumentBytes, 0, renderingResult.DocumentBytes.Length);
            fs.Close();

            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.AddHeader("Content-Disposition", $"attachment;filename={fileName}");
            HttpContext.Current.Response.TransmitFile(filePath);
            HttpContext.Current.Response.End();
        }


        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetSgSummaryAreaWise(int ProjId)
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            List<IsomeSumaryAreaWiseModel> items = new List<IsomeSumaryAreaWiseModel>();
            string conn_str = DatabaseTools.AmgDbConnectionString(ProjId);
            using (OracleConnection conn = new OracleConnection(conn_str))
            {
                conn.Open();
                string sql = "SELECT * FROM REP_SG_SUMMARY_AREA WHERE PROJECT_ID = 1 ORDER BY AREA_L2, AREA_L1";
                //PROJECT_ID, JOB_CODE, JOB_NAME, CLIENT_NAME, PROJ_REM,
                //APP_LOGO1, APP_LOGO2, APP_LOGO3, AREA_L1, AREA_L2, RECVD, IDF_RECVD,
                //HOLD_QTY, SG_DONE, BCHK_DONE, TRANSMITTED

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        IsomeSumaryAreaWiseModel item = new IsomeSumaryAreaWiseModel();
                        item.ProjectId = int.Parse(dr["PROJECT_ID"].ToString());
                        item.AreaL1 = dr["AREA_L1"].ToString();
                        item.AreaL2 = dr["AREA_L2"].ToString();
                        item.IsoReceived = MathUtility.stringToInt(dr["RECVD"].ToString());
                        item.IdfReceived = MathUtility.stringToInt(dr["IDF_RECVD"].ToString());
                        item.OnHold = MathUtility.stringToInt(dr["HOLD_QTY"].ToString());
                        item.SgDone = MathUtility.stringToInt(dr["SG_DONE"].ToString());
                        item.BackCheckDone = MathUtility.stringToInt(dr["BCHK_DONE"].ToString());
                        item.Transmitted = MathUtility.stringToInt(dr["TRANSMITTED"].ToString());

                        items.Add(item);
                    }
                }
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = int.MaxValue;
            string data = js.Serialize(items);
            Context.Response.Write(data);
        } // method


        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetSgSummaryAreaWisePDF(int ProjId)
        {
            Random random = new Random();
            int fileId = random.Next(1000, 9999);
            string fileName = $"report_{fileId}.pdf";
            string filePath = $@"C:\Temp\{fileName}";

            IsometricSummaryAreaWiseReport report = new IsometricSummaryAreaWiseReport();
            Telerik.Reporting.Processing.ReportProcessor reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();
            report.ReportParameters[0].Value = ProjId;
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

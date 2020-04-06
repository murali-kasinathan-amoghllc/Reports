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
    /// Summary description for RTReportsService
    /// </summary>
    [WebService(Namespace = "http://maakuthari.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class RTReportsService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetRTSummaryMaterialWise(int ProjId, int CatId)
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            List<RTSummaryMaterialWiseModel> items = new List<RTSummaryMaterialWiseModel>();
            string conn_str = DatabaseTools.AmgDbConnectionString(ProjId);
            using (OracleConnection conn = new OracleConnection(conn_str))
            {
                conn.Open();
                string sql = $"SELECT * FROM REP_RT_SUMMARY_MAT WHERE PROJECT_ID=1 AND CAT_ID={CatId} ORDER BY MAT_TYPE, RT";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        RTSummaryMaterialWiseModel item = new RTSummaryMaterialWiseModel();
                        item.project_id = int.Parse(dr["PROJECT_ID"].ToString());
                        item.mat_type = dr["MAT_TYPE"].ToString();
                        item.cat_id = MathUtility.stringToInt(dr["CAT_ID"].ToString());
                        item.rt_percentage = MathUtility.stringToInt(dr["RT"].ToString());
                        item.jnt_welded = MathUtility.stringToInt(dr["JNT_WELDED"].ToString());
                        item.jnt_nde_done = MathUtility.stringToInt(dr["JNT_NDE_DONE"].ToString());
                        item.jnt_repair = MathUtility.stringToInt(dr["JNT_REPAIR"].ToString());
                        item.jnt_repaired = MathUtility.stringToInt(dr["JNT_REPAIRED"].ToString());
                        item.total_films = MathUtility.stringToInt(dr["TOTAL_FILMS"].ToString());
                        item.acc_films = MathUtility.stringToInt(dr["ACC_FILMS"].ToString());
                        item.rej_films = MathUtility.stringToInt(dr["REJ_FILMS"].ToString());

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
        public void GetRTSummaryMaterialWisePDF(int ProjId, int CatId)
        {
            Random random = new Random();
            int fileId = random.Next(1000, 9999);
            string fileName = $"spool_id_area_wise_{ fileId}.pdf";
            string filePath = $@"C:\Temp\{fileName}";

            RTSummaryMaterialWiseReport report = new RTSummaryMaterialWiseReport();
            Telerik.Reporting.Processing.ReportProcessor reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();
            report.ReportParameters["ProjId"].Value = ProjId;
            report.ReportParameters["CatId"].Value = CatId;
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

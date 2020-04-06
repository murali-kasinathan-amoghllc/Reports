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
    /// Summary description for SpoolGenProgress_LotWise_Service
    /// </summary>
    [WebService(Namespace = "http://maakuthari.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class SpoolGenProgress_LotWise_Service : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetSpoolGenStatusDetails(int ProjId)
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            List<SpoolGenProgress_LotWise_Model> spoolGenProgressList = new List<SpoolGenProgress_LotWise_Model>();
            string conn_str = DatabaseTools.AmgDbConnectionString(ProjId);
            using (OracleConnection conn = new OracleConnection(conn_str))
            {
                conn.Open();
                    string sql = "SELECT * FROM VIEW_ISOME_REP_C" +
                    $" WHERE PROJECT_ID={1} ORDER BY LOT_NO";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SpoolGenProgress_LotWise_Model spoolGen = new SpoolGenProgress_LotWise_Model();
                        spoolGen.PROJECT_ID = dr["PROJECT_ID"].ToString();
                        spoolGen.JOB_CODE = dr["JOB_CODE"].ToString();
                        spoolGen.CLIENT_NAME = dr["CLIENT_NAME"].ToString();
                        spoolGen.PROJ_REM = dr["PROJ_REM"].ToString();
                        spoolGen.JOB_NAME = dr["JOB_NAME"].ToString();
                        string LOT_RECV = dr["LOT_RECV"].ToString();
                        if (!string.IsNullOrEmpty(LOT_RECV))
                        {
                            spoolGen.LOT_RECV = DateTime.Parse(dr["LOT_RECV"].ToString()).ToString("dd-MMM-yyyy");
                        }
                        spoolGen.LOT_NO = dr["LOT_NO"].ToString();
                        spoolGen.HCOPY_RECV = Convert.ToInt32(dr["HCOPY_RECV"].ToString());
                        spoolGen.IDF_RECV = Convert.ToInt32(dr["IDF_RECV"].ToString());
                        spoolGen.MARK_DATE = Convert.ToInt32(dr["MARK_DATE"].ToString());
                        spoolGen.SG_DATE = Convert.ToInt32(dr["SG_DATE"].ToString());
                        spoolGen.SG_BAL = Convert.ToInt32(dr["SG_BAL"].ToString());
                        spoolGen.BACK_CHK = Convert.ToInt32(dr["BACK_CHK"].ToString());
                        spoolGen.BCK_CHK_BAL = Convert.ToInt32(dr["BCK_CHK_BAL"].ToString());
                        spoolGen.MAT_CHK = Convert.ToInt32(dr["MAT_CHK"].ToString());
                        spoolGen.MAT_CHK_BAL = Convert.ToInt32(dr["MAT_CHK_BAL"].ToString());
                        spoolGen.TRANS_QTY = Convert.ToInt32(dr["TRANS_QTY"].ToString());
                        spoolGen.HOLD_QTY = Convert.ToInt32(dr["HOLD_QTY"].ToString());
                        spoolGen.TRANS_BAL = Convert.ToInt32(dr["TRANS_BAL"].ToString());
                        spoolGenProgressList.Add(spoolGen);
                    }
                }
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = int.MaxValue;
            string data = js.Serialize(spoolGenProgressList);
            Context.Response.Write(data);
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetSpoolGenStatusDetailsPDF(int ProjId)
        {
            Random random = new Random();
            int fileId = random.Next(1000, 9999);
            string fileName = $"SpoolGenProgress_Status_{fileId}.pdf";
            string filePath = $@"C:\Temp\{fileName}";

            SpoolGenProgress_LotWise_Report report = new SpoolGenProgress_LotWise_Report();
            Telerik.Reporting.Processing.ReportProcessor reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();
            report.ReportParameters["ProjId"].Value = ProjId;

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

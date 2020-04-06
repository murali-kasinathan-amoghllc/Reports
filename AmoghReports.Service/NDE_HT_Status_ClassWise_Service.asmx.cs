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
    /// Summary description for DuqmNDE_HT_Status_ClassWise_ProdService
    /// </summary>
    [WebService(Namespace = "http://maakuthari.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class NDE_HT_Status_ClassWise_Service : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetNDEHTStatusDetails(int ProjId, string SUB_CON_ID, string CAT_ID, string Inclde_Prod)
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            List<Duqm_NDE_HT_Status_Model> ndeHTStatusList = new List<Duqm_NDE_HT_Status_Model>();
            string conn_str = DatabaseTools.AmgDbConnectionString(ProjId);
            using (OracleConnection conn = new OracleConnection(conn_str))
            {
                conn.Open();
                string sql = string.Empty;
                if (Inclde_Prod.ToUpper() == "Y")
                {
                    string prod = "SELECT * FROM VIEW_LINE_CLASS_WISE_HT" +
                    $" WHERE PROJ_ID={1} AND SUB_CON_ID = '{SUB_CON_ID}' AND CAT_ID= '{CAT_ID}'";
                    sql = prod;
                }
                else
                {
                    string nonProd = "SELECT * FROM VIEW_LINE_CLS_WISE_HT_NON_PROD" +
                   $" WHERE PROJ_ID={1} AND SUB_CON_ID = '{SUB_CON_ID}' AND CAT_ID= '{CAT_ID}'";
                    sql = nonProd;
                }
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Duqm_NDE_HT_Status_Model ndeHTStatus = new Duqm_NDE_HT_Status_Model();
                        ndeHTStatus.PROJ_ID = dr["PROJ_ID"].ToString();
                        ndeHTStatus.JOB_CODE = dr["JOB_CODE"].ToString();
                        ndeHTStatus.CLIENT_NAME = dr["CLIENT_NAME"].ToString();
                        ndeHTStatus.JV_OF = dr["JV_OF"].ToString();
                        ndeHTStatus.JOB_NAME = dr["JOB_NAME"].ToString();
                        ndeHTStatus.SHORT_CODE = dr["SHORT_CODE"].ToString();
                        ndeHTStatus.REP_TITLE1 = dr["REP_TITLE1"].ToString();
                        ndeHTStatus.REP_TITLE2 = dr["REP_TITLE2"].ToString();
                        ndeHTStatus.SUB_CON_ID = Convert.ToInt32(dr["SUB_CON_ID"].ToString());
                        ndeHTStatus.SUB_CON_NAME = dr["SUB_CON_NAME"].ToString();
                        ndeHTStatus.CAT_ID = Convert.ToInt32(dr["CAT_ID"].ToString());

                        bool catName = DatabaseTools.ColumnExists(dr, "CAT_NAME");
                        if (catName)
                        {
                            ndeHTStatus.CAT_NAME = dr["CAT_NAME"].ToString();
                        }

                        //ndePWHTStatus.CAT_NAME = dr["CAT_NAME"].ToString();
                        ndeHTStatus.LINE_CLASS = dr["LINE_CLASS"].ToString();
                        ndeHTStatus.HT = dr["HT"].ToString();
                        ndeHTStatus.TOTAL_JOINTS = Convert.ToInt32(dr["TOTAL_JOINTS"].ToString());
                        ndeHTStatus.HT_WELDED = Convert.ToInt32(dr["HT_WELDED"].ToString());
                        ndeHTStatus.HT_REQUIRED = Convert.ToInt32(dr["HT_REQUIRED"].ToString());
                        ndeHTStatus.HT_REQUESTED = Convert.ToInt32(dr["HT_REQUESTED"].ToString());
                        ndeHTStatus.HT_DONE = Convert.ToInt32(dr["HT_DONE"].ToString());
                        ndeHTStatus.HT_COVERAGE = Convert.ToDouble(dr["HT_COVERAGE"].ToString());
                        ndeHTStatus.HT_BALANCE = Convert.ToInt32(dr["HT_BALANCE"].ToString());
                        ndeHTStatusList.Add(ndeHTStatus);
                    }
                }
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = int.MaxValue;
            string data = js.Serialize(ndeHTStatusList);
            Context.Response.Write(data);
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetNDEHTStatusDetailsPDF(int ProjId, string SUB_CON_ID, string CAT_ID, string Inclde_Prod)
        {
            Random random = new Random();
            int fileId = random.Next(1000, 9999);
            string fileName = $"NDE_HT_Status_{fileId}.pdf";
            string filePath = $@"C:\Temp\{fileName}";

            NDE_HT_Status_ClassWise_Report report = new NDE_HT_Status_ClassWise_Report();
            Telerik.Reporting.Processing.ReportProcessor reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();
            report.ReportParameters["ProjId"].Value = ProjId;
            report.ReportParameters["SubConId"].Value = SUB_CON_ID;
            report.ReportParameters["CatId"].Value = CAT_ID;
            report.ReportParameters["IncludeProd"].Value = Inclde_Prod;

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

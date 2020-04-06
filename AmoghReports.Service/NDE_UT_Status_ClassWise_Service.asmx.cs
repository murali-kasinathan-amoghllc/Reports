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
    /// Summary description for DuqmNDE_UT_Status_ClassWise_ProdService
    /// </summary>
    [WebService(Namespace = "http://maakuthari.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class NDE_UT_Status_ClassWise_Service : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetNDEUTStatusDetails(int ProjId, string SUB_CON_ID, string CAT_ID, string Inclde_Prod)
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            List<Duqm_NDE_UT_Status_Model> ndeUTStatusFieldList = new List<Duqm_NDE_UT_Status_Model>();
            string conn_str = DatabaseTools.AmgDbConnectionString(ProjId);
            using (OracleConnection conn = new OracleConnection(conn_str))
            {
                conn.Open();
                string sql = string.Empty;
                if (Inclde_Prod.ToUpper() == "Y")
                {
                    string prod = "SELECT * FROM VIEW_LINE_CLASS_WISE_UT" +
                      $" WHERE PROJ_ID={1} AND SUB_CON_ID = '{SUB_CON_ID}' AND CAT_ID= '{CAT_ID}'";
                    sql = prod;
                }
                else
                {
                    string nonProd = "SELECT * FROM VIEW_LINE_CLS_UT_NON_PROD" +
                   $" WHERE PROJ_ID={1} AND SUB_CON_ID = '{SUB_CON_ID}' AND CAT_ID= '{CAT_ID}'";
                    sql = nonProd;
                }

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Duqm_NDE_UT_Status_Model ndeUTStatusField = new Duqm_NDE_UT_Status_Model();
                        ndeUTStatusField.PROJ_ID = dr["PROJ_ID"].ToString();
                        ndeUTStatusField.JOB_CODE = dr["JOB_CODE"].ToString();
                        ndeUTStatusField.CLIENT_NAME = dr["CLIENT_NAME"].ToString();
                        ndeUTStatusField.JV_OF = dr["JV_OF"].ToString();
                        ndeUTStatusField.JOB_NAME = dr["JOB_NAME"].ToString();
                        ndeUTStatusField.SHORT_CODE = dr["SHORT_CODE"].ToString();
                        ndeUTStatusField.REP_TITLE1 = dr["REP_TITLE1"].ToString();
                        ndeUTStatusField.REP_TITLE2 = dr["REP_TITLE2"].ToString();
                        ndeUTStatusField.SUB_CON_ID = Convert.ToInt32(dr["SUB_CON_ID"].ToString());
                        ndeUTStatusField.SUB_CON_NAME = dr["SUB_CON_NAME"].ToString();
                        ndeUTStatusField.CAT_ID = Convert.ToInt32(dr["CAT_ID"].ToString());
                        ndeUTStatusField.LINE_CLASS = dr["LINE_CLASS"].ToString();
                        ndeUTStatusField.UT = dr["UT"].ToString();
                        ndeUTStatusField.TOTAL_JOINTS = Convert.ToInt32(dr["TOTAL_JOINTS"].ToString());
                        if(Inclde_Prod == "Y")
                        {
                            ndeUTStatusField.TOTAL_JOINT_LS = Convert.ToInt32(dr["TOTAL_JOINT_LS"].ToString());
                            ndeUTStatusField.LET_JOINTS = Convert.ToInt32(dr["LET_JOINTS"].ToString());
                            ndeUTStatusField.SOB_JOINTS = Convert.ToInt32(dr["SOB_JOINTS"].ToString());
                            ndeUTStatusField.LET_WELDED = Convert.ToInt32(dr["LET_WELDED"].ToString());
                            ndeUTStatusField.SOB_WELDED = Convert.ToInt32(dr["SOB_WELDED"].ToString());
                            ndeUTStatusField.LET_REQUIRED = Convert.ToInt32(dr["LET_REQUIRED"].ToString());
                            ndeUTStatusField.LET_REQUESTED = Convert.ToInt32(dr["LET_REQUESTED"].ToString());
                            ndeUTStatusField.SOB_REQUESTED = Convert.ToInt32(dr["SOB_REQUESTED"].ToString());
                            ndeUTStatusField.LET_DONE = Convert.ToInt32(dr["LET_DONE"].ToString());
                            ndeUTStatusField.SOB_DONE = Convert.ToInt32(dr["SOB_DONE"].ToString());
                            ndeUTStatusField.LET_COVERAGE = Convert.ToDouble(dr["LET_COVERAGE"].ToString());
                            ndeUTStatusField.SOB_COVERAGE = Convert.ToDouble(dr["SOB_COVERAGE"].ToString());
                            ndeUTStatusField.COVERAGE_LS = Convert.ToDouble(dr["COVERAGE_LS"].ToString());
                            ndeUTStatusField.LET_BALANCE = Convert.ToInt32(dr["LET_BALANCE"].ToString());
                            ndeUTStatusField.SOB_BALANCE = Convert.ToInt32(dr["SOB_BALANCE"].ToString());
                        }
                        ndeUTStatusField.SW_JOINTS = Convert.ToInt32(dr["SW_JOINTS"].ToString());
                        ndeUTStatusField.BW_JOINTS = Convert.ToInt32(dr["BW_JOINTS"].ToString());
                        ndeUTStatusField.BW_WELDED = Convert.ToInt32(dr["BW_WELDED"].ToString());
                        ndeUTStatusField.SW_WELDED = Convert.ToInt32(dr["SW_WELDED"].ToString());
                        ndeUTStatusField.BW_REQUIRED = Convert.ToInt32(dr["BW_REQUIRED"].ToString());
                        ndeUTStatusField.SW_REQUIRED = Convert.ToInt32(dr["SW_REQUIRED"].ToString());
                        ndeUTStatusField.BW_REQUESTED = Convert.ToInt32(dr["BW_REQUESTED"].ToString());
                        ndeUTStatusField.SW_REQUESTED = Convert.ToInt32(dr["SW_REQUESTED"].ToString());
                        ndeUTStatusField.BW_DONE = Convert.ToInt32(dr["BW_DONE"].ToString());
                        ndeUTStatusField.SW_DONE = Convert.ToInt32(dr["SW_DONE"].ToString());
                        ndeUTStatusField.BW_COVERAGE = Convert.ToDouble(dr["BW_COVERAGE"].ToString());
                        ndeUTStatusField.SW_COVERAGE = Convert.ToDouble(dr["SW_COVERAGE"].ToString());
                        ndeUTStatusField.COVERAGE = Convert.ToDouble(dr["COVERAGE"].ToString());
                        ndeUTStatusField.BW_BALANCE = Convert.ToInt32(dr["BW_BALANCE"].ToString());
                        ndeUTStatusField.SW_BALANCE = Convert.ToInt32(dr["SW_BALANCE"].ToString());
                        ndeUTStatusFieldList.Add(ndeUTStatusField);
                    }
                }
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = int.MaxValue;
            string data = js.Serialize(ndeUTStatusFieldList);
            Context.Response.Write(data);
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetNDEUTStatusDetailsPDF(int ProjId, string SUB_CON_ID, string CAT_ID, string Inclde_Prod)
        {
            Random random = new Random();
            int fileId = random.Next(1000, 9999);
            string fileName = $"NDE_UT_Status_{fileId}.pdf";
            string filePath = $@"C:\Temp\{fileName}";

            NDE_UT_Status_ClassWise_Report report = new NDE_UT_Status_ClassWise_Report();
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

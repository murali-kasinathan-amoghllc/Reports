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
    /// Summary description for DuqmNDERTStatusFieldService
    /// </summary>
    [WebService(Namespace = "http://maakuthari.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class NDE_RT_Status_ClassWise_Service : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetNDERTStatusDetails(int ProjId, string SUB_CON_ID, string CAT_ID, string Inclde_Prod)
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            List<Duqm_NDE_RT_Status_Field_Model> ndeRTStatusFieldList = new List<Duqm_NDE_RT_Status_Field_Model>();
            string conn_str = DatabaseTools.AmgDbConnectionString(ProjId);
            using (OracleConnection conn = new OracleConnection(conn_str))
            {
                conn.Open();
                string sql = string.Empty;
                if (Inclde_Prod.ToUpper() == "Y")
                {
                    string prod = "SELECT * FROM VIEW_LINE_CLASS_WISE_RT" +
                    $" WHERE PROJ_ID={1} AND SUB_CON_ID = '{SUB_CON_ID}' AND CAT_ID= '{CAT_ID}'";
                    sql = prod;
                }
                else
                {
                    string nonProd = "SELECT * FROM VIEW_LINE_CLS_WISE_RT_NON_PROD" +
                   $" WHERE PROJ_ID={1} AND SUB_CON_ID = '{SUB_CON_ID}' AND CAT_ID= '{CAT_ID}'";
                    sql = nonProd;
                }

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Duqm_NDE_RT_Status_Field_Model ndeRTStatusField = new Duqm_NDE_RT_Status_Field_Model();
                        ndeRTStatusField.PROJ_ID = dr["PROJ_ID"].ToString();
                        ndeRTStatusField.JOB_CODE = dr["JOB_CODE"].ToString();
                        ndeRTStatusField.CLIENT_NAME = dr["CLIENT_NAME"].ToString();
                        ndeRTStatusField.JV_OF = dr["JV_OF"].ToString();
                        ndeRTStatusField.JOB_NAME = dr["JOB_NAME"].ToString();
                        ndeRTStatusField.SHORT_CODE = dr["SHORT_CODE"].ToString();
                        ndeRTStatusField.REP_TITLE1 = dr["REP_TITLE1"].ToString();
                        ndeRTStatusField.REP_TITLE2 = dr["REP_TITLE2"].ToString();
                        ndeRTStatusField.SUB_CON_ID = dr["SUB_CON_ID"].ToString();
                        ndeRTStatusField.SUB_CON_NAME = dr["SUB_CON_NAME"].ToString();
                        ndeRTStatusField.CAT_ID = dr["CAT_ID"].ToString();
                        if (Inclde_Prod == "Y")
                        {
                            ndeRTStatusField.CAT_NAME = dr["CAT_NAME"].ToString();
                        }
                        ndeRTStatusField.LINE_CLASS = dr["LINE_CLASS"].ToString();
                        ndeRTStatusField.RT = Convert.ToInt32(dr["RT"].ToString());
                        ndeRTStatusField.TOTAL_JOINTS = Convert.ToInt32(dr["TOTAL_JOINTS"].ToString());
                        ndeRTStatusField.BW_JOINTS = Convert.ToInt32(dr["BW_JOINTS"].ToString());
                        ndeRTStatusField.SW_JOINTS = Convert.ToInt32(dr["SW_JOINTS"].ToString());
                        ndeRTStatusField.BW_WELDED = Convert.ToInt32(dr["BW_WELDED"].ToString());
                        ndeRTStatusField.SW_WELDED = Convert.ToInt32(dr["SW_WELDED"].ToString());
                        ndeRTStatusField.BW_REQUIRED = Convert.ToInt32(dr["BW_REQUIRED"].ToString());
                        ndeRTStatusField.SW_REQUIRED = Convert.ToInt32(dr["SW_REQUIRED"].ToString());
                        ndeRTStatusField.BW_REQUESTED = Convert.ToInt32(dr["BW_REQUESTED"].ToString());
                        ndeRTStatusField.SW_REQUESTED = Convert.ToInt32(dr["SW_REQUESTED"].ToString());

                        ndeRTStatusField.BW_DONE = Convert.ToInt32(dr["BW_DONE"].ToString());
                        ndeRTStatusField.SW_DONE = Convert.ToInt32(dr["SW_DONE"].ToString());
                        ndeRTStatusField.BW_COVERAGE = Convert.ToDouble(dr["BW_COVERAGE"].ToString());
                        ndeRTStatusField.SW_COVERAGE = Convert.ToDouble(dr["SW_COVERAGE"].ToString());
                        ndeRTStatusField.COVERAGE = Convert.ToDouble(dr["COVERAGE"].ToString());
                        ndeRTStatusField.BW_BALANCE = Convert.ToInt32(dr["BW_BALANCE"].ToString());
                        ndeRTStatusField.SW_BALANCE = Convert.ToInt32(dr["SW_BALANCE"].ToString());
                        //ndeRTStatusField.BW_REJ = dr["BW_REJ"].ToString();
                        //ndeRTStatusField.SW_REJ = dr["SW_REJ"].ToString();
                        //ndeRTStatusField.REPAIR_PCNT = dr["REPAIR_PCNT"].ToString();
                        
                        ndeRTStatusFieldList.Add(ndeRTStatusField);
                    }
                }
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = int.MaxValue;
            string data = js.Serialize(ndeRTStatusFieldList);
            Context.Response.Write(data);
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetNDERTStatusDetailsPDF(int ProjId, string SUB_CON_ID, string CAT_ID, string Inclde_Prod)
        {
            Random random = new Random();
            int fileId = random.Next(1000, 9999);
            string fileName = $"NDE_RT_Status_{fileId}.pdf";
            string filePath = $@"C:\Temp\{fileName}";

            NDE_RT_Status_ClassWise_Report report = new NDE_RT_Status_ClassWise_Report();
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

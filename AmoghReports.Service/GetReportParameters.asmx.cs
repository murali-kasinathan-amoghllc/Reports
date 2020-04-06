using AmoghReports.Library;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace AmoghReports.Service
{
    /// <summary>
    /// Summary description for GetReportParameters
    /// </summary>
    [WebService(Namespace = "http://maakuthari.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class GetReportParameters : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetWeldReportNo(int ProjId, string weldReportNo)
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            List<DuqmDailyWeldingControlSheetModel> weldSummary = new List<DuqmDailyWeldingControlSheetModel>();
            string conn_str = DatabaseTools.AmgDbConnectionString(ProjId);
            using (OracleConnection conn = new OracleConnection(conn_str))
            {
                conn.Open();
                string sql = "SELECT  DISTINCT WELD_REP_NO FROM REP_DAILY_WELDING_CTRL_SHT" +
                    $" WHERE PROJECT_ID={1} AND WELD_REP_NO LIKE '%{weldReportNo}%'";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DuqmDailyWeldingControlSheetModel summary = new DuqmDailyWeldingControlSheetModel();
                        summary.weld_rep_no = dr["WELD_REP_NO"].ToString();
                        weldSummary.Add(summary);
                    }
                }
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = int.MaxValue;
            string data = js.Serialize(weldSummary);
            Context.Response.Write(data);
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetAllSubContractorDetails(int ProjId)
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            List<SubContractorsModel> subConList = new List<SubContractorsModel>();
            string conn_str = DatabaseTools.AmgDbConnectionString(ProjId);
            using (OracleConnection conn = new OracleConnection(conn_str))
            {
                conn.Open();
                string sql = "SELECT SUB_CON_ID, SUB_CON_NAME FROM SUB_CONTRACTOR" +
                    $" WHERE PROJ_ID={1} ORDER BY SUB_CON_NAME";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SubContractorsModel subCon = new SubContractorsModel();
                        subCon.SUB_CON_ID = dr["SUB_CON_ID"].ToString();
                        subCon.SUB_CON_NAME = dr["SUB_CON_NAME"].ToString();
                        subConList.Add(subCon);
                    }
                }
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = int.MaxValue;
            string data = js.Serialize(subConList);
            Context.Response.Write(data);
        }
    }
}

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
    /// Summary description for GetReportXShop
    /// </summary>
    [WebService(Namespace = "http://maakuthari.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class GetReportXShop : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetReportXShopDetails(int ProjId)
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            List<SubContractorsModel> subContractorList = new List<SubContractorsModel>();
            string conn_str = DatabaseTools.AmgDbConnectionString(ProjId);
            using (OracleConnection conn = new OracleConnection(conn_str))
            {
                conn.Open();
                string sql = "SELECT SUB_CON_ID, SUB_CON_NAME FROM SUB_CONTRACTOR" +
                    $" WHERE PROJ_ID={1} AND FAB_SC = 'Y' ORDER BY SUB_CON_NAME";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SubContractorsModel subContractorsModel = new SubContractorsModel();
                        subContractorsModel.SUB_CON_ID = dr["SUB_CON_ID"].ToString();
                        subContractorsModel.SUB_CON_NAME = dr["SUB_CON_NAME"].ToString();
                        subContractorList.Add(subContractorsModel);
                    }
                }
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = int.MaxValue;
            string data = js.Serialize(subContractorList);
            Context.Response.Write(data);
        }
    }
}

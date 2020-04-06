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
    /// Summary description for RFITransmittalService
    /// </summary>
    [WebService(Namespace = "http://maakuthari.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class RFITransmittalService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public int RegisterRFITransmittalDetails(int ProjId, string RFI_Number, int SUB_CON_ID, string Inspector_Name, string Inspection_Date, string Item_Desc, string Inspection_Result)
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            string conn_str = DatabaseTools.AmgDbConnectionString(ProjId);
            int statusCode = 0;
            using (OracleConnection conn = new OracleConnection(conn_str))
            {
                conn.Open();
                string sql = "INSERT INTO RFI_TRANS_MASTER (RFI_NUMBER, PROJECT_ID, SUB_CON_ID, RFI_DATE, INSPECTOR_NAME, INSPECTOR_ACTIVITY, INSPECTION_RESULT, CREATED_AT, CREATED_BY) " +
                                $" VALUES('{RFI_Number}', {1}, {SUB_CON_ID}, '{Inspection_Date}','{Inspector_Name}', '{Item_Desc}', '{Inspection_Result}', '{DateTime.Now.ToString("dd/MMM/yyyy")}', '{Inspector_Name}') ";
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        statusCode = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return statusCode;
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetRFITransmittalDetails(int ProjId, string RFI_Number)
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            List<RFI_Transmittal_Model> rfiTransmittalList = new List<RFI_Transmittal_Model>();
            string conn_str = DatabaseTools.AmgDbConnectionString(ProjId);
            using (OracleConnection conn = new OracleConnection(conn_str))
            {
                conn.Open();
                string sql = "SELECT * FROM VW_RFI_TRANS_MASTER" +
                   $" WHERE PROJECT_ID={1} AND RFI_NUMBER = '{RFI_Number}'";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        RFI_Transmittal_Model rfiTransmittal = new RFI_Transmittal_Model();
                        rfiTransmittal.project_id = dr["project_id"].ToString();
                        rfiTransmittal.rfi_number = dr["rfi_number"].ToString();
                        rfiTransmittal.sub_con_name = dr["sub_con_name"].ToString();
                        rfiTransmittal.rfi_date = dr["rfi_date"].ToString();
                        rfiTransmittal.inspector_name = dr["inspector_name"].ToString();
                        rfiTransmittal.inspector_activity = dr["inspector_activity"].ToString();
                        rfiTransmittal.inspection_result = dr["inspection_result"].ToString();
                        rfiTransmittal.created_at = dr["created_at"].ToString();
                        rfiTransmittal.created_by = dr["created_by"].ToString();
                        rfiTransmittalList.Add(rfiTransmittal);
                    }
                }
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = int.MaxValue;
            string data = js.Serialize(rfiTransmittalList);
            Context.Response.Write(data);
        }
    }
}

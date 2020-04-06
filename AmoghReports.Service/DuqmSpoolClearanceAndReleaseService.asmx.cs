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
    /// Summary description for DuqmSpoolClearanceAndReleaseService
    /// </summary>
    [WebService(Namespace = "http://maakuthari.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class DuqmSpoolClearanceAndReleaseService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetSpoolClearanceAndReleaseServiceDetails(int ProjId, string SpoolId)
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            List<DuqmSpoolClearanceAndReleaseModel> spoolClearance = new List<DuqmSpoolClearanceAndReleaseModel>();
            string conn_str = DatabaseTools.AmgDbConnectionString(ProjId);
            using (OracleConnection conn = new OracleConnection(conn_str))
            {
                conn.Open();
                string sql = "SELECT * FROM VIEW_SPL_CLR_HS" +
                    $" WHERE PROJECT_ID=1 AND spl_id={SpoolId}";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DuqmSpoolClearanceAndReleaseModel clearance = new DuqmSpoolClearanceAndReleaseModel();
                        clearance.LINE_NO = dr["LINE_NO"].ToString();
                        clearance.ISO_TITLE1 = dr["ISO_TITLE1"].ToString();
                        clearance.SPOOL = dr["SPOOL"].ToString();
                        clearance.SC_NAME = dr["SC_NAME"].ToString();
                        clearance.SPL_REV = dr["SPL_REV"].ToString();
                        clearance.SPL_SCR = dr["SPL_SCR"].ToString();
                        clearance.SPL_FCR = dr["SPL_FCR"].ToString();
                        clearance.MAT_CLASS = dr["MAT_CLASS"].ToString();
                        clearance.MAT_TYPE = dr["MAT_TYPE"].ToString();
                        clearance.SPL_PS = dr["SPL_PS"].ToString();
                        clearance.SHOP_ID = dr["SHOP_ID"].ToString();
                        clearance.DIM_CHECK = dr["DIM_CHECK"].ToString();
                        clearance.HYDRO_REP_NO = dr["HYDRO_REP_NO"].ToString();
                        string hydro_rep_date = dr["HYDRO_REP_DATE"].ToString();
                        if (!string.IsNullOrEmpty(hydro_rep_date))
                        {
                            clearance.HYDRO_REP_DATE = DateTime.Parse(dr["HYDRO_REP_DATE"].ToString()).ToString("dd-MMM-yyyy");
                        }
                        clearance.PNT_REP_NO = dr["PNT_REP_NO"].ToString();
                        string pick_rep_no_date = dr["PICK_REP_NO_DATE"].ToString();
                        if ((!string.IsNullOrEmpty(pick_rep_no_date)) && (pick_rep_no_date !="/"))
                        {
                            clearance.PICK_REP_NO_DATE = DateTime.Parse(dr["PICK_REP_NO_DATE"].ToString()).ToString("dd-MMM-yyyy");
                        }

                        clearance.PNT_REQ_NO = dr["PNT_REQ_NO"].ToString();
                        clearance.JOINT_NO = dr["JOINT_NO"].ToString();
                        clearance.JOINT_TYPE = dr["JOINT_TYPE"].ToString();
                        clearance.WPS_NO = dr["WPS_NO"].ToString();
                        clearance.TW_FLG = dr["TW_FLG"].ToString();
                        clearance.MRV_NOS1 = dr["MRV_NOS1"].ToString();
                        clearance.MAT_CODE1 = dr["MAT_CODE1"].ToString();
                        clearance.HEAT_NO1 = dr["HEAT_NO1"].ToString();
                        clearance.FITUP_REP_NO = dr["FITUP_REP_NO"].ToString();
                        clearance.ROOT_HOT_WELDER = dr["ROOT_HOT_WELDER"].ToString();
                        clearance.WELD_REP_NO = dr["WELD_REP_NO"].ToString();
                        clearance.PT_REP_NO = dr["PT_REP_NO"].ToString();
                        clearance.MT_PT_ROOT_REP_NO = dr["MT_PT_ROOT_REP_NO"].ToString();
                        clearance.PMI1_REP_NO = dr["PMI1_REP_NO"].ToString();
                        clearance.RT1_REP_NO = dr["RT1_REP_NO"].ToString();
                        clearance.RT2_REP_NO = dr["RT2_REP_NO"].ToString();

                        clearance.PWHT_REP_NO = dr["PWHT_REP_NO"].ToString();
                        clearance.UT_REP_NO = dr["UT_REP_NO"].ToString();
                        clearance.HT_REP_NO = dr["HT_REP_NO"].ToString();
                        clearance.FT_REP_NO = dr["FT_REP_NO"].ToString();
                        clearance.RT1_PASS_FLG = dr["RT1_PASS_FLG"].ToString();
                        clearance.RT2_PASS_FLG = dr["RT2_PASS_FLG"].ToString();
                        clearance.TRACER = dr["TRACER"].ToString();
                        clearance.SYMBOL = dr["SYMBOL"].ToString();
                        clearance.JOINT_SIZE = dr["JOINT_SIZE"].ToString();
                        clearance.JOINT_THK = dr["JOINT_THK"].ToString();
                        clearance.CAT_NAME = dr["CAT_NAME"].ToString();
                        clearance.MRV_NOS2 = dr["MRV_NOS2"].ToString();
                        clearance.MAT_CODE2 = dr["MAT_CODE2"].ToString();
                        clearance.HEAT_NO2 = dr["HEAT_NO2"].ToString();
                        string fitup_date = dr["FITUP_DATE"].ToString();
                        if (!string.IsNullOrEmpty(fitup_date))
                        {
                            clearance.FITUP_DATE = DateTime.Parse(dr["FITUP_DATE"].ToString()).ToString("dd-MMM-yyyy");
                        }
                        clearance.FILL_CAP_WELDER = dr["FILL_CAP_WELDER"].ToString();

                        string weld_date = dr["WELD_DATE"].ToString();
                        if (!string.IsNullOrEmpty(weld_date))
                        {
                            clearance.WELD_DATE = DateTime.Parse(dr["WELD_DATE"].ToString()).ToString("dd-MMM-yyyy");
                        }

                        string pt_date = dr["PT_DATE"].ToString();
                        if (!string.IsNullOrEmpty(pt_date))
                        {
                            clearance.PT_DATE = DateTime.Parse(dr["PT_DATE"].ToString()).ToString("dd-MMM-yyyy");
                        }

                        string mt_pt_rootRep_date = dr["MT_PT_ROOT_REP_DATE"].ToString();
                        if (!string.IsNullOrEmpty(mt_pt_rootRep_date))
                        {
                            clearance.MT_PT_ROOT_REP_DATE = DateTime.Parse(dr["MT_PT_ROOT_REP_DATE"].ToString()).ToString("dd-MMM-yyyy");
                        }

                        string mt_date = dr["MT_DATE"].ToString();
                        if (!string.IsNullOrEmpty(mt_date))
                        {
                            clearance.MT_DATE = DateTime.Parse(dr["MT_DATE"].ToString()).ToString("dd-MMM-yyyy");
                        }

                        string pmi1_date = dr["PMI1_DATE"].ToString();
                        if (!string.IsNullOrEmpty(pmi1_date))
                        {
                            clearance.PMI1_DATE = DateTime.Parse(dr["PMI1_DATE"].ToString()).ToString("dd-MMM-yyyy");
                        }

                        string rt1_date = dr["RT1_DATE"].ToString();
                        if (!string.IsNullOrEmpty(rt1_date))
                        {
                            clearance.RT1_DATE = DateTime.Parse(dr["RT1_DATE"].ToString()).ToString("dd-MMM-yyyy");
                        }

                        string rt2_date = dr["RT2_DATE"].ToString();
                        if (!string.IsNullOrEmpty(rt2_date))
                        {
                            clearance.RT2_DATE = DateTime.Parse(dr["RT2_DATE"].ToString()).ToString("dd-MMM-yyyy");
                        }

                        string pwht_date = dr["PWHT_DATE"].ToString();
                        if (!string.IsNullOrEmpty(pwht_date))
                        {
                            clearance.PWHT_DATE = DateTime.Parse(dr["PWHT_DATE"].ToString()).ToString("dd-MMM-yyyy");
                        }

                        string ut_date = dr["UT_DATE"].ToString();
                        if (!string.IsNullOrEmpty(ut_date))
                        {
                            clearance.UT_DATE = DateTime.Parse(dr["UT_DATE"].ToString()).ToString("dd-MMM-yyyy");
                        }

                        string ht_date = dr["HT_DATE"].ToString();
                        if (!string.IsNullOrEmpty(ht_date))
                        {
                            clearance.HT_DATE = DateTime.Parse(dr["HT_DATE"].ToString()).ToString("dd-MMM-yyyy");
                        }

                        string ft_date = dr["FT_DATE"].ToString();
                        if (!string.IsNullOrEmpty(ft_date))
                        {
                            clearance.FT_DATE = DateTime.Parse(dr["FT_DATE"].ToString()).ToString("dd-MMM-yyyy");
                        }
                        clearance.UT_PASS_FLG = dr["UT_PASS_FLG"].ToString();
                        clearance.DIM_CHECK = dr["DIM_CHECK"].ToString();
                        clearance.NDE_CMPLT = dr["NDE_CMPLT"].ToString();
                        clearance.PAINT_CLR = dr["PAINT_CLR"].ToString();
                        spoolClearance.Add(clearance);
                    }
                }
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = int.MaxValue;
            string data = js.Serialize(spoolClearance);
            Context.Response.Write(data);
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetSpoolClearanceAndReleaseServicePDF(int ProjId, string SpoolId)
        {
            Random random = new Random();
            int fileId = random.Next(1000, 9999);
            string fileName = $"report_{fileId}.pdf";
            string filePath = $@"C:\Temp\{fileName}";

            Duqm_SpoolClearanceAndReleaseReport report = new Duqm_SpoolClearanceAndReleaseReport();
            Telerik.Reporting.Processing.ReportProcessor reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();
            report.ReportParameters["ProjId"].Value = ProjId;
            report.ReportParameters["SpoolId"].Value = SpoolId;

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

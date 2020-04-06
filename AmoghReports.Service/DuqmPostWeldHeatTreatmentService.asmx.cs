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
    [WebService(Namespace = "http://maakuthari.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class DuqmPostWeldHeatTreatmentService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetPostWeldHeatTreatmentDetails(int ProjId, string NDE_Rep_No)
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            List<PostWeldHeatTreatmentModel> postWeldHeatTreatmentList = new List<PostWeldHeatTreatmentModel>();
            string conn_str = DatabaseTools.AmgDbConnectionString(ProjId);
            using (OracleConnection conn = new OracleConnection(conn_str))
            {
                conn.Open();
                string sql = "SELECT * FROM VIEW_PWHT_REPORT_FORMAT_DT" +
                    $" WHERE PROJECT_ID={1} AND NDE_REP_NO = '{NDE_Rep_No}'";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        PostWeldHeatTreatmentModel pwht = new PostWeldHeatTreatmentModel();
                        pwht.project_id = dr["PROJECT_ID"].ToString();
                        pwht.job_code = dr["JOB_CODE"].ToString();
                        pwht.iso_title1 = dr["ISO_TITLE1"].ToString();
                        pwht.spool = dr["SPOOL"].ToString();
                        pwht.joint_no = dr["JOINT_NO"].ToString();
                        pwht.joint_id = dr["JOINT_ID"].ToString();
                        pwht.root_hot_welder = dr["ROOT_HOT_WELDER"].ToString();
                        pwht.fill_cap_welder = dr["FILL_CAP_WELDER"].ToString();
                        pwht.joint_size_dec = dr["JOINT_SIZE_DEC"].ToString();
                        pwht.schedule = dr["SCHEDULE"].ToString();
                        pwht.joint_type = dr["JOINT_TYPE"].ToString();
                        pwht.weld_process = dr["WELD_PROCESS"].ToString();
                        pwht.material = dr["MATERIAL"].ToString();
                        pwht.wps_no = dr["WPS_NO"].ToString();
                        pwht.pwht = dr["PWHT"].ToString();
                        pwht.nde_rep_no = dr["NDE_REP_NO"].ToString();
                        string nde_date = dr["NDE_DATE"].ToString();
                        if (!string.IsNullOrEmpty(nde_date))
                        {
                            pwht.nde_date = DateTime.Parse(dr["NDE_DATE"].ToString()).ToString("dd-MMM-yyyy");
                        }
                        pwht.pass_flg = dr["PASS_FLG"].ToString();
                        pwht.nde_type = dr["NDE_TYPE"].ToString();
                        pwht.total_films = dr["TOTAL_FILMS"].ToString();
                        pwht.repair_films = dr["REPAIR_FILMS"].ToString();
                        pwht.reshoot_films = dr["RESHOOT_FILMS"].ToString();
                        pwht.repair_code = dr["REPAIR_CODE"].ToString();
                        pwht.cat_name = dr["CAT_NAME"].ToString();
                        pwht.hardness_test = dr["HARDNESS_TEST"].ToString();
                        pwht.joint_thk = dr["JOINT_THK"].ToString();
                        postWeldHeatTreatmentList.Add(pwht);
                    }
                }
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = int.MaxValue;
            string data = js.Serialize(postWeldHeatTreatmentList);
            Context.Response.Write(data);
        }


        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetPostWeldHeatTreatmentDetailsPDF(int ProjId, string NDE_Rep_No)
        {
            Random random = new Random();
            int fileId = random.Next(1000, 9999);
            string fileName = $"report_{fileId}.pdf";
            string filePath = $@"C:\Temp\{fileName}";

            PostWeldHeatTreatmentReport report = new PostWeldHeatTreatmentReport();
            Telerik.Reporting.Processing.ReportProcessor reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();
            report.ReportParameters["ProjId"].Value = ProjId;
            report.ReportParameters["NDE_Report_No"].Value = NDE_Rep_No;

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

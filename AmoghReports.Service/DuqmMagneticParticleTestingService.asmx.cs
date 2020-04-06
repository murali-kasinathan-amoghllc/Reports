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
    public class MagneticParticleTestingService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetMagneticParticleTestingDetails(int ProjId, string NDE_Rep_No)
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            List<MagneticParticleTestingModel> magneticParticleList = new List<MagneticParticleTestingModel>();
            string conn_str = DatabaseTools.AmgDbConnectionString(ProjId);
            using (OracleConnection conn = new OracleConnection(conn_str))
            {
                conn.Open();
                string sql = "SELECT * FROM VIEW_MT_REPORT_FORMAT_DT" +
                    $" WHERE PROJECT_ID={1} AND NDE_REP_NO = '{NDE_Rep_No}'";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        MagneticParticleTestingModel magneticParticle = new MagneticParticleTestingModel();
                        magneticParticle.project_id = dr["PROJECT_ID"].ToString();
                        magneticParticle.job_code = dr["JOB_CODE"].ToString();
                        magneticParticle.iso_title1 = dr["ISO_TITLE1"].ToString();
                        magneticParticle.spool = dr["SPOOL"].ToString();
                        magneticParticle.joint_no = dr["JOINT_NO"].ToString();
                        magneticParticle.joint_id = dr["JOINT_ID"].ToString();
                        magneticParticle.root_hot_welder = dr["ROOT_HOT_WELDER"].ToString();
                        magneticParticle.fill_cap_welder = dr["FILL_CAP_WELDER"].ToString();
                        magneticParticle.joint_size_dec = dr["JOINT_SIZE_DEC"].ToString();
                        magneticParticle.schedule = dr["SCHEDULE"].ToString();
                        magneticParticle.joint_type = dr["JOINT_TYPE"].ToString();
                        magneticParticle.weld_process = dr["WELD_PROCESS"].ToString();
                        magneticParticle.material = dr["MATERIAL"].ToString();
                        magneticParticle.wps_no = dr["WPS_NO"].ToString();
                        magneticParticle.pwht = dr["PWHT"].ToString();
                        magneticParticle.nde_rep_no = dr["NDE_REP_NO"].ToString();
                        string nde_date = dr["NDE_DATE"].ToString();
                        if (!string.IsNullOrEmpty(nde_date))
                        {
                            magneticParticle.nde_date = DateTime.Parse(dr["NDE_DATE"].ToString()).ToString("dd-MMM-yyyy");
                        }
                        magneticParticle.pass_flg = dr["PASS_FLG"].ToString();
                        magneticParticle.nde_type = dr["NDE_TYPE"].ToString();
                        magneticParticle.total_films = dr["TOTAL_FILMS"].ToString();
                        magneticParticle.repair_films = dr["REPAIR_FILMS"].ToString();
                        magneticParticle.reshoot_films = dr["RESHOOT_FILMS"].ToString();
                        magneticParticle.repair_code = dr["REPAIR_CODE"].ToString();
                        magneticParticle.cat_name = dr["CAT_NAME"].ToString();
                        magneticParticleList.Add(magneticParticle);
                    }
                }
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = int.MaxValue;
            string data = js.Serialize(magneticParticleList);
            Context.Response.Write(data);
        }


        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetMagneticParticleTestingDetailsPDF(int ProjId, string NDE_Rep_No)
        {
            Random random = new Random();
            int fileId = random.Next(1000, 9999);
            string fileName = $"report_{fileId}.pdf";
            string filePath = $@"C:\Temp\{fileName}";

            MagneticParticleTestingReport report = new MagneticParticleTestingReport();
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

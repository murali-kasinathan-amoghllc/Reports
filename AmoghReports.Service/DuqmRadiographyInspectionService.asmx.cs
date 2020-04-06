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
    public class RadiographyInspectionService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetRadiographyInspectionDetails(int ProjId, string NDE_Rep_No)
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            List<RadiographyInspectionModel> radiographyInspection = new List<RadiographyInspectionModel>();
            string conn_str = DatabaseTools.AmgDbConnectionString(ProjId);
            using (OracleConnection conn = new OracleConnection(conn_str))
            {
                conn.Open();
                string sql = "SELECT * FROM VIEW_RT_REPORT_FORMAT_DT" +
                    $" WHERE PROJECT_ID={1} AND NDE_REP_NO = '{NDE_Rep_No}'";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        RadiographyInspectionModel inspection = new RadiographyInspectionModel();
                        inspection.project_id = dr["project_id"].ToString();
                        inspection.job_code = dr["job_code"].ToString();
                        inspection.iso_title1 = dr["iso_title1"].ToString();
                        inspection.spool = dr["spool"].ToString();
                        inspection.joint_no = dr["joint_no"].ToString();
                        inspection.joint_id = dr["joint_id"].ToString();
                        inspection.root_hot_welder = dr["root_hot_welder"].ToString();
                        inspection.fill_cap_welder = dr["fill_cap_welder"].ToString();
                        inspection.joint_size_dec = dr["joint_size_dec"].ToString();
                        inspection.schedule = dr["schedule"].ToString();
                        inspection.joint_type = dr["joint_type"].ToString();
                        inspection.weld_process = dr["weld_process"].ToString();
                        inspection.material = dr["material"].ToString();
                        inspection.wps_no = dr["wps_no"].ToString();
                        inspection.pwht = dr["pwht"].ToString();
                        inspection.nde_rep_no = dr["nde_rep_no"].ToString();
                        string nde_date = dr["nde_date"].ToString();
                        if (!string.IsNullOrEmpty(nde_date))
                        {
                            inspection.nde_date = DateTime.Parse(dr["nde_date"].ToString()).ToString("dd-MMM-yyyy");
                        }
                        inspection.pass_flg = dr["pass_flg"].ToString();
                        inspection.nde_type = dr["nde_type"].ToString();
                        inspection.total_films = dr["total_films"].ToString();
                        inspection.repair_films = dr["repair_films"].ToString();
                        inspection.reshoot_films = dr["reshoot_films"].ToString();
                        inspection.repair_code = dr["repair_code"].ToString();
                        radiographyInspection.Add(inspection);
                    }
                }
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = int.MaxValue;
            string data = js.Serialize(radiographyInspection);
            Context.Response.Write(data);
        }


        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetRadiographyInspectionDetailsPDF(int ProjId, string NDE_Rep_No)
        {
            Random random = new Random();
            int fileId = random.Next(1000, 9999);
            string fileName = $"report_{fileId}.pdf";
            string filePath = $@"C:\Temp\{fileName}";

            RadiographyInspectionReport report = new RadiographyInspectionReport();
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

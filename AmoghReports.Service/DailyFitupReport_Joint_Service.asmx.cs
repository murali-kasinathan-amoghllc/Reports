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
    /// Summary description for DailyFitup_Joint_Shop_Service
    /// </summary>
    [WebService(Namespace = "http://maakuthari.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class DailyFitup_Joint_Service : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetDailyFitupJointDetails(int PROJECT_ID, string SUB_CON_ID, string CAT_ID, string MAT_TYPE, string DATE_FROM, string DATE_TO)
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            List<DailyFitupWelding_Joint_Model> dailyFitupJointShopList = new List<DailyFitupWelding_Joint_Model>();
            string conn_str = DatabaseTools.AmgDbConnectionString(PROJECT_ID);
            using (OracleConnection conn = new OracleConnection(conn_str))
            {
                conn.Open();
                string sql = string.Empty;

                if (string.IsNullOrEmpty(DATE_FROM) && string.IsNullOrEmpty(DATE_TO))
                {
                    DATE_FROM = DateTime.Now.ToString("dd-MMM-yyyy");
                    DATE_TO = DateTime.Now.ToString("dd-MMM-yyyy");
                }


                if (CAT_ID == "1")
                {
                    string categoryType = "SELECT * FROM VIEW_WELDING_REPORT" +
                    $" WHERE PROJECT_ID={1} AND (SUB_CON_ID = '{SUB_CON_ID}' OR '{SUB_CON_ID}' ='99') AND (CAT_ID= '{1}' OR CAT_ID='{3}') AND (FITUP_DATE >= '{DATE_FROM}') AND (FITUP_DATE <= '{DATE_TO}') AND (MAT_TYPE = '{MAT_TYPE}' OR '{MAT_TYPE}' = 'XXX') ORDER BY ISO_TITLE1, SPOOL, JOINT_NO";
                    sql = categoryType;
                }
                else
                {
                    string categoryType = "SELECT * FROM VIEW_WELDING_REPORT" +
                    $" WHERE PROJECT_ID={1} AND (SUB_CON_ID = '{SUB_CON_ID}' OR '{SUB_CON_ID}' ='99') AND (CAT_ID= '{2}' OR CAT_ID='{4}') AND (FITUP_DATE >= '{DATE_FROM}') AND (FITUP_DATE <= '{DATE_TO}') AND (MAT_TYPE = '{MAT_TYPE}' OR '{MAT_TYPE}' = 'XXX') ORDER BY ISO_TITLE1, SPOOL, JOINT_NO";
                    sql = categoryType;
                }


                using (OracleCommand cmd = new OracleCommand(sql, conn))
                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DailyFitupWelding_Joint_Model dailyFitupJointShop = new DailyFitupWelding_Joint_Model();
                        dailyFitupJointShop.project_id = dr["PROJECT_ID"].ToString();
                        dailyFitupJointShop.job_code = dr["job_code"].ToString();
                        dailyFitupJointShop.client_name = dr["client_name"].ToString();
                        dailyFitupJointShop.rep_title1 = dr["rep_title1"].ToString();
                        dailyFitupJointShop.rep_title2 = dr["rep_title2"].ToString();
                        dailyFitupJointShop.job_name = dr["job_name"].ToString();
                        dailyFitupJointShop.proj_rem = dr["proj_rem"].ToString();
                       // dailyFitupJointShop.app_logo1 = dr["app_logo1"].ToString();
                       // dailyFitupJointShop.app_logo2 = dr["app_logo2"].ToString();
                        //dailyFitupJointShop.wo_id = dr["wo_id"].ToString();
                        //dailyFitupJointShop.wo_name = dr["wo_name"].ToString();
                        dailyFitupJointShop.sub_con_id = dr["sub_con_id"].ToString();
                        dailyFitupJointShop.sub_con_name = dr["sub_con_name"].ToString();
                        //dailyFitupJointShop.iso_id = dr["iso_id"].ToString();
                        dailyFitupJointShop.line_no = dr["line_no"].ToString();
                        dailyFitupJointShop.iso_title1 = dr["iso_title1"].ToString();
                        //dailyFitupJointShop.sheet = dr["sheet"].ToString();
                        dailyFitupJointShop.spool = dr["spool"].ToString();
                        dailyFitupJointShop.rev_no = dr["rev_no"].ToString();
                        dailyFitupJointShop.fcr = dr["fcr"].ToString();
                        dailyFitupJointShop.scr = dr["scr"].ToString();
                        //dailyFitupJointShop.area_l1 = dr["area_l1"].ToString();
                        //dailyFitupJointShop.train = dr["train"].ToString();
                        //dailyFitupJointShop.srv_code = dr["srv_code"].ToString();
                        dailyFitupJointShop.spl_id = dr["spl_id"].ToString();
                        dailyFitupJointShop.main_mat = dr["main_mat"].ToString();
                        dailyFitupJointShop.field_sc_id = dr["field_sc_id"].ToString();
                        dailyFitupJointShop.field_sc_name = dr["field_sc_name"].ToString();
                        dailyFitupJointShop.mat_type = dr["mat_type"].ToString();
                        dailyFitupJointShop.mat_class = dr["mat_class"].ToString();
                        dailyFitupJointShop.joint_id = dr["joint_id"].ToString();
                        dailyFitupJointShop.joint_no = dr["joint_no"].ToString();
                        dailyFitupJointShop.rev_code = dr["rev_code"].ToString();
                        dailyFitupJointShop.crw_code = dr["crw_code"].ToString();
                        dailyFitupJointShop.joint_type = dr["joint_type"].ToString();
                        dailyFitupJointShop.joint_size = dr["joint_size"].ToString();
                        dailyFitupJointShop.joint_size_dec = dr["joint_size_dec"].ToString();
                        dailyFitupJointShop.joint_thk = dr["joint_thk"].ToString();
                        dailyFitupJointShop.schedule = dr["schedule"].ToString();
                        dailyFitupJointShop.cat_id = dr["cat_id"].ToString();
                        dailyFitupJointShop.cat_name = dr["cat_name"].ToString();
                        dailyFitupJointShop.item_1 = dr["item_1"].ToString();
                        dailyFitupJointShop.item_2 = dr["item_2"].ToString();
                        //dailyFitupJointShop.mat_id1 = dr["mat_id1"].ToString();
                        //dailyFitupJointShop.mat_id2 = dr["mat_id2"].ToString();
                        //dailyFitupJointShop.mat_code1 = dr["mat_code1"].ToString();
                        //dailyFitupJointShop.short_descr1 = dr["short_descr1"].ToString();
                        //dailyFitupJointShop.mat_code2 = dr["mat_code2"].ToString();
                        //dailyFitupJointShop.short_descr2 = dr["short_descr2"].ToString();
                        dailyFitupJointShop.heat_no1 = dr["heat_no1"].ToString();
                        dailyFitupJointShop.heat_no2 = dr["heat_no2"].ToString();
                        dailyFitupJointShop.fitup_rep_no = dr["fitup_rep_no"].ToString();
                        dailyFitupJointShop.weld_rep_no = dr["weld_rep_no"].ToString();
                        dailyFitupJointShop.weld_insp = dr["weld_insp"].ToString();
                        //dailyFitupJointShop.amg_insp_rep = dr["amg_insp_rep"].ToString();
                        string fitupDate = dr["fitup_date"].ToString();
                        if (!string.IsNullOrEmpty(fitupDate))
                        {
                            dailyFitupJointShop.fitup_date = DateTime.Parse(dr["fitup_date"].ToString()).ToString("dd-MMM-yyyy");
                        }
                        string weld_insp_date = dr["weld_insp_date"].ToString();
                        if (!string.IsNullOrEmpty(weld_insp_date))
                        {
                            dailyFitupJointShop.weld_insp_date = DateTime.Parse(dr["weld_insp_date"].ToString()).ToString("dd-MMM-yyyy");
                        }
                        string weld_date = dr["weld_date"].ToString();
                        if (!string.IsNullOrEmpty(weld_date))
                        {
                            dailyFitupJointShop.weld_date = DateTime.Parse(dr["weld_date"].ToString()).ToString("dd-MMM-yyyy");
                        }
                        string weld_entry_date = dr["weld_entry_date"].ToString();
                        if (!string.IsNullOrEmpty(weld_entry_date))
                        {
                            dailyFitupJointShop.weld_entry_date = DateTime.Parse(dr["weld_entry_date"].ToString()).ToString("dd-MMM-yyyy");
                        }
                        dailyFitupJointShop.fitup_insp = dr["fitup_insp"].ToString();
                        dailyFitupJointShop.amg_weld_rep = dr["amg_weld_rep"].ToString();
                        dailyFitupJointShop.root_hot_welder = dr["root_hot_welder"].ToString();
                        dailyFitupJointShop.fill_cap_welder = dr["fill_cap_welder"].ToString();
                        dailyFitupJointShop.rt = dr["rt"].ToString();
                        dailyFitupJointShop.pt = dr["pt"].ToString();
                        dailyFitupJointShop.mt = dr["mt"].ToString();
                        dailyFitupJointShop.pwht = dr["pwht"].ToString();
                        dailyFitupJointShop.pmi = dr["pmi"].ToString();
                        dailyFitupJointShop.ht = dr["ht"].ToString();
                        //dailyFitupJointShop.wps_no = dr["wps_no"].ToString();
                        //dailyFitupJointShop.prog_factor = dr["prog_factor"].ToString();
                        //dailyFitupJointShop.cns_batch = dr["cns_batch"].ToString();
                        dailyFitupJointShop.weld_process = dr["weld_process"].ToString();
                       
                        dailyFitupJointShopList.Add(dailyFitupJointShop);
                    }
                }
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = int.MaxValue;
            string data = js.Serialize(dailyFitupJointShopList);
            Context.Response.Write(data);
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetDailyFitupJointDetailsPDF(int PROJECT_ID, string SUB_CON_ID, string CAT_ID, string MAT_TYPE, string DATE_FROM, string DATE_TO)
        {
            Random random = new Random();
            int fileId = random.Next(1000, 9999);
            string fileName = $"DailyFitupWeldingReport_{fileId}.pdf";
            string filePath = $@"C:\Temp\{fileName}";

            if (string.IsNullOrEmpty(DATE_FROM) && string.IsNullOrEmpty(DATE_TO))
            {
                DATE_FROM = DateTime.Now.ToString("dd-MMM-yyyy");
                DATE_TO = DateTime.Now.ToString("dd-MMM-yyyy");
            }

            if (CAT_ID == "1")
            { 
                DailyFitupShopReport report = new DailyFitupShopReport();
                Telerik.Reporting.Processing.ReportProcessor reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();
                report.ReportParameters["ProjId"].Value = PROJECT_ID;
                report.ReportParameters["SubConId"].Value = SUB_CON_ID;
                report.ReportParameters["CatId"].Value = CAT_ID;
                report.ReportParameters["MatType"].Value = MAT_TYPE;
                report.ReportParameters["DateFrom"].Value = DATE_FROM;
                report.ReportParameters["DateTo"].Value = DATE_TO;

                Telerik.Reporting.Processing.RenderingResult renderingResult = reportProcessor.RenderReport("PDF", report, null);

                FileStream fs = new FileStream(filePath, FileMode.Create);
                fs.Write(renderingResult.DocumentBytes, 0, renderingResult.DocumentBytes.Length);
                fs.Close();
            }
            else
            {
                DailyFitup_Joint_Field_Report report = new DailyFitup_Joint_Field_Report();
                Telerik.Reporting.Processing.ReportProcessor reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();
                report.ReportParameters["ProjId"].Value = PROJECT_ID;
                report.ReportParameters["SubConId"].Value = SUB_CON_ID;
                report.ReportParameters["CatId"].Value = CAT_ID;
                report.ReportParameters["MatType"].Value = MAT_TYPE;
                report.ReportParameters["DateFrom"].Value = DATE_FROM;
                report.ReportParameters["DateTo"].Value = DATE_TO;

                Telerik.Reporting.Processing.RenderingResult renderingResult = reportProcessor.RenderReport("PDF", report, null);

                FileStream fs = new FileStream(filePath, FileMode.Create);
                fs.Write(renderingResult.DocumentBytes, 0, renderingResult.DocumentBytes.Length);
                fs.Close();
            }
            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.AddHeader("Content-Disposition", $"attachment;filename={fileName}");
            HttpContext.Current.Response.TransmitFile(filePath);
            HttpContext.Current.Response.End();
        }
    }
}

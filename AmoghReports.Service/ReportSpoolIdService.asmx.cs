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
using Telerik.Reporting;

namespace AmoghReports.Service
{
    [WebService(Namespace = "http://maakuthari.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ReportSpoolIdService : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetAreaWise(int ProjId)
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            List<ReportSpoolIdAreaWiseModel> areas = new List<ReportSpoolIdAreaWiseModel>();
            string conn_str = DatabaseTools.AmgDbConnectionString(ProjId);
            using (OracleConnection conn = new OracleConnection(conn_str))
            {
                conn.Open();
                string sql = "SELECT * FROM REP_SPOOL_INCH_DIA_AREA"
                    + $" WHERE LENGTH(NVL(AREA_L1,''))>0 AND PROJECT_ID=1";


                using (OracleCommand cmd = new OracleCommand(sql, conn))
                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //PROJECT_ID, JOB_CODE, JOB_NAME, CLIENT_NAME, PROJ_REM,
                        //APP_LOGO1, APP_LOGO2, AREA_L2, AREA_L1, SG_SHOP, SG_FIELD,
                        //MAT_AVL, JC_ISSUED, SWN, NDE_CMPLT, DIM_CHECK, QC_CLEARED,
                        //PAINT_REQ, SHIPPING_JC, PAINTED, SHIPPING, SHOP_FITUP,
                        //SHOP_WELDING, FIELD_FITUP, FIELD_WELDING

                        ReportSpoolIdAreaWiseModel area = new ReportSpoolIdAreaWiseModel();
                        area.project_id = int.Parse(dr["PROJECT_ID"].ToString());
                        area.job_code = dr["JOB_CODE"].ToString();
                        area.job_name = dr["JOB_NAME"].ToString();
                        area.client_name = dr["CLIENT_NAME"].ToString();
                        area.proj_rem = dr["PROJ_REM"].ToString();
                        area.app_logo1 = dr["APP_LOGO1"].ToString();
                        area.area_l1 = dr["AREA_L1"].ToString();
                        area.area_l2 = dr["AREA_L2"].ToString();
                        area.sg_shop = MathUtility.stringToDouble(dr["SG_SHOP"].ToString());
                        area.sg_field = MathUtility.stringToDouble(dr["SG_FIELD"].ToString());
                        area.mat_avl = MathUtility.stringToDouble(dr["MAT_AVL"].ToString());
                        area.jc_issued = MathUtility.stringToDouble(dr["JC_ISSUED"].ToString());
                        area.swn = MathUtility.stringToDouble(dr["SWN"].ToString());
                        area.dim_check = MathUtility.stringToDouble(dr["DIM_CHECK"].ToString());
                        area.qc_cleared = MathUtility.stringToDouble(dr["QC_CLEARED"].ToString());
                        area.paint_req = MathUtility.stringToDouble(dr["PAINT_REQ"].ToString());
                        area.shipping_jc = MathUtility.stringToDouble(dr["SHIPPING_JC"].ToString());
                        area.painted = MathUtility.stringToDouble(dr["PAINTED"].ToString());
                        area.shipping = MathUtility.stringToDouble(dr["SHIPPING"].ToString());
                        area.shop_fitup = MathUtility.stringToDouble(dr["SHOP_FITUP"].ToString());
                        area.shop_welding = MathUtility.stringToDouble(dr["SHOP_WELDING"].ToString());
                        area.field_fitup = MathUtility.stringToDouble(dr["FIELD_FITUP"].ToString());
                        area.field_welding = MathUtility.stringToDouble(dr["FIELD_WELDING"].ToString());

                        areas.Add(area);
                    }
                }
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = int.MaxValue;
            string data = js.Serialize(areas);
            Context.Response.Write(data);
        } // method


        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetAreaWisePDF(int ProjId)
        {
            Random random = new Random();
            int fileId = random.Next(1000, 9999);
            string fileName = $"spool_id_area_wise_{ fileId}.pdf";
            string filePath = $@"C:\Temp\{fileName}";

            SpoolIdAreaWise report = new SpoolIdAreaWise();
            Telerik.Reporting.Processing.ReportProcessor reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();
            report.ReportParameters[0].Value = ProjId;
            Telerik.Reporting.Processing.RenderingResult renderingResult = reportProcessor.RenderReport("PDF", report, null);

            FileStream fs = new FileStream(filePath, FileMode.Create);
            fs.Write(renderingResult.DocumentBytes, 0, renderingResult.DocumentBytes.Length);
            fs.Close();

            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.AddHeader("Content-Disposition", $"attachment;filename={fileName}");
            HttpContext.Current.Response.TransmitFile(filePath);
            HttpContext.Current.Response.End();
        }


        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetMaterialWise(int ProjId)
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            List<ReportSpoolIdMatWiseModel> items = new List<ReportSpoolIdMatWiseModel>();
            string conn_str = DatabaseTools.AmgDbConnectionString(ProjId);
            using (OracleConnection conn = new OracleConnection(conn_str))
            {
                conn.Open();
                string sql = "SELECT * FROM REP_SPOOL_INCH_DIA_MAT WHERE PROJECT_ID=1";


                using (OracleCommand cmd = new OracleCommand(sql, conn))
                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ReportSpoolIdMatWiseModel item = new ReportSpoolIdMatWiseModel();
                        item.project_id = int.Parse(dr["PROJECT_ID"].ToString());
                        item.job_code = dr["JOB_CODE"].ToString();
                        item.job_name = dr["JOB_NAME"].ToString();
                        item.client_name = dr["CLIENT_NAME"].ToString();
                        item.proj_rem = dr["PROJ_REM"].ToString();
                        item.mat_type = dr["MAT_TYPE"].ToString();
                        item.sg_shop = MathUtility.stringToDouble(dr["SG_SHOP"].ToString());
                        item.sg_field = MathUtility.stringToDouble(dr["SG_FIELD"].ToString());
                        item.sg_total = MathUtility.stringToDouble(dr["SG_TOTAL_ID"].ToString());
                        item.mat_avl = MathUtility.stringToDouble(dr["MAT_AVL"].ToString());
                        item.jc_issued = MathUtility.stringToDouble(dr["JC_ISSUED"].ToString());
                        item.swn = MathUtility.stringToDouble(dr["SWN"].ToString());
                        item.dim_check = MathUtility.stringToDouble(dr["DIM_CHECK"].ToString());
                        item.qc_cleared = MathUtility.stringToDouble(dr["QC_CLEARED"].ToString());
                        item.paint_req = MathUtility.stringToDouble(dr["PAINT_REQ"].ToString());
                        item.shipping_jc = MathUtility.stringToDouble(dr["SHIPPING_JC"].ToString());
                        item.painted = MathUtility.stringToDouble(dr["PAINTED"].ToString());
                        item.shipping = MathUtility.stringToDouble(dr["SHIPPING"].ToString());
                        item.shop_fitup = MathUtility.stringToDouble(dr["SHOP_FITUP"].ToString());
                        item.shop_welding = MathUtility.stringToDouble(dr["SHOP_WELDING"].ToString());
                        item.field_fitup = MathUtility.stringToDouble(dr["FIELD_FITUP"].ToString());
                        item.field_welding = MathUtility.stringToDouble(dr["FIELD_WELDING"].ToString());

                        items.Add(item);
                    }
                }
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = int.MaxValue;
            string data = js.Serialize(items);
            Context.Response.Write(data);
        } // method


        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetMaterialWiseChartPDF(int ProjId)
        {
            Random random = new Random();
            int fileId = random.Next(1000, 9999);
            string fileName = $"spool_id_chart_{ fileId}.pdf";
            string filePath = $@"C:\Temp\{fileName}";

            SpoolIdPieChart report = new SpoolIdPieChart();
            Telerik.Reporting.Processing.ReportProcessor reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();
            report.ReportParameters[0].Value = ProjId;
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

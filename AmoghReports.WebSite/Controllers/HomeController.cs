using AmoghReports.WebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace AmoghReports.WebSite.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Login()
        {
            ViewBag.Message = "Login page.";

            return View();
        }

        public ActionResult Error()
        {
            ViewBag.Message = "Error page.";

            return View();
        }

        public ActionResult GetUserData(string emailId, string secret)
        {
            Session["MailID"] = emailId;
            string loginUrl = string.Format("https://amoghapps.com/AmoghMobileService/CredentialService.asmx/GetLoginSystem?emailId={0}&secret={1}", emailId, secret);

            using (WebClient client = new WebClient())
            {
                try
                {
                    string loginJson = client.DownloadString(loginUrl);
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    dynamic blogObject = js.Deserialize<dynamic>(loginJson);
                    bool isValid = blogObject["Success"];
                    if (isValid)
                    {
                        Session["UserName"] = "Authorized";
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                }
                catch(Exception ex)
                {
                    throw new Exception("Error");
                }
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ProjectsList()
        {
            if (Session["UserName"] != null)
            {
                if (Session["MailID"] != null)
                {
                    TempData.Keep();
                    string projectsUrl = string.Format("https://amoghapps.com/AmoghMobileService/CredentialService.asmx/GetUserProjects?emailId={0}", Session["MailID"]);
                    using (WebClient client = new WebClient())
                    {
                        JavaScriptSerializer jsProject = new JavaScriptSerializer();
                        string projects = client.DownloadString(projectsUrl);
                        List<ProjectsModel> json_pjs = jsProject.Deserialize<List<ProjectsModel>>(projects);
                        return View(json_pjs);
                    }

                }
            }
            return RedirectToAction("Login");
        }

        public JsonResult GetReportsList(string catId)
        {
            string ProjId = Convert.ToString(Session["ProjId"]);
            string categoryID;
            if (string.IsNullOrEmpty(catId))
                categoryID = "-1";
            else
                categoryID =  catId;
            
            string reportUrl = string.Format("https://amoghapps.com/AmoghMobileService/ReportListService.asmx/GetReportList?ProjId={0}&CategoryId={1}", ProjId, categoryID);
            using (WebClient client = new WebClient())
            {
                string reportsJson = client.DownloadString(reportUrl);
                JavaScriptSerializer js = new JavaScriptSerializer();
                List<ReportItemModel> json_rpts = js.Deserialize<List<ReportItemModel>>(reportsJson);

                if(ProjId == "2")
                    json_rpts.Add(new ReportItemModel { reportId = 50, reportTitle = "RFI INSPECTION" });

                if (json_rpts != null)
                {
                    //TempData["Reports"] = json_rpts;
                    //var result = new { data = json_rpts, ProjId = ProjId };
                    return Json(new { data = json_rpts }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(false);
        }

        public ActionResult ReportsList(int? ProjId)
        {
            if (Session["UserName"] != null && ProjId != null)
            {
                Session["ProjId"] = ProjId;
                //var reportsList = TempData["Reports"];
                //TempData.Keep();
                return View();
            }
            return RedirectToAction("Login");
        }

        //public JsonResult ReportTemplates(ReportItemModel reportItemModel)
        //{
        //    string reportName = string.Empty;
        //    string reportDesc = string.Empty;
        //    string reportURL = string.Empty;
        //    if (reportItemModel.reportId == 1)
        //    {
        //        reportName = "SPOOL INCH-DIA SUMMARY";
        //        reportDesc = "SPOOL INCH-DIA SUMMARY";
        //        reportURL = "../../Reports/WeldingSummaryReport.aspx?ReportName={0}&Height={1}";
        //    }

        //    var rptInfo = new ReportInfo
        //    {
        //        ReportName = reportName,
        //        ReportDescription = reportDesc,
        //        ReportURL = String.Format(reportURL, reportName, 650),
        //        Width = 100,
        //        Height = 500
        //    };

        //    TempData["Res"] = rptInfo;
        //    return Json(true);
        //}

        //public ActionResult ReportTemplate()
        //{
        //    var reportsList = TempData["Res"];
        //    return View(reportsList);
        //}

        public ActionResult LogOut()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login");
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult ForgetPassword()
        {
            return View();
        }

        public JsonResult Signup(string emailId)
        {
            string registerUrl = string.Format("https://amoghapps.com/AmoghMobileService/CredentialService.asmx/SignUpUser?emailId={0}", emailId);

            using (WebClient client = new WebClient())
            {
                string signupJson = client.DownloadString(registerUrl);
                JavaScriptSerializer js = new JavaScriptSerializer();
                dynamic blogObject = js.Deserialize<dynamic>(signupJson);
                bool isValid = blogObject["Success"];
                if (isValid)
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ForgetPasswordLink(string emailId)
        {
            string resetUrl = string.Format("https://amoghapps.com/AmoghMobileService/CredentialService.asmx/ResetPassword?emailId={0}", emailId);

            using (WebClient client = new WebClient())
            {
                string resetJson = client.DownloadString(resetUrl);
                JavaScriptSerializer js = new JavaScriptSerializer();
                dynamic blogObject = js.Deserialize<dynamic>(resetJson);
                bool isValid = blogObject["Success"];
                if (isValid)
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AmoghHome.Web.Models;
using System.Web.Script.Serialization;

namespace AmoghHome.Web.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProjectsList()
        {
            if (Session["UserName"] != null)
            {
                if (Session["MailID"] != null)
                {
                    TempData.Keep();
                    string projectsUrl = string.Format("http://maakuthari.com/AmoghMobileService/CredentialService.asmx/GetUserProjects?emailId={0}", Session["MailID"]);
                    using (WebClient client = new WebClient())
                    {
                        JavaScriptSerializer jsProject = new JavaScriptSerializer();
                        string projects = client.DownloadString(projectsUrl);
                        List<ProjectsModel> json_pjs = jsProject.Deserialize<List<ProjectsModel>>(projects);
                        return View(json_pjs);
                    }

                }
            }
            return RedirectToAction("Index");
        }

        //[HttpPost]
        public JsonResult GetUserData(string emailId, string secret)
        {
            Session["MailID"] = emailId;
            string loginUrl = string.Format("http://maakuthari.com/AmoghMobileService/CredentialService.asmx/GetLoginSystem?emailId={0}&secret={1}", emailId, secret);
            
            using (WebClient client = new WebClient())
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
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        public JsonResult GetReportsList()
        {
            string ProjId = Convert.ToString(Session["ProjId"]);
            string categoryID = "1";
            string reportUrl = string.Format("http://maakuthari.com/AmoghMobileService/ReportListService.asmx/GetReportList?ProjId={0}&CategoryId={1}", ProjId, categoryID);
            using (WebClient client = new WebClient())
            {
                string reportsJson = client.DownloadString(reportUrl);
                JavaScriptSerializer js = new JavaScriptSerializer();
                List<ReportItemModel> json_rpts = js.Deserialize<List<ReportItemModel>>(reportsJson);
                if(json_rpts!=null)
                {
                    TempData["Reports"] = json_rpts;
                    var result = new { data = json_rpts, ProjId = ProjId };
                    return Json(new { data = json_rpts }, JsonRequestBehavior.AllowGet);
                   // return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(false);
        }

        //[HttpGet]
        public ActionResult ReportsList(int? ProjId)
        {
            if (Session["UserName"] != null && ProjId != null)
            {
                Session["ProjId"] = ProjId;
                //var reportsList = TempData["Reports"];
                //TempData.Keep();
                return View();
            }
            return RedirectToAction("Index");
        }

        //[HttpPost]
        public ActionResult LogOut()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index");
        }

        
        public ActionResult ReportTemplate(string reportName)
        {
            var rptInfo = new ReportInfo
            {
                ReportName = "Welding Report",
                ReportDescription = "Welding Desc",
                ReportURL = String.Format("../../Reports/WeldingSummaryReport.aspx?ReportName={0}&Height={1}", "Welding Report", 650),
                Width = 100,
                Height = 500
            };
           return PartialView(rptInfo);
        }

    }
}